using System;
using UnityEngine;

namespace PostProcessing.ASCII.Utils
{
    public class Rotator: MonoBehaviour 
    {
        public Vector3 RotationSpeed;

        public void FixedUpdate()
        {
            transform.Rotate(RotationSpeed);
        }
    }
}