using Core.State;
using Core.Game.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.UI
{
    public class SettingsWindow : Window
    {
        [SerializeField] private Button closeButton = null;

        protected override void OnClose() { }

        protected override void OnShow()
        {
            closeButton.onClick.AddListener(OnCloseClick);
        }

        private void OnCloseClick()
        {
            gameObject.SetActive(false);
        }

    }
}