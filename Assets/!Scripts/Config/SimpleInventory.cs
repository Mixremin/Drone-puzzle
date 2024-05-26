using System;
using UnityEngine;

namespace _Config
{
    [CreateAssetMenu(fileName = "SimpleInventory", menuName = "Config/Create SimpleInventory")]
    internal class SimpleInventory : SingletonScriptableObject<SimpleInventory>
    {

        [SerializeField]
        private bool _hasDrone = false;

        public bool hasDrone
        {
            get => _hasDrone;
            set
            {
                _hasDrone = value;
                questChanged?.Invoke();
            }
        }

        [SerializeField]
        private bool _phoneUsed = false;

        public bool phoneUsed
        {
            get => _phoneUsed;
            set
            {
                _phoneUsed = value;
                questChanged?.Invoke();
            }
        }

        [SerializeField]
        private bool _talkedToInformant = false;

        public bool talkedToInformant
        {
            get => _talkedToInformant;
            set
            {
                _talkedToInformant = value;
                quest = 1;
                questChanged?.Invoke();
            }
        }

        [SerializeField]
        private bool _canStartJapanGame = false;

        public bool canStartJapanGame
        {
            get => _canStartJapanGame;
            set
            {
                _canStartJapanGame = value;
                quest = 2;
                questChanged?.Invoke();
            }
        }

        [SerializeField]
        private bool _japanGamePassed = false;

        public bool japanGamePassed
        {
            get => _japanGamePassed;
            set
            {
                _japanGamePassed = value;
                quest = 3;
                questChanged?.Invoke();
            }
        }

        [SerializeField]
        private bool _hackerQuestPassed = false;

        public bool hackerQuestPassed
        {
            get => _hackerQuestPassed;
            set
            {
                _hackerQuestPassed = value;
                quest = 4;
                questChanged?.Invoke();
            }
        }

        [SerializeField]
        private bool _toOfficeCardObtained = false;

        public bool toOfficeCardObtained
        {
            get => _toOfficeCardObtained;
            set
            {
                _toOfficeCardObtained = value;
                quest = 5;
                questChanged?.Invoke();
            }
        }

        [SerializeField]
        private bool _runnerPazzlePassed = false;

        public bool runnerPazzlePassed
        {
            get => _runnerPazzlePassed;
            set
            {
                _runnerPazzlePassed = value;
                quest = 7;
                questChanged?.Invoke();
            }
        }

        public Action questChanged;
        private int quest = 0;

        public int GetQuest()
        {
            return quest;
        }

    }
}
