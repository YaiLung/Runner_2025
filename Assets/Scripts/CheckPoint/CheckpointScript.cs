using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; // ���� ���������
    [SerializeField] private Animator playerAnimator; // �������� ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ����� �� ���
        {
            SaveGame(other.transform);
        }
    }

    private void SaveGame(Transform playerTransform)
    {
        // ��������� ������� � ����
        PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
        PlayerPrefs.SetInt("PlayerScore", ScoreManager.Instance.GetScore());

        // ������������� ��������
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Checkpoint");
        }

        // ����������� ����
        if (checkpointSound != null)
        {
            AudioSource.PlayClipAtPoint(checkpointSound, playerTransform.position);
        }

        // ������� ��������� � �������
        Debug.Log("���� ���������!");
    }
}
