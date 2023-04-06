using System;
using System.Security.Cryptography;
using _Scripts.Combat;
using _Scripts.FSM_Player;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.FSM_Enemy
{
    public class NPCStateManager : MonoBehaviour
    {
        [SerializeField] private Transform target;
        public Transform GetTarget() => target;

        [SerializeField] private float range = 1;
        public float GetRange() => range;

        [SerializeField] private float minRangeToShoot = 5;
        public float GetMinRangeShoot() => minRangeToShoot;

        [SerializeField] private float speed;
        public float GetSpeed() => speed;

        [SerializeField] private Animator myAnimator;
        public Animator GetMyAnimator() => myAnimator;


        private NPCState _state;

        private Health _health;

        public readonly int HoverAnimationId = Animator.StringToHash("Hover");
        public readonly int IdleAnimationId = Animator.StringToHash("Idle");
        public readonly int DoublePunchAnimationId = Animator.StringToHash("DoublePunch");
        public readonly int SmashAnimationId = Animator.StringToHash("Smash");
        public readonly int RangedAttackAnimationId = Animator.StringToHash("RangedAttack");
        public readonly int HurtAnimationId = Animator.StringToHash("EnemyHurt");
        public readonly int DeathAnimationId = Animator.StringToHash("Death");


        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Start()
        {
            ChangeState(new NPCIdleState(this));
        }

        private void Update()
        {
            _state.Update();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetType() != typeof(CircleCollider2D)) return;

            var damager = collision.GetComponent<Damager>();

            if (!damager) return;

            if (collision.CompareTag("Projectile")) Destroy(collision.gameObject);

            ChangeState(new NPCHurtState(this));

            _health.TakeDamage(damager.Damage);
        }

        public void ChangeState(NPCState newState)
        {
            _state = newState;
            _state.Enter();
        }
    }
}