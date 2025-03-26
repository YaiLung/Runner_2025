using UnityEngine;
using UnityEngine.UI;
using Score;

namespace Defeat
{
    /// <summary>
    /// Triggers defeat when the player's score reaches zero.
    /// </summary>
    public class DefeatManager : MonoBehaviour
    {
        [SerializeField] private GameObject _defeatUI; // UI element for defeat screen
        [SerializeField] private AudioClip _defeatSound; // Defeat sound clip
        [SerializeField] private float _soundVolume = 1.0f; // Volume of the defeat sound

        private void Start()
        {
            ScoreManager.Instance.OnScoreChanged += CheckDefeatCondition;
        }

        private void OnDestroy()
        {
            ScoreManager.Instance.OnScoreChanged -= CheckDefeatCondition;
        }

        private void CheckDefeatCondition(int currentScore)
        {
            if (currentScore <= 0)
            {
                TriggerDefeat();
            }
        }

        private void TriggerDefeat()
        {
            _defeatUI.SetActive(true); // Show the defeat UI
            AudioSource.PlayClipAtPoint(_defeatSound, Camera.main.transform.position, _soundVolume); // Play the defeat sound
            Time.timeScale = 0f; // Pause the game
            Debug.Log("Game Over!");
        }
    }
}
