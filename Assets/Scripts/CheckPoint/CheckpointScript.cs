using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; // Звук чекпоинта
    [SerializeField] private Animator playerAnimator; // Анимация игрока

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, игрок ли это
        {
            SaveGame(other.transform);
        }
    }

    private void SaveGame(Transform playerTransform)
    {
        // Сохраняем позицию и очки
        PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
        PlayerPrefs.SetInt("PlayerScore", ScoreManager.Instance.GetScore());

        // Воспроизводим анимацию
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Checkpoint");
        }

        // Проигрываем звук
        if (checkpointSound != null)
        {
            AudioSource.PlayClipAtPoint(checkpointSound, playerTransform.position);
        }

        // Выводим сообщение в консоль
        Debug.Log("Игра Сохранена!");
    }
}
