using UnityEngine;
using UnityEngine.Playables;

namespace _Cutscene
{
    [AddComponentMenu("Scripts/_Cutscene/_Cutscene.Starter")]
    internal class Starter : MonoBehaviour
    {
        [SerializeField]
        private PlayableDirector cutscene;

        public void StartCutscene()
        {
            cutscene.Play();
        }
    }
}
