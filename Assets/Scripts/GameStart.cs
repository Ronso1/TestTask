using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;

    private bool _gameStarted;

    public bool GameStarted => _gameStarted;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _gameStarted = true;
            _playerMove.enabled = true;
            transform.GetComponent<GameStart>().enabled = false;
        }
    }
}
