using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;  // �������� �������� ������
    [SerializeField] private float sideSpeed = 3f;     // �������� �������� �����/������
    [SerializeField] private float rotationSpeed = 5f; // �������� ��������

    private Quaternion targetRotation; // ������� ������� ������

    private void Start()
    {
        targetRotation = transform.rotation; // ��������� �������
    }

    private void Update()
    {
        MoveForward();
        HandleInput();
        SmoothRotate();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.Self); // ������ �������� ������ ������ ������������ ������
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A = -1, D = 1
        Vector3 sideMove = transform.right * horizontalInput * sideSpeed * Time.deltaTime; // ������ �������� �����/������ ��������� �������
        transform.Translate(sideMove, Space.World);
    }

    private void SmoothRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void SetTurn(float angle)
    {
        targetRotation *= Quaternion.Euler(0, angle, 0); // ��������� ������� ������������ �������� ���������
    }
}
