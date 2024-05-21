using Config;
using UnityEngine;
using UnityEngine.UI;

namespace _Items.Phone
{
    [AddComponentMenu("Scripts/_Items/Phone/_Items.Phone.PhoneUI")]
    internal class PhoneUI : MonoBehaviour
    {
        [SerializeField]
        private Button closeButton;


        private void Awake()
        {
            Debug.Log("Awakened");
            ShowCursor();

            Locker.instance.LockAll();
            Time.timeScale = 0;

            closeButton.onClick.AddListener(Close);

        }

        private void Close()
        {
            Locker.instance.InFPSLock();
            HideCursor();
            Time.timeScale = 1.0f;
            Destroy(gameObject);
        }

        private void ShowCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
