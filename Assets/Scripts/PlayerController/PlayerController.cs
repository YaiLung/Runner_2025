using UnityEngine;

namespace Player
{    

    /// <summary>
    /// player manager
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _forwardSpeed = 5f;  // Forward movement speed
        [SerializeField] private float _sideSpeed = 3f;     // Side movement speed (left/right)
        [SerializeField] private float _rotationSpeed = 5f; // Rotation speed

        private Quaternion _targetRotation; // Target player rotation

        private void Start()
        {
            _targetRotation = transform.rotation; // Set initial rotation
        }

        private void Update()
        {
            MoveForward();
            HandleInput();
            SmoothRotate();
        }

        private void MoveForward()
        {
            transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime, Space.Self); // Move forward relative to player rotation
        }

        private void HandleInput()
        {
            float horizontalInput = Input.GetAxis("Horizontal"); // A = -1, D = 1
            Vector3 sideMove = transform.right * horizontalInput * _sideSpeed * Time.deltaTime; // Move left/right based on player rotation
            transform.Translate(sideMove, Space.World);
        }

        private void SmoothRotate()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        }

        public void SetTurn(float angle)
        {
            _targetRotation *= Quaternion.Euler(0, angle, 0); // Apply rotation relative to the current rotation
        }
    }
}
