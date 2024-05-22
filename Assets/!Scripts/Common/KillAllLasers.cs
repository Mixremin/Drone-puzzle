using _Drone.LaserObj;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Common
{
    [AddComponentMenu("Scripts/_Common/_Common.KillAllLasers")]
    internal class KillAllLasers : MonoBehaviour
    {
        public static KillAllLasers instance = null;

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

        [Button]
        public void KillAll()
        {

            LaserProjectile[] lasers = FindObjectsOfType<LaserProjectile>();
            foreach (LaserProjectile lasser in lasers)
            {
                Destroy(lasser.gameObject);
            }
        }
    }
}
