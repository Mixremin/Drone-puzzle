using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Player
{
    [AddComponentMenu("Scripts/_Player/_Player.PlayerStats")]
    internal class PlayerStats : MonoBehaviour
    {
        [SerializeField]
        private float maxHealth = 100f;

        [SerializeField]
        private float currentHealth;

        [SerializeField]
        private Slider healthSlider;
        [SerializeField]
        private TextMeshProUGUI healthText;

        public Action damaged;

        private void Start()
        {
            currentHealth = maxHealth;
            healthSlider.value = currentHealth / maxHealth;
            healthText.text = (currentHealth / maxHealth * 100) + "%";
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            healthSlider.value = currentHealth / maxHealth;
            healthText.text = (currentHealth / maxHealth * 100) + "%";
            damaged.Invoke();


            if (currentHealth <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
