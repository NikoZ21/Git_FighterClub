using UnityEngine;

namespace _Scripts.Combat
{
    public class SpawnProjectile : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private GameObject projectile;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float lifeTime = 2f;

        public void ShootProjectile()
        {
            GameObject proj = Instantiate(projectile, parent.position, transform.rotation * Quaternion.Euler(0f, 0f, 90f));
            proj.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed * transform.localScale.x;
            Destroy(proj, lifeTime);
        }

    }
}
