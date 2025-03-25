using UnityEngine;
using Score;

namespace SaveCheckpoint
{

    /// <summary>
    /// checkpoint manager
    /// </summary>
    public class CheckpointScript : MonoBehaviour
    {
        [SerializeField] private AudioClip _checkpointSound; // Checkpoint sound effect
        [SerializeField] private Animator _playerAnimator; // Player animator

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) // Check if the player enters the checkpoint
            {
                SaveGame(other.transform);
            }
        }

        private void SaveGame(Transform playerTransform)
        {
            // Save player position and score
            PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
            PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
            PlayerPrefs.SetInt("PlayerScore", ScoreManager.Instance.GetScore());

            // Play checkpoint animation
            if (_playerAnimator != null)
            {
                _playerAnimator.SetTrigger("Checkpoint");
            }

            // Play checkpoint sound
            if (_checkpointSound != null)
            {
                AudioSource.PlayClipAtPoint(_checkpointSound, playerTransform.position);
            }

            // Print message in console
            Debug.Log("Game Saved!");
        }
    }
}
