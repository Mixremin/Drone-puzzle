using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.WaitBeforeBlackout")]
    internal class WaitBeforeBlackout : MonoBehaviour
    {
        [SerializeField]
        private bool PlayOnAwake = true;

        [SerializeField]
        private float timeBeforeBlackout = 4f;

        [SerializeField]
        private List<GameObject> objectsToBlackout = new();

        private void Start()
        {
            if (PlayOnAwake)
            {
                StartCount();
            }
        }

        public void StartCount()
        {
            _ = StartCoroutine(WaitRoutine());
        }

        private IEnumerator WaitRoutine()
        {
            yield return new WaitForSeconds(timeBeforeBlackout);
            foreach (GameObject obj in objectsToBlackout)
            {
                obj.SetActive(false);
            }
        }
    }
}
