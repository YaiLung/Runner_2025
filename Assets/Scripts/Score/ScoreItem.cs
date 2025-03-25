using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10; // ������� ����� �����������/����������
    [SerializeField] private bool isPositive = true; // true - ���������, false - ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(isPositive ? scoreValue : -scoreValue);
            Destroy(gameObject);
        }
    }
}
