using System;
using UnityEditor;
using UnityEngine;

namespace _Config
{
    [CreateAssetMenu(fileName = "SimpleInventory", menuName = "Config/Create SimpleInventory")]
    internal class SimpleInventory : ScriptableSingleton<SimpleInventory>
    {
        [SerializeField]
        public bool hasDrone = false;

        [SerializeField]
        public bool phoneUsed = false;

        [SerializeField]
        public bool japanGamePassed = false;

        [SerializeField]
        public bool runnerPazzlePassed = false;
    }
}
