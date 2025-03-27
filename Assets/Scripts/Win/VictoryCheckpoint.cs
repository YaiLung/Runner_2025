using UnityEngine;
using Score;

namespace Victory
{
    public class VictoryCheckpoint : MonoBehaviour
    {
        [SerializeField] private int _requiredScore = 50; // Required score to pass
        [SerializeField] private GameObject _door; // Door to open
        [SerializeField] private Animator _doorAnimator; // Door animation
        [SerializeField] private string _doorOpenTrigger = "Open"; // Animation trigger name

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                int playerScore = ScoreManager.Instance.GetScore(); // Get player's score

                if (playerScore >= _requiredScore)
                {
                    OpenDoor();
                }
                else
                {
                    FindObjectOfType<VictoryTrigger>().TriggerVictory(); // End game
                }
            }
        }

        private void OpenDoor()
        {
            if (_doorAnimator != null)
            {
                _doorAnimator.SetTrigger(_doorOpenTrigger); // Play door animation
            }
            if (_door != null)
            {
                _door.SetActive(false); // Disable door collider (optional)
            }
        }
    }
}
