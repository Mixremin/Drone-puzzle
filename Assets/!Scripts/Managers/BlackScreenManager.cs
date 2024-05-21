using _UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Managers
{
    [AddComponentMenu("Scripts/_Managers/_Managers.BlackScreenManager")]
    internal class BlackScreenManager : MonoBehaviour
    {
        [SerializeField]
        private Blackscreen blackScreen;

        [SerializeField]
        private Canvas canvas;

        public float FadeInDuration;

        public float FadeOutDuration;



        public static BlackScreenManager instance = null;

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
        private void FindCanvas()
        {
            canvas = FindAnyObjectByType<Canvas>();
        }

        [Button]
        public void FadeIn()
        {
            blackScreen.FadeIn(FadeInDuration);
        }

        [Button]
        public void FadeOut()
        {
            blackScreen.FadeOut(FadeOutDuration);
        }
    }
}
