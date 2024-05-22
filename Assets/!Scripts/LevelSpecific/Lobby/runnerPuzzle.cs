using _Config;
using _Items;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LevelSpecific.Lobby
{
    [AddComponentMenu("Scripts/_LevelSpecific/Lobby/_LevelSpecific.Lobby.runnerPuzzle")]
    internal class runnerPuzzle : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int runnerScene = 4;

        private void Start()
        {
            if (SimpleInventory.instance.runnerPazzlePassed)
            {
                Destroy(this);
            }
        }

        public void Interact()
        {
            if (!SimpleInventory.instance.runnerPazzlePassed)
            {
                SceneManager.LoadScene(runnerScene);
            }
        }
    }
}
