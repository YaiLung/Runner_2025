using UnityEngine;
using UnityEngine.UI;

namespace Victory
{
    /// <summary>
    /// Victory when trigger bc
    /// </summary>
    public class VictoryTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _victoryUI; // UI element for victory screen
        [SerializeField] private AudioClip _victorySound; // Victory sound clip
        [SerializeField] private float _soundVolume = 1.0f; // Volume of the victory sound

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _victoryUI.SetActive(true); // Show the victory UI
                AudioSource.PlayClipAtPoint(_victorySound, Camera.main.transform.position, _soundVolume); // Play the victory sound
                Time.timeScale = 0f; // Pause the game
                Debug.Log("win!");
            }
        }
    }
}

