using _Config;
using UnityEngine;

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
        private void Start()
        {
            player = GameObject.Find("Player");
            if (!SimpleInventory.instance.japanGamePassed)
            {
                player.transform.position = fistSpawnPoint.position;
            }
            else
            {
                player.transform.position = secondHalfSpawnPoint.position;
            }
        }
    }
}
