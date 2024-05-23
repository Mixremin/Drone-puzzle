using System.Collections.Generic;
using UnityEngine;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.SpawnToEnemies")]
    internal class SpawnToEnemies : MonoBehaviour
    {
        [SerializeField]
        private List<EnemyMovement> enemiesToActivate;

        private void OnTriggerEnter(Collider other)
        {
            foreach (EnemyMovement enemy in enemiesToActivate)
            {
                enemy.enabled = true;
            }
            Destroy(gameObject);
        }
    }
}
