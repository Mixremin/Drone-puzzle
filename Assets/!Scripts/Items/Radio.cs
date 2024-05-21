using System; 
using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.Radio")]
    internal class Radio : MonoBehaviour, IInteractable
    {
        internal enum RadioType
        {
            turnedOff,
            music1,
            music2,
            music3,
            noise,
            threat
        }


        [Header("Sound")]
        [SerializeField]
        private AudioSource radioSound;

        [Header("Music")]

        [SerializeField]
        private AudioClip music1;

        [SerializeField]
        private AudioClip music2;

        [SerializeField]
        private AudioClip music3;

        [SerializeField]
        private AudioClip noise;

        [SerializeField]
        private AudioClip threat;

        [Header("Mode")]
        [SerializeField]
        private RadioType radioType = RadioType.turnedOff;

        public void Interact()
        {
            PlayMusic();
        }

        private void PlayMusic()
        {
            switch (radioType)
            {
                case RadioType.turnedOff:
                    radioType = RadioType.music1;
                    ChangeMusic(music1);
                    break;
                case RadioType.music1:
                    radioType = RadioType.music2;
                    ChangeMusic(music2);
                    break;
                case RadioType.music2:
                    radioType = RadioType.music3;
                    ChangeMusic(music3);
                    break;
                case RadioType.music3:
                    radioType = RadioType.noise;
                    ChangeMusic(noise);
                    break;
                case RadioType.noise:
                    radioType = RadioType.threat;
                    ChangeMusic(threat);
                    break;
                case RadioType.threat:
                    radioType = RadioType.turnedOff;
                    radioSound.Stop();
                    break;

            }
        }

        private void ChangeMusic(AudioClip clip)
        {
            radioSound.clip = clip;
            radioSound.loop = true;
            radioSound.Play();
        }
    }
}
