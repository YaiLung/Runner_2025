using UnityEngine;
using UnityEngine.UI;
using System;

namespace Score
{
    /// <summary>
    /// Manages the player's score.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        // Singleton instance of ScoreManager
        public static ScoreManager Instance { get; private set; }

        [SerializeField] private Text _scoreText; // UI text for displaying the score
        [SerializeField] private Slider _scoreSlider; // Progress bar for score
        [SerializeField] private Text _statusText; // UI text for displaying the player's wealth status
        [SerializeField] private int _maxScore = 100; // Maximum score value

        private int _currentScore; // Current score value

        public event Action<int> OnScoreChanged; // Event triggered when the score changes

        private void Awake()
        {
            // Singleton pattern to ensure only one instance of ScoreManager exists
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            _currentScore = _maxScore / 2; // Initialize score to half of max score
            UpdateUI();
        }

        // Method to add score
        public void AddScore(int amount)
        {
            _currentScore = Mathf.Clamp(_currentScore + amount, 0, _maxScore); // Clamp score within valid range
            UpdateUI();
            OnScoreChanged?.Invoke(_currentScore); // Trigger the score change event
        }

        // Method to update the UI elements for score
        private void UpdateUI()
        {
            if (_scoreText) _scoreText.text = $"Score: {_currentScore}"; // Update score text
            if (_scoreSlider) _scoreSlider.value = (float)_currentScore / _maxScore; // Update score slider value
            UpdateStatusText(); // Update status text
        }

        // Method to update the player's wealth status based on the score
        private void UpdateStatusText()
        {
            if (_statusText)
            {
                if (_currentScore <= 49) _statusText.text = "Бедный";
                else if (_currentScore <= 99) _statusText.text = "Состоятельный";
                else _statusText.text = "Миллионер";
            }
        }

        // Method to get the current score
        public int GetScore() => _currentScore;
    }
}
