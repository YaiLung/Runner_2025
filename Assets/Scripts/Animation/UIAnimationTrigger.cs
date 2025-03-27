using UnityEngine;

namespace Game
{
    public class UIAnimationTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _uiElement; // UI элемент (должен быть Canvas или Image)
        [SerializeField] private Animator _uiAnimator; // Аниматор UI
        [SerializeField] private string _triggerName = "Animation"; // Имя триггера анимации

        private void Start()
        {
            if (_uiElement != null)
            {
                _uiElement.SetActive(false); // UI скрыт при старте
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _uiElement != null && _uiAnimator != null)
            {
                _uiElement.SetActive(true); // Показать UI
                _uiAnimator.SetTrigger(_triggerName); // Запустить анимацию
            }
        }
    }
}
