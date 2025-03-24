using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;  // ���� (�����)
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7); // �������� ������
    [SerializeField] private float followSpeed = 5f;  // �������� ����������
    [SerializeField] private float rotationSpeed = 5f; // �������� �������� ������

    private Quaternion targetRotation; // ������� ������� ������

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollow: �� �������� target (�����)!");
            enabled = false;
        }
    }

    private void LateUpdate()
    {
        FollowTarget();
        SmoothRotate();
    }

    private void FollowTarget()
    {
        // ���������� ����� ������� � ������ �������� � �������� ������
        Vector3 targetPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    private void SmoothRotate()
    {
        // ������ ������ �������� �� ������ � ������� ���������
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
