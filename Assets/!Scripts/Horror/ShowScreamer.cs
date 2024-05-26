using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace _Horror
{
    [AddComponentMenu("Scripts/_Horror/_Horror.ShowScreamer")]
    internal class ShowScreamer : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private float duration;

        [SerializeField]
        private GameObject screamerPrefab;

        private GameObject screamer;

        [Button]
        public void SpawnScreamer()
        {
            screamer = Instantiate(screamerPrefab);
            screamer.transform.SetParent(canvas.transform, false);
            _ = StartCoroutine(ScreamerRoutine());
        }

        private IEnumerator ScreamerRoutine()
        {
            AudioSource scarySource = screamer.GetComponentInChildren<AudioSource>();
            scarySource.Play();
            yield return new WaitForSecondsRealtime(duration);
            scarySource.Stop();
            Destroy(screamer.gameObject);
        }
    }
}
