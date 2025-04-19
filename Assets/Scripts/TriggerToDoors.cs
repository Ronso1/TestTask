using UnityEngine;

public class TriggerToDoors : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Animator _doorsAnimator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipWin;
    [SerializeField] private AudioClip _audioClipLose;
    [SerializeField] private int _scoreNeeded;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerMove>()) return;

        if (_gameManager.PlayerScore >= _scoreNeeded)
        {
            _doorsAnimator.enabled = true;
            _audioSource.PlayOneShot(_audioClipWin);
        }
        else
        {
            _audioSource.PlayOneShot(_audioClipLose);
            _playerMove.enabled = false;
        }
    }
}
