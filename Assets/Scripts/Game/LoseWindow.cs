using Core.State;
using Core.Game.UI;
using UnityEngine;
using TMPro;
using System;
using Core.Game;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseWindow : Window
{
    [SerializeField] private Button restartButton = null;
    [SerializeField] private Button menuButton = null;
    [SerializeField] private Button settingsButton = null;
    [SerializeField] private TMP_Text bestScoreText = null;
    [SerializeField] private TMP_Text curScoreText = null;

    protected override void OnClose() { }

    protected override void OnShow()
    {
        menuButton.onClick.AddListener(OnMenuClick);
        restartButton.onClick.AddListener(OnRestartClick);
        settingsButton.onClick.AddListener(OnSettingsClick);
        var scoreController = GameObject.FindObjectOfType<ScoreController>();
        bestScoreText.text = $"BEST SCORE: {scoreController.MaxScore}";
        curScoreText.text = $"SCORE: {scoreController.CurScore}";
    }

    private void OnRestartClick()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnMenuClick()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LevelStarter.Instance.SwitchPanels(true);
    }

    private void OnSettingsClick()
    {
        GameObject.FindObjectOfType<SettingsWindow>(true).Show();
    }
}
