using UnityEngine;
using Score; 

namespace Score
{
    /// <summary>
    /// score manager for items for score
    /// </summary>
    public class ScoreItem : MonoBehaviour
    {
        [SerializeField] private int _scoreValue = 10; // The amount of points added or subtracted
        [SerializeField] private bool _isPositive = true; // true - adds points, false - subtracts points

        // When the player collides with the score item
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) // Check if the object is the player
            {
                // Add or subtract points based on _isPositive flag
                ScoreManager.Instance.AddScore(_isPositive ? _scoreValue : -_scoreValue);
                Destroy(gameObject); // Destroy the score item after it is collected
            }
        }
    }
}
