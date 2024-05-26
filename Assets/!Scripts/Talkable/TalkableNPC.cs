using _Items;
using _Managers;
using Sirenix.OdinInspector;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace _Talkable
{
    [AddComponentMenu("Scripts/_Talkable/_Talkable.TalkableNPC")]
    internal class TalkableNPC : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private GameObject slideshowParent;

        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private bool mainInteraction = true;

        private SlideshowParent slideshowScript;

        public UnityEvent OnDialogueStart;

        [Button]
        private void FindCanvas()
        {
            canvas = FindAnyObjectByType<Canvas>();
        }

        public void Interact()

        {
            if (mainInteraction)
            {
                StartDialogue();
            }
        }

        public void StartDialogue()
        {
            OnDialogueStart?.Invoke();
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
