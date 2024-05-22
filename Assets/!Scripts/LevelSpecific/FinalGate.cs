using _Items.PuckUps;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.FinalGate")]
    internal class FinalGate : MonoBehaviour
    {
        [SerializeField]
        private int sceneInt = 0;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IPickable>(out _))
            {
                SceneManager.LoadScene(sceneInt);
            }
        }
    }
}
