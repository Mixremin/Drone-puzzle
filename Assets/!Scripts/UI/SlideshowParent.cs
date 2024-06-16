using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    [AddComponentMenu("Scripts/UI/UI.SlideshowParent")]
    internal class SlideshowParent : MonoBehaviour
    {
        [Serializable]
        private struct SlideStruct
        {
            public Sprite Slide;
            public float WaitBefore;
            public float HoldTime;
            public float WaitAfter;
            public float FadeTime;
        }

        [InfoBox("@" + nameof(Info))]
        [SerializeField]
        private bool playOnAwake = false;

        [SerializeField]
        private bool childrenComponentsMode = true;

        [ShowIf(nameof(childrenComponentsMode))]
        [SerializeField]
        private List<Slide> slides = new();

        [ShowIf("@!" + nameof(childrenComponentsMode))]
        [SerializeField]
        private List<SlideStruct> slideStructs = new();

        [SerializeField]
        private bool playLast = false;

        public UnityEvent SlideshowStarted;
        public UnityEvent SlideshowEnded;

        private bool skipAll = false;

        private Image image;
        private Tween fadeTween;

        private string Info =>
            $"Total time on playlist +-{slides.Sum(x => x.WaitBefore + x.HoldTime)} sec";

        private void Start()
        {
            if (playOnAwake)
            {
                StartSlideshow();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                skipAll = true;
                StopAllCoroutines();
                SlideshowEnded?.Invoke();
                Destroy(gameObject);
            }
        }

        private IEnumerator ShowSlides()
        {
            if (playLast)
            {
                yield return ShowSlide(slides.Last());
                yield return new WaitForSeconds(slides.Last().FadeTime * 2);
                SlideshowEnded?.Invoke();
            }
            else
            {
                if (childrenComponentsMode)
                {
                    FillChildren();
                    yield return new WaitForSeconds(0.5f);
                    foreach (Slide slide in slides)
                    {
                        if (!skipAll)
                        {
                            yield return ShowSlide(slide);
                        }
                    }

                    yield return new WaitForSeconds(slides.Last().FadeTime * 2);
                    SlideshowEnded?.Invoke();
                }
                else
                {
                    //    if (image == null)
                    //    {
                    //        image = gameObject.AddComponent<Image>();
                    //    }

                    //    image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                    //    foreach (SlideStruct slide in slideStructs)
                    //    {
                    //        yield return ShowSlide(slide);
                    //    }


                    //    yield return new WaitForSeconds(slides.Last().FadeTime * 2);
                    //    SlideshowEnded?.Invoke();
                    //}
                    Debug.Log("Mode need improvement");
                }
            }
        }

        private IEnumerator ShowSlide(Slide slide)
        {
            slide.gameObject.SetActive(true);
            yield return new WaitForSeconds(slide.WaitBefore);
            slide.FadeIn();
            yield return new WaitForSeconds(slide.HoldTime);
            slide.FadeOut();
        }

        private IEnumerator ShowSlide(SlideStruct slide)
        {
            image.sprite = slide.Slide;

            yield return new WaitForSeconds(slide.WaitBefore);
            FadeIn(slide.FadeTime);
            yield return new WaitForSeconds(slide.HoldTime);
            FadeOut(slide.FadeTime);
        }

        [Button]
        public void StartSlideshow()
        {
            SlideshowStarted?.Invoke();
            _ = StartCoroutine(ShowSlides());
        }

        [Button]
        public void FillChildren()
        {
            if (slides.Count == 0)
            {
                foreach (Transform child in transform)
                {
                    slides.Add(child.GetComponent<Slide>());
                }
            }
        }

        public void FadeIn(float duration)
        {
            Fade(1f, duration, () => { });
        }

        public void FadeOut(float duration)
        {
            Fade(0f, duration, () => { });
        }

        private void Fade(float endValue, float duration, TweenCallback onEnd)
        {
            fadeTween.Kill(false);

            fadeTween = image.DOFade(endValue, duration);
            fadeTween.onComplete += onEnd;
        }
    }
}
