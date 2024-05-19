﻿using Config;
using UnityEngine;

namespace Player
{
    internal class Jump : MonoBehaviour
    {
        private new Rigidbody rigidbody;
        public float jumpStrength = 2;
        public event System.Action Jumped;

        [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
        private GroundCheck groundCheck;

        private void Reset()
        {
            // Try to get groundCheck.
            groundCheck = GetComponentInChildren<GroundCheck>();
        }

        private void Awake()
        {
            // Get rigidbody.
            rigidbody = GetComponent<Rigidbody>();
        }

        private void LateUpdate()
        {
            if (!Locker.instance.MovementLocked)
            {
                // Jump when the Jump button is pressed and we are on the ground.
                if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
                {
                    rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
                    Jumped?.Invoke();
                }
            }
        }
    }
}
