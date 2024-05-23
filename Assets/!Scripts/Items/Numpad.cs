using _LevelSpecific;
using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.Numpad")]
    internal class Numpad : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ShowTextInteraction doorReady;

        [SerializeField]
        private ShowTextInteraction firstUse;

        [SerializeField]
        private Door door;

        public bool poweredOn = false;

        [SerializeField]
        private bochkiPuzzle bochki;
        public void Interact()
        {
            if (!poweredOn)
            {
                firstUse.Interact();
                bochki.CanStartPuzzle = true;
            }
            else
            {
                doorReady.Interact();
                door.enabled = true;
            }
        }
    }
}
