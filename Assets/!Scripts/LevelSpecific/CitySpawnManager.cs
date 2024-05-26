using _Config;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.CitySpawnManager")]
    internal class CitySpawnManager : MonoBehaviour
    {
        [SerializeField]
        private Transform fistSpawnPoint;

        [SerializeField]
        private Transform secondHalfSpawnPoint;

        private GameObject player;
        private int sceneNum;
        private void Start()
        {
            player = GameObject.Find("Player");
            Scene scene = SceneManager.GetActiveScene();
            switch (scene.buildIndex)
            {
                case 2:
                    CitySpawn();
                    break;
                case 4:
                    LobbySpawn();
                    break;
                default:
                    Debug.Log("Invalid scene");
                    break;
            }
        }

        private void CitySpawn()
        {
            if (!SimpleInventory.instance.japanGamePassed)
            {
                player.transform.position = fistSpawnPoint.position;
            }
            else
            {
                player.transform.position = secondHalfSpawnPoint.position;
            }
        }

        private void LobbySpawn()
        {
            if (!SimpleInventory.instance.runnerPazzlePassed)
            {
                player.transform.position = fistSpawnPoint.position;
                player.transform.rotation = fistSpawnPoint.rotation;
            }
            else
            {
                player.transform.position = secondHalfSpawnPoint.position;
                player.transform.rotation = secondHalfSpawnPoint.rotation;
            }
        }
    }
}
