using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.Enemy")]
    internal class EnemyInRunner : MonoBehaviour, IEnemy
    {
        [SerializeField]
        private int ticks = 3;

        [SerializeField]
        private bool dieOnTouch = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<FirstPersonMovement>(out _) && dieOnTouch)
            {
                SceneManager.LoadScene(2);
            }
        }

        private void Death()
        {
            Debug.Log("Need effect for death");
            Destroy(gameObject);
        }

        public void TakeTick()
        {
            ticks -= 1;
            if (ticks <= 0)
            {
                Death();
            }
        }
    }
}
