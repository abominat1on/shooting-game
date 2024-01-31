using Core.Game.UI;
using Core.State;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private Button startGameButton = null;
        [SerializeField] private GameObject startPanel = null;
        [SerializeField] private GameObject gamePlayPanel = null;
        public static LevelStarter Instance = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            GameObject.FindObjectOfType<CameraRaycaster>().enabled = false;
            startGameButton.onClick.AddListener(OnPlayClick);
            SwitchPanels(true);
        }

        private void OnPlayClick()
        {
            var levelController = GameObject.FindObjectOfType<LevelController>();
            levelController.StartLevel();
            SwitchPanels(false);
            GameObject.FindObjectOfType<CameraRaycaster>().enabled = true;
        }

        public void SwitchPanels(bool isStart)
        {
            startPanel.gameObject.SetActive(isStart);
            gamePlayPanel.gameObject.SetActive(!isStart);
        }
    }
}