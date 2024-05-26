using System.Collections.Generic;
using UnityEngine;

namespace _Enemies
{
    [AddComponentMenu("Scripts/_Enemies/_Enemies.EnemySounds")]
    internal class EnemySounds : MonoBehaviour
    {
        [SerializeField]
        private AudioSource stepSource;

        [SerializeField]
        private AudioSource shootSource;

        [SerializeField]
        private List<AudioClip> stepClips;

        [SerializeField]
        private List<AudioClip> shootClips;

        public void PlayStep()
        {
            if (stepClips != null)
            {
                stepSource.clip = stepClips[Random.Range(0, stepClips.Count)];
                stepSource.Play();
            }
        }

        public void PlayShoot()
        {
            if (shootClips != null)
            {
                shootSource.clip = shootClips[Random.Range(0, shootClips.Count)];
                shootSource.Play();
            }
        }
    }
}
