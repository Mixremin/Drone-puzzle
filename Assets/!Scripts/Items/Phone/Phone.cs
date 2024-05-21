using _Config;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Items.Phone
{
    [AddComponentMenu("Scripts/_Items/_Items.Phone.Phone")]
    internal class Phone : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private GameObject phonePrefab;

        private GameObject phoneObject;

        [Button]
        public void FindCanvas()
        {
            canvas = FindObjectOfType<Canvas>();
        }


        public void Interact()
        {
            SimpleInventory.instance.phoneUsed = true;

            phoneObject = Instantiate(phonePrefab, canvas.transform);
        }

    }
}
