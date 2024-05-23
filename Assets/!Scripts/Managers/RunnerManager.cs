using _Config;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Managers
{
    [AddComponentMenu("Scripts/_Managers/_Managers.RunnerManager")]
    internal class RunnerManager : MonoBehaviour
    {
        [Header("Enemy count")]
        [SerializeField]
        private int needToKill = 10;

        [SerializeField]
        private int killedEnemies = 0;

        [Header("Scene num")]
        [SerializeField]
        private int sceneToLoad = 3;

        public static RunnerManager instance = null;

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }

        }

        public void EnemyKilled()
        {
            killedEnemies++;

            if (killedEnemies >= needToKill)
            {
                Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
                SimpleInventory.instance.runnerPazzlePassed = true;
                SceneManager.LoadScene(sceneToLoad);
            }
        }

    }
}
