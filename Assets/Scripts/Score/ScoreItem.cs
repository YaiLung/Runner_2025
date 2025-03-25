using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10; // Сколько очков добавляется/отнимается
    [SerializeField] private bool isPositive = true; // true - добавляет, false - отнимает

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(isPositive ? scoreValue : -scoreValue);
            Destroy(gameObject);
        }
    }
}
