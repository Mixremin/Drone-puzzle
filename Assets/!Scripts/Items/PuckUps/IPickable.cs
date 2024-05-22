using UnityEngine;

namespace _Items.PuckUps
{
    [AddComponentMenu("Scripts/_Items/PuckUps/_Items.PuckUps.IPickable")]
    internal interface IPickable
    {
        public GameObject PickUp();
    }
}
