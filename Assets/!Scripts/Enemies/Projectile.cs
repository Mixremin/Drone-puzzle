using _Player;
using UnityEngine;

namespace _Enemies
{
    [AddComponentMenu("Scripts/_Enemies/_Enemies.Projectile")]
    internal class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float projDamage = 5.0f;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<PlayerStats>().TakeDamage(projDamage);
            }

            Destroy(gameObject);
        }
    }
}
