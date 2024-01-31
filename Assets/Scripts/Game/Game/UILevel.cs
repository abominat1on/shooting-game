using Core.State;
using TMPro;
using UnityEngine;

public class UILevel : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;

    private void Start()
    {
        var levelControler = GameObject.FindObjectOfType<LevelController>();
        levelText.text = levelControler.currentLevel.ToString();
    }

    private void Awake()
    {
        LevelController.LevelUp += OnLevelUp;
    }

    private void OnDestroy()
    {
        LevelController.LevelUp -= OnLevelUp;
    }

    private void OnLevelUp()
    {
        var levelControler = GameObject.FindObjectOfType<LevelController>();
        levelText.text = levelControler.currentLevel.ToString();
    }
}
