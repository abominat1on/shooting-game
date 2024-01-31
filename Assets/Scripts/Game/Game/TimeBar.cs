using System.Collections;
using System.Collections.Generic;
using Core.State;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private Image fillImage = null;

    private void Awake()
    {
        LevelController.StartWaveAction += OnStartLevel;
    }

    private void OnStartLevel()
    {
        LevelController.Instance.ActiveTimer.TimeTick += OnTimerTick;
        fillImage.fillAmount = 1.0f;
    }

    private void OnTimerTick(float obj)
    {
        fillImage.fillAmount = obj / LevelController.Instance.maxTime;
    }

    private void OnDestroy()
    {
        LevelController.StartWaveAction -= OnStartLevel;
    }
}
