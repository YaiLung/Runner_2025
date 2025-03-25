using UnityEngine;

namespace Player
{
    /// <summary>
    /// turn poin when trigger bc
    /// </summary>
    public class TurnPoint : MonoBehaviour
    {
        [SerializeField] private float _turnAngle = 90f; // Rotation angle

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) // Check if the player entered the trigger
            {
                PlayerController player = other.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.SetTurn(_turnAngle); // Apply the turn
                }
            }
        }
    }
}
