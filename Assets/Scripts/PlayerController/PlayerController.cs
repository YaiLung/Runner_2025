using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;  // Скорость движения вперед
    [SerializeField] private float sideSpeed = 3f;     // Скорость движения влево/вправо
    [SerializeField] private float rotationSpeed = 5f; // Скорость поворота

    private Quaternion targetRotation; // Целевой поворот игрока

    private void Start()
    {
        targetRotation = transform.rotation; // Начальный поворот
    }

    private void Update()
    {
        MoveForward();
        HandleInput();
        SmoothRotate();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.Self); // Теперь движение вперед всегда относительно игрока
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A = -1, D = 1
        Vector3 sideMove = transform.right * horizontalInput * sideSpeed * Time.deltaTime; // Теперь движение влево/вправо учитывает поворот
        transform.Translate(sideMove, Space.World);
    }

    private void SmoothRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void SetTurn(float angle)
    {
        targetRotation *= Quaternion.Euler(0, angle, 0); // Добавляем поворот относительно текущего положения
    }
}
