using UnityEngine;
using UnityEngine.UI;

namespace Victory
{
    public class VictoryTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _victoryUI; // Victory screen
        [SerializeField] private AudioClip _victorySound; // Sound
        [SerializeField] private float _soundVolume = 1.0f; // Volume

        public void TriggerVictory()
        {
            _victoryUI.SetActive(true); // Show UI
            AudioSource.PlayClipAtPoint(_victorySound, Camera.main.transform.position, _soundVolume);
            Time.timeScale = 0f; // Pause game
            Debug.Log("Victory!");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                TriggerVictory();
            }
        }
    }
}
