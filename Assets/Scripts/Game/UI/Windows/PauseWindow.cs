using Core.State;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Game.UI
{
    public class PauseWindow : Window
    {
        [SerializeField] private Button exitButton = null;
        [SerializeField] private Button settingsButton = null;
        [SerializeField] private Button restartButton = null;

        protected override void OnShow()
        {
            exitButton.onClick.AddListener(OnExitClick);
            settingsButton.onClick.AddListener(OpenSettings);
            restartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OpenSettings()
        {
            GameObject.FindObjectOfType<SettingsWindow>(true).Show();
        }

        private void OnExitClick()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        protected override void OnClose() { }
    }
}