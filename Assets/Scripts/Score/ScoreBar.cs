using UnityEngine;

namespace Score

{   
    /// <summary>
    /// score UI
    /// </summary>
    public class ScoreBar : MonoBehaviour
    {
        [SerializeField] private Transform _player; // The player
        [SerializeField] private Vector3 _offset = new Vector3(0, 2, 0); // The offset above the player

        // Update the position and rotation of the score bar each frame
        private void LateUpdate()
        {
            if (_player)
            {
                // Set the position of the score bar to be above the player with the specified offset
                transform.position = _player.position + _offset;

                // Ensure the score bar always faces the camera
                transform.LookAt(Camera.main.transform);
            }
        }
    }
}
