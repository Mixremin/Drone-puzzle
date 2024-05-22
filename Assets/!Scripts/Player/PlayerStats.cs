using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Player
{
    [AddComponentMenu("Scripts/_Player/_Player.PlayerStats")]
    internal class PlayerStats : MonoBehaviour
    {
        [SerializeField]
        private float playerHealth;
        public void TakeDamage(float damage)
        {
            playerHealth -= damage;
            if (playerHealth <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
