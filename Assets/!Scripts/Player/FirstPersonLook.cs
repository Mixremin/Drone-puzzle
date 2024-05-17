﻿using UnityEngine;
namespace Player
{
    internal class FirstPersonLook : MonoBehaviour
    {
        [SerializeField]
        private Transform character;
        public float sensitivity = 2;
        public float smoothing = 1.5f;

        [HideInInspector]
        public Vector2 velocity;
        public Vector2 frameVelocity;

        private void Reset()
        {
            // Get the character from the FirstPersonMovement in parents.
            character = GetComponentInParent<FirstPersonMovement>().transform;
        }

        private void Start()
        {
            // Lock the mouse cursor to the game screen.
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            // Get smooth velocity.
            Vector2 mouseDelta = new(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);

            // Rotate camera up-down and controller left-right from velocity.
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }
    }
}
