using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private Text scoreText; // UI-текст для отображения счета
    [SerializeField] private Slider scoreSlider; // Полоска прогресса очков
    [SerializeField] private int maxScore = 100; // Максимальное количество очков

    private int currentScore;

    public event Action<int> OnScoreChanged; // Событие изменения счета

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        currentScore = maxScore / 2; // Начальное значение
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        currentScore = Mathf.Clamp(currentScore + amount, 0, maxScore);
        UpdateUI();
        OnScoreChanged?.Invoke(currentScore);
    }

    private void UpdateUI()
    {
        if (scoreText) scoreText.text = $"Score: {currentScore}";
        if (scoreSlider) scoreSlider.value = (float)currentScore / maxScore;
    }

    public int GetScore() => currentScore;
}
