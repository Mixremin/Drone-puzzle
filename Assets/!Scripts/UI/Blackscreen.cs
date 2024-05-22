using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace _UI
{
    [AddComponentMenu("Scripts/_UI/_UI.Blackscreen")]
    internal class Blackscreen : MonoBehaviour
    {
        [SerializeField]
        private Image blackImage;

        [SerializeField]
        private float fadeInDuration;

        [SerializeField]
        private float fadeOutDuration;

        private Tween fadeTween;


        public void FadeIn(float duration)
        {
            //Locker.instance.LockAll();
            Fade(1f, duration, () => { });
        }


        public void FadeOut(float duration)
        {
            //Locker.instance.InFPSLock();
            Fade(0f, duration, () => { });
        }

        [Button]
        public void FadeIn()
        {
            //Locker.instance.LockAll();
            Fade(1f, fadeInDuration, () => { });
        }

        [Button]
        public void FadeOut()
        {
            //Locker.instance.InFPSLock();
            Fade(0f, fadeOutDuration, () => { });
        }

        private void Fade(float endValue, float duration, TweenCallback onEnd)
        {
            fadeTween.Kill(false);

            fadeTween = blackImage.DOFade(endValue, duration);
            fadeTween.onComplete += onEnd;
        }
    }
}
