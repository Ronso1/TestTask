using UnityEngine;

public class TriggerToDoors : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Animator _doorsAnimator;
    [SerializeField] private int _scoreNeeded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>() && _gameManager.PlayerScore >= _scoreNeeded)
        {
            _doorsAnimator.enabled = true;
        }
    }
}
