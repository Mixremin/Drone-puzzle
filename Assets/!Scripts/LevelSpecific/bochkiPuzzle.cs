using _Items;
using _Items.Bochki;
using UnityEngine;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.bochkiPuzzle")]
    internal class bochkiPuzzle : MonoBehaviour, IInteractable
    {
        public bool CanStartPuzzle = false;

        [SerializeField]
        public int enoughBaterries = 2;

        [SerializeField]
        private ShowTextInteraction noWorking;

        [SerializeField]
        private ShowTextInteraction noPower;

        [SerializeField]
        private ShowTextInteraction bochkaPlaced;

        [SerializeField]
        private ShowTextInteraction puzzleDone;

        [SerializeField]
        private ShowTextInteraction alreadyCarrying;

        [SerializeField]
        private Numpad numpad;

        public bool carryingBochka = false;
        private bool puzzleStarted = false;
        private int batteries = 0;

        public void Interact()
        {
            if (!CanStartPuzzle)
            {
                noWorking.Interact();
            }
            else if (CanStartPuzzle && !puzzleStarted)
            {
                noPower.Interact();
                StartPuzzle();
                puzzleStarted = true;
            }
            else if (carryingBochka)
            {
                bochkaPlaced.Interact();
                batteries++;
                carryingBochka = false;
                if (batteries >= enoughBaterries)
                {
                    puzzleDone.Interact();
                    numpad.poweredOn = true;
                    StopPuzzle();
                }
            }
        }


        private void StartPuzzle()
        {
            foreach (Transform child in transform)
            {
                if (child != null)
                {
                    Bochka comp = child.gameObject.AddComponent<Bochka>();
                    comp.SetPuzzle(this);
                }
            }
        }

        private void StopPuzzle()
        {
            foreach (Transform child in transform)
            {
                if (child != null)
                {
                    Bochka comp = child.gameObject.AddComponent<Bochka>();
                    Destroy(comp);
                }
            }
        }
    }
}
