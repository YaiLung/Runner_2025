using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private Text scoreText; // UI-����� ��� ����������� �����
    [SerializeField] private Slider scoreSlider; // ������� ��������� �����
    [SerializeField] private int maxScore = 100; // ������������ ���������� �����

    private int currentScore;

    public event Action<int> OnScoreChanged; // ������� ��������� �����

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        currentScore = maxScore / 2; // ��������� ��������
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
