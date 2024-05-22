using _Managers;
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
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }

        private void Death()
        {
            Debug.Log("Need effect for death");
            if (RunnerManager.instance != null)
            {
                RunnerManager.instance.EnemyKilled();
            }
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
