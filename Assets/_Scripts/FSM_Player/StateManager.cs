using _Scripts.Combat;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.FSM_Player
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] private float speed;

        public float Speed
        {
            get => speed;
        }

        [SerializeField] private float jumpForce;

        public float JumpForce
        {
            get => jumpForce;
        }

        [SerializeField] private Animator myAnimator;

        public Animator MyAnimator
        {
            get => myAnimator;
        }


        public readonly int HoverAnimationId = Animator.StringToHash("Hover");
        public readonly int IdleAnimationId = Animator.StringToHash("Idle");
        public readonly int DoublePunchAnimationId = Animator.StringToHash("DoublePunch");
        public readonly int UpperCutAnimationId = Animator.StringToHash("UpperCut");
        public readonly int SmashAnimationId = Animator.StringToHash("Smash");
        public readonly int RangedAttackAnimationId = Animator.StringToHash("RangedAttack");
        public readonly int HurtAnimationId = Animator.StringToHash("Hurt");
        public readonly int KickAnimationId = Animator.StringToHash("Kick");
        public readonly int DodgeAnimationId = Animator.StringToHash("Dodge");
        public readonly int JumpAnimationId = Animator.StringToHash("Jump");
        public readonly int FallAnimationId = Animator.StringToHash("Fall");
        public readonly int DeathAnimationId = Animator.StringToHash("Death");

        public IState _currentState;

        private Health _health;


        private Rigidbody2D _rb;
        public Rigidbody2D GetRigidBody2D() => _rb;


        private void Awake()
        {
            _health = GetComponent<Health>();
            _rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            _currentState = new IdleState(this);
        }

        void Update()
        {
            _currentState.Update();
            //_currentState.ToString();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetType() != typeof(CircleCollider2D)) return;

            var damager = collision.GetComponent<Damager>();

            if (!damager) return;

            if (collision.CompareTag("Projectile")) Destroy(collision.gameObject);

            ChangeState(new HurtState(this));

            _health.TakeDamage(damager.Damage);
        }

        public void ChangeState(IState newState)
        {
            _currentState = newState;
            _currentState.Enter();
        }
    }
}