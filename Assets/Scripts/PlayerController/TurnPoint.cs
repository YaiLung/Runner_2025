using UnityEngine;

public class TurnPoint : MonoBehaviour
{
    [SerializeField] private float turnAngle = 90f; // ���� ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ��� ����� �����
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetTurn(turnAngle);
            }
        }
    }
}
