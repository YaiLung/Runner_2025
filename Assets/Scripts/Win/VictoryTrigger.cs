using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Victory
{
    public class VictoryTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _victoryUI; // Victory screen
        [SerializeField] private AudioClip _victorySound; // Sound
        [SerializeField] private float _soundVolume = 1.0f; // Volume
        [SerializeField] private string _nextLevelName = "Level2"; // Имя следующей сцены
        [SerializeField] private Button _nextLevelButton; // Кнопка перехода на следующий уровень

        private void Start()
        {
            if (_nextLevelButton != null)
            {
                _nextLevelButton.onClick.AddListener(LoadNextLevel); // Привязываем кнопку к методу
            }
        }

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

        public void LoadNextLevel()
        {
            Time.timeScale = 1f; // Возвращаем время в норму
            SceneManager.LoadScene(_nextLevelName); // Загружаем новую сцену
        }
    }
}

