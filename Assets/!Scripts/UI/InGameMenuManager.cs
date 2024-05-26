using UnityEngine;
using UnityEngine.SceneManagement;

namespace _UI
{
    [AddComponentMenu("Scripts/_UI/_UI.InGameMenuManager")]
    internal class InGameMenuManager : MonoBehaviour
    {
        public void ShowCursor()
        {
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void HideCursor()
        {
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void ReloadLevel()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
