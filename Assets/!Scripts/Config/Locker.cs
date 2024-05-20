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

        [SerializeField]
        private bool cameraLocked = false;
        public bool CameraLocked => cameraLocked;

        [Button]
        public void InDroneLock()
        {
            movementLocked = true;
            interactionLocked = true;
            shootingLocked = false;
            cameraLocked = false;
        }

        public void LockMovement()
        {
            movementLocked = true;
        }
        public void LockInteraction()
        {
            interactionLocked = true;
        }
        public void LockShooting()
        {
            shootingLocked = true;
        }
        [Button]
        public void InFPSLock()
        {
            movementLocked = false;
            interactionLocked = false;
            shootingLocked = true;
            cameraLocked = false;
        }

        public void LockAll()
        {
            movementLocked = true;
            interactionLocked = true;
            shootingLocked = true;
            cameraLocked = true;
        }
    }

}
