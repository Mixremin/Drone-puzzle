using _Config;
using Config;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Common
{
    [AddComponentMenu("Scripts/_Common/_Common.ResetLock")]
    internal class ResetLock : MonoBehaviour
    {
        [SerializeField]
        private int roomNum = 0;

        [SerializeField]
        private int cityNum = 1;

        private Scene currentScene;
        private void Awake()
        {
            currentScene = SceneManager.GetActiveScene();
            Locker.instance.InFPSLock();
            RoomSetup();
            CitySetup();
            CitySecondHalfSetup();
        }
        public void RoomSetup()
        {
            if (currentScene.buildIndex == roomNum)
            {
                SimpleInventory.instance.hasDrone = false;
                SimpleInventory.instance.phoneUsed = false;
                SimpleInventory.instance.talkedToInformant = false;
                SimpleInventory.instance.canStartJapanGame = false;
                SimpleInventory.instance.japanGamePassed = false;
            }
        }

        public void CitySetup()
        {
            if (!SimpleInventory.instance.japanGamePassed && currentScene.buildIndex == cityNum)
            {
                SimpleInventory.instance.hasDrone = true;
                SimpleInventory.instance.phoneUsed = true;
                SimpleInventory.instance.talkedToInformant = false;
                SimpleInventory.instance.canStartJapanGame = false;
                SimpleInventory.instance.japanGamePassed = false;
            }
        }

        public void CitySecondHalfSetup()
        {
            if (SimpleInventory.instance.japanGamePassed && currentScene.buildIndex == cityNum)
            {
                SimpleInventory.instance.hasDrone = true;
                SimpleInventory.instance.phoneUsed = true;
                SimpleInventory.instance.talkedToInformant = true;
                SimpleInventory.instance.canStartJapanGame = true;
                SimpleInventory.instance.japanGamePassed = true;
            }
        }
    }
}


