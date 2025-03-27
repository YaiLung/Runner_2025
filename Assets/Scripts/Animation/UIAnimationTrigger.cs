using UnityEngine;

namespace Game
{
    public class UIAnimationTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _uiElement; // UI ������� (������ ���� Canvas ��� Image)
        [SerializeField] private Animator _uiAnimator; // �������� UI
        [SerializeField] private string _triggerName = "Animation"; // ��� �������� ��������

        private void Start()
        {
            if (_uiElement != null)
            {
                _uiElement.SetActive(false); // UI ����� ��� ������
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _uiElement != null && _uiAnimator != null)
            {
                _uiElement.SetActive(true); // �������� UI
                _uiAnimator.SetTrigger(_triggerName); // ��������� ��������
            }
        }
    }
}
