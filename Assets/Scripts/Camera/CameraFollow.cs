using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;  // Цель (игрок)
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7); // Смещение камеры
    [SerializeField] private float followSpeed = 5f;  // Скорость следования
    [SerializeField] private float rotationSpeed = 5f; // Скорость поворота камеры

    private Quaternion targetRotation; // Целевой поворот камеры

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollow: Не назначен target (игрок)!");
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
        // Определяем новую позицию с учетом смещения и поворота игрока
        Vector3 targetPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    private void SmoothRotate()
    {
        // Камера должна смотреть на игрока с плавным поворотом
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
