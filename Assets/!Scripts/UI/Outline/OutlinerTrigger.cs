using EPOOutline;
using Player;
using UnityEngine;

namespace _UI.Outline
{
    [AddComponentMenu("Scripts/_UI/Outline/_UI.OutlinerTrigger")]
    internal class OutlinerTrigger : MonoBehaviour
    {
        [SerializeField]
        private Outlinable outlinedObject;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonMovement _))
            {
                outlinedObject.enabled = true;
                gameObject.SetActive(false);
            }
        }

    }
}
