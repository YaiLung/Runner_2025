using UnityEngine;

namespace AudioSystem
{
    public class CollisionSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _collisionSound; // Sound to play on collision
        [SerializeField] private float _soundVolume = 1.0f; // Volume of the sound

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) // Check if player entered the collider
            {
                PlaySound();
            }
        }

        private void PlaySound()
        {
            if (_collisionSound != null)
            {
                AudioSource.PlayClipAtPoint(_collisionSound, transform.position, _soundVolume);
            }
        }
    }
}
