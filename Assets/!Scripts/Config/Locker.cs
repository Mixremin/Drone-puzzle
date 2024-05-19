using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "Locker", menuName = "Config/Create Locker Settings")]
    internal class Locker : ScriptableSingleton<Locker>
    {
        [SerializeField]
        private bool movementLocked = false;
        public bool MovementLocked => movementLocked;

        [SerializeField]
        private bool interactionLocked = false;
        public bool InteractionLocked => interactionLocked;
        [SerializeField]
        private bool shootingLocked = false;
        public bool ShootingLocked => shootingLocked;

        [Button]
        public void LockAll()
        {
            movementLocked = true;
            interactionLocked = true;
            shootingLocked = true;
        }
        [Button]
        public void LockMovement()
        {
            movementLocked = true;
        }
        [Button]
        public void LockInteraction()
        {
            interactionLocked = true;
        }
        [Button]
        public void LockShooting()
        {
            shootingLocked = true;
        }
        [Button]
        public void UnlockAll()
        {
            movementLocked = false;
            interactionLocked = false;
            shootingLocked = false;
        }
    }
}
