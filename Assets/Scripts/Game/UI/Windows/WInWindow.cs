using Core.State;
using Core.Game.UI;
using UnityEngine;
using TMPro;
using System;
using Core.Game;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WInWindow : Window
{
    [SerializeField] private Button nextLevelButton = null;
    [SerializeField] private Button closeButton = null;
    [SerializeField] private Button settingsButton = null;
    [SerializeField] private TMP_Text bestScoreText = null;
    [SerializeField] private TMP_Text curScoreText = null;

    protected override void OnClose() { }

    protected override void OnShow()
    {
        closeButton.onClick.AddListener(OnCloseClick);
        nextLevelButton.onClick.AddListener(OnNextLevelClick);
        settingsButton.onClick.AddListener(OnSettingsClick);

        var scoreController = GameObject.FindObjectOfType<ScoreController>();
        bestScoreText.text = $"BEST SCORE: {scoreController.MaxScore}";
        curScoreText.text = $"SCORE: {scoreController.CurScore}";
    }

    private void OnNextLevelClick()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCloseClick()
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
