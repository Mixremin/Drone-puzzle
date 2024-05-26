using Player;
using System.Collections;
using UnityEngine;

namespace _Horror
{
    [AddComponentMenu("Scripts/_Horror/_Horror.TriggerSound")]
    internal class TriggerSound : MonoBehaviour
    {
        [SerializeField]
        private AudioSource horrorSource;

        [SerializeField]
        private bool OnSecondTouch = false;

        private bool activated = false;
        private bool touched = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonMovement _) && !activated)
            {
                if (!OnSecondTouch)
                {
                    activated = true;
                    _ = StartCoroutine(HorrorRoutine());
                }
                else if (touched)
                {
                    activated = true;
                    _ = StartCoroutine(HorrorRoutine());
                }
                else
                {
                    touched = true;
                }

            }
        }

        private IEnumerator HorrorRoutine()
        {
            horrorSource.Play();
            yield return new WaitForSeconds(horrorSource.clip.length);
            Destroy(gameObject);
        }
    }
}
