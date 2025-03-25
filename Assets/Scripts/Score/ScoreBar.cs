using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private Transform player; // �����
    [SerializeField] private Vector3 offset = new Vector3(0, 2, 0); // �������� ��� �������

    private void LateUpdate()
    {
        if (player)
        {
            transform.position = player.position + offset;
            transform.LookAt(Camera.main.transform); // ������� ������ �������� � ������
        }
    }
}
