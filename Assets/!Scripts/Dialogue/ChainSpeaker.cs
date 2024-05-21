using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace _Dialogue
{
    [AddComponentMenu("Scripts/_Dialogue/_Dialogue.ChainSpeaker")]
    internal class ChainSpeaker : MonoBehaviour
    {

        [Serializable]
        private struct Replica
        {
            public AudioClip replicSound;
            public string subtitleText;
        }

        [InfoBox("@" + nameof(Info))]

        [SerializeField]
        private List<Replica> replicas = new();

        [SerializeField]
        private TextMeshProUGUI subtitleView;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private float WaitBefore = 0f;

        private string Info =>
    $"Total time on of replica +-{replicas.Sum(x => x.replicSound.length)} sec";

        public void StartSpeak()
        {
            audioSource = transform.parent.transform.parent.GetComponent<AudioSource>();
            _ = StartCoroutine(SpeakRoutine());
        }

        private IEnumerator SpeakRoutine()
        {
            yield return new WaitForSeconds(WaitBefore);

            foreach (Replica replica in replicas)
            {
                audioSource.clip = replica.replicSound;
                audioSource.Play();
                subtitleView.text = replica.subtitleText;
                subtitleView.enabled = true;

                yield return new WaitForSeconds(replica.replicSound.length);
            }
            subtitleView.enabled = false;
        }
    }
}
