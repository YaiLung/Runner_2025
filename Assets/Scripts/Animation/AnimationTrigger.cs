using UnityEngine;

namespace Game
{
    public class AnimationTrigger : MonoBehaviour
    {
        [SerializeField] private Animator _animator; // Animator component
        [SerializeField] private string _triggerName = "Animation"; // Trigger name

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _animator != null)
            {
                _animator.SetTrigger(_triggerName); // Play animation
            }
        }
    }
}
