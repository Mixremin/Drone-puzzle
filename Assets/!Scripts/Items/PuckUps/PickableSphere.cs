using UnityEngine;

namespace _Items.PuckUps
{
    [AddComponentMenu("Scripts/_Items/PuckUps/_Items.PuckUps.PickableSphere")]
    internal class PickableSphere : MonoBehaviour, IPickable
    {
        private bool canBePicked = true;
        public GameObject PickUp()
        {
            if (true)
            {
                return gameObject;
            }
            else
            {
                return null;
            }
        }
    }
}
