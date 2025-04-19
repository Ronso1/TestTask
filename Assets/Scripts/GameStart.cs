using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _playerMove.enabled = true;
            transform.GetComponent<GameStart>().enabled = false;
        }
    }
}
