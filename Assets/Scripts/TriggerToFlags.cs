using UnityEngine;

public class TriggerToFlags : MonoBehaviour
{
    [SerializeField] private Animator _flagAnimator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            _flagAnimator.enabled = true;
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
