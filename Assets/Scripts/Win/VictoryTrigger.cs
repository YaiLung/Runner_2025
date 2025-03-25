using UnityEngine;
using UnityEngine.UI;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] private GameObject victoryUI; // UI победы
    [SerializeField] private AudioClip victorySound; // Аудио победы
    [SerializeField] private float soundVolume = 1.0f; // Громкость звука

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryUI.SetActive(true); // Показать UI
            AudioSource.PlayClipAtPoint(victorySound, Camera.main.transform.position, soundVolume); // Проиграть звук победы
            Time.timeScale = 0f; // Остановить время (игру)
            Debug.Log("🏆 Победа!");
        }
    }
}

