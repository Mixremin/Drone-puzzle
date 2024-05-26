using UnityEngine;
using UnityEngine.SceneManagement;

namespace _UI
{
    [AddComponentMenu("Scripts/_UI/_UI.MainMenuManager")]
    internal class MainMenuManager : MonoBehaviour
    {
        [Header("Windows")]
        [SerializeField]
        private GameObject mainMenu;
        [SerializeField]
        private GameObject settings;
        [SerializeField]
        private GameObject soundsSettings;
        [SerializeField]
        private GameObject controlSettings;

        private void Start()
        {
            OpenMainMenu();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void OpenMainMenu()
        {
            mainMenu.SetActive(true);
            settings.SetActive(false);
        }

        public void OpenSoundSettings()
        {
            mainMenu.SetActive(false);
            settings.SetActive(true);
            soundsSettings.SetActive(true);
            controlSettings.SetActive(false);
        }

        public void OpenControlSettings()
        {
            mainMenu.SetActive(false);
            settings.SetActive(true);
            soundsSettings.SetActive(false);
            controlSettings.SetActive(true);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
