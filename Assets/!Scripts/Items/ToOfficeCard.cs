using _Config;
using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.ToOfficeCard")]
    internal class ToOfficeCard : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            SimpleInventory.instance.toOfficeCardObtained = true;
            Destroy(gameObject);
        }

    }
}
