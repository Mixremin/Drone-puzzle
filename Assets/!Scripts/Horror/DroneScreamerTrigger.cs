using Player;
using UnityEngine;

namespace _Horror
{
    [AddComponentMenu("Scripts/_Horror/_Horror.DroneScreamerTrigger")]
    internal class DroneScreamerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonMovement player))
            {
                player.GetComponent<SwitchToDrone>().needToShowScreamer = true;
            }
        }
    }
}
