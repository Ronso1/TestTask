using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 5f;
    [SerializeField] private float _sidewaysSpeed = 10f;
    [SerializeField] private float _boundaryLeft = -3f;
    [SerializeField] private float _boundaryRight = 3f;

    private float _screenWidth;
    private float _inputX;

    private void Awake()
    {
        _screenWidth = Screen.width;
    }

    private void Update()
    {
        HandleTouchInput();
        MoveSideways();
        MoveDirectionPlayer();
    }

    private void HandleTouchInput()
    {
        _inputX = 0f;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                float halfScreen = _screenWidth / 2f;

                if (touch.position.x < halfScreen)
                    _inputX = -1f;
                else
                    _inputX = 1f;
            }
        }
    }

    private void MoveSideways()
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x += _inputX * _sidewaysSpeed * Time.deltaTime;

        playerPosition.x = Mathf.Clamp(playerPosition.x, _boundaryLeft, _boundaryRight);

        transform.position = playerPosition;
    }

    private void MoveDirectionPlayer()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);

    }
}
