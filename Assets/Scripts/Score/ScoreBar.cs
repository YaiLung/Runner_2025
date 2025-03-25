using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private Transform player; // Игрок
    [SerializeField] private Vector3 offset = new Vector3(0, 2, 0); // Смещение над игроком

    private void LateUpdate()
    {
        if (player)
        {
            transform.position = player.position + offset;
            transform.LookAt(Camera.main.transform); // Полоска всегда повёрнута к камере
        }
    }
}
