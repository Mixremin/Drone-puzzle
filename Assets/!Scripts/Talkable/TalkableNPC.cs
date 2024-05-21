using _Items;
using _Managers;
using Sirenix.OdinInspector;
using System.Collections;
using UI;
using UnityEngine;

namespace _Talkable
{
    [AddComponentMenu("Scripts/_Talkable/_Talkable.TalkableNPC")]
    internal class TalkableNPC : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private GameObject slideshowParent;

        [SerializeField]
        private Canvas canvas;

        private SlideshowParent slideshowScript;

        [Button]
        private void FindCanvas()
        {
            canvas = FindAnyObjectByType<Canvas>();
        }

        public void Interact()
        {
            _ = StartCoroutine(StartSlideshow());
        }

        private IEnumerator StartSlideshow()
        {
            GameObject newSlideshow = Instantiate(slideshowParent, canvas.transform);
            slideshowScript = newSlideshow.GetComponent<SlideshowParent>();

            BlackScreenManager.instance.FadeIn();
            yield return new WaitForSeconds(BlackScreenManager.instance.FadeInDuration);

            slideshowScript.SlideshowEnded.AddListener(EndSlideshow);
            slideshowScript.StartSlideshow();
        }

        private void EndSlideshow()
        {
            BlackScreenManager.instance.FadeOut();
        }
    }
}
