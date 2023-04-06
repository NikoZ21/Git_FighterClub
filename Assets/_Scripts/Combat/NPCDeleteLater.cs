using UnityEngine;

namespace _Scripts.Combat
{
    public class NPCDeleteLater : MonoBehaviour
    {
        private Health _health;
        private Animator _animator;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damager = collision.GetComponent<Damager>();

            if (!damager) return;

            _animator.CrossFade("Hurt", 0, 0);
            _health.TakeDamage(damager.Damage);

            if (!damager.CompareTag("Projectile")) return;

            Destroy(collision.gameObject);
        }
    }
}