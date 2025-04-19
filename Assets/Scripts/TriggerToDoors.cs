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
    [SerializeField] private bool _finalDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerMove>()) return;

        if (_gameManager.PlayerScore >= _scoreNeeded)
        {
            if (_finalDoor)
            {
                if (_playerMove.enabled is false) return;

                _gameManager.GameComplete();
                _playerMove.enabled = false;
                return;
            }

            _doorsAnimator.enabled = true;
            _audioSource.PlayOneShot(_audioClipWin);
        }
        else
        {
            _audioSource.PlayOneShot(_audioClipLose);
            _playerMove.enabled = false;
            _gameManager.GameFailed();
        }
    }
}
