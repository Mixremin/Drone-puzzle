using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.DeathFloor")]
    internal class DeathFloor : MonoBehaviour
    {
        [SerializeField]
        private float deathFloorHeight = -5f;

        private void Update()
        {
            if (transform.position.y < deathFloorHeight)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
