﻿using UnityEngine;

namespace Player
{
    [ExecuteInEditMode]
    internal class Zoom : MonoBehaviour
    {
        private new Camera camera;
        public float defaultFOV = 60;
        public float maxZoomFOV = 15;
        [Range(0, 1)]
        public float currentZoom;
        public float sensitivity = 1;

        private void Awake()
        {
            // Get the camera on this gameObject and the defaultZoom.
            camera = GetComponent<Camera>();
            if (camera)
            {
                defaultFOV = camera.fieldOfView;
            }
        }

        private void Update()
        {
            // Update the currentZoom and the camera's fieldOfView.
            currentZoom += Input.mouseScrollDelta.y * sensitivity * .05f;
            currentZoom = Mathf.Clamp01(currentZoom);
            camera.fieldOfView = Mathf.Lerp(defaultFOV, maxZoomFOV, currentZoom);
        }
    }
}
