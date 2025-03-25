using UnityEngine;

public class TurnPoint : MonoBehaviour
{
    [SerializeField] private float turnAngle = 90f; // Угол поворота

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что вошел игрок
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetTurn(turnAngle);
            }
        }
    }
}
