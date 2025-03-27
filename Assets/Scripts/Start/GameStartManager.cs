using UnityEngine;
using UnityEngine.UI;

namespace GameManagement
{
    /// <summary>
    /// Manages the game start process.
    /// </summary>
    public class GameStartManager : MonoBehaviour
    {
        [SerializeField] private GameObject _startUI; // UI for game start
        [SerializeField] private GameObject _runUI; // UI that appears when the game starts
        [SerializeField] private GameObject _scoreSlider; // Score slider UI
        [SerializeField] private GameObject _scoreText; // Score text UI

        private bool _gameStarted = false;

        private void Start()
        {
            Time.timeScale = 0f; // Pause the game at the start
            _startUI.SetActive(true); // Show start UI
            _runUI.SetActive(false); // Hide game UI
            _scoreSlider.SetActive(false);
            _scoreText.SetActive(false);
        }

        private void Update()
        {
            if (!_gameStarted && Input.anyKeyDown)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            _gameStarted = true;
            _startUI.SetActive(false); // Hide start UI
            _runUI.SetActive(true); // Show game UI
            _scoreSlider.SetActive(true);
            _scoreText.SetActive(true);
            Time.timeScale = 1f; // Resume game
        }
    }
}
