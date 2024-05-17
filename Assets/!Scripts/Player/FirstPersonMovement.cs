using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    internal class FirstPersonMovement : MonoBehaviour
    {
        public float speed = 5;

        [Header("Running")]
        public bool canRun = true;
        public bool IsRunning { get; private set; }
        public float runSpeed = 9;
        public KeyCode runningKey = KeyCode.LeftShift;
        private new Rigidbody rigidbody;
        /// <summary> Functions to override movement speed. Will use the last added override. </summary>
        public List<System.Func<float>> speedOverrides = new();

        private void Awake()
        {
            // Get the rigidbody on this.
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // Update IsRunning from input.
            IsRunning = canRun && Input.GetKey(runningKey);

            // Get targetMovingSpeed.
            float targetMovingSpeed = IsRunning ? runSpeed : speed;
            if (speedOverrides.Count > 0)
            {
                targetMovingSpeed = speedOverrides[^1]();
            }

            // Get targetVelocity from input.
            Vector2 targetVelocity = new(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

            // Apply movement.
            rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        }
    }
}