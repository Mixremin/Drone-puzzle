using UnityEngine;

namespace _Config
{
    [CreateAssetMenu(fileName = "SimpleInventory", menuName = "Config/Create SimpleInventory")]
    internal class SimpleInventory : SingletonScriptableObject<SimpleInventory>
    {

        [SerializeField]
        public bool hasDrone = false;

        [SerializeField]
        public bool phoneUsed = false;

        [SerializeField]
        public bool talkedToInformant = false;

        [SerializeField]
        public bool canStartJapanGame = false;

        [SerializeField]
        public bool japanGamePassed = false;

        [SerializeField]
        public bool hackerQuestPassed = true;

        [SerializeField]
        public bool toOfficeCardObtained = false;

        [SerializeField]
        public bool runnerPazzlePassed = false;



    }
}
