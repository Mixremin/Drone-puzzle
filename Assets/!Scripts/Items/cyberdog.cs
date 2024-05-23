using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.cyberdog")]
    internal class cyberdog : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Application.Quit();
        }
    }
}
