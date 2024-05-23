using _LevelSpecific;
using UnityEngine;

namespace _Items.Bochki
{
    [AddComponentMenu("Scripts/_Items/Bochki/_Items.Bochki.Bochka")]
    internal class Bochka : MonoBehaviour, IInteractable
    {
        private bochkiPuzzle bochkiPuzzle;
        public void Interact()
        {
            if (!bochkiPuzzle.carryingBochka)
            {
                Destroy(gameObject);
                bochkiPuzzle.carryingBochka = true;
            }

        }

        public void SetPuzzle(bochkiPuzzle puzzle)
        {
            bochkiPuzzle = puzzle;
        }
    }
}
