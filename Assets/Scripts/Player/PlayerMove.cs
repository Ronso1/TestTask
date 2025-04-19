using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 300f;
    [SerializeField] private float _dragSensitivity = 0.01f;

    private CharacterController _controller;

    private bool _isDragging = false;
    private bool _isFlipping = false;

    private float _targetAngle;
    private bool _isRotating = false;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleTouchInput();
        MoveForward();

        if (_isRotating)
        {
            SmoothRotate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemInteractLogic>())
        {
            other.gameObject.SetActive(false);
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0 && !_isFlipping)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (_isDragging)
                    {
                        Vector2 touchDelta = touch.deltaPosition;
                        float moveAmount = touchDelta.x * _dragSensitivity;

                        Vector3 lateralMove = transform.right * moveAmount;
                        _controller.Move(lateralMove);
                    }
                    break;

                case TouchPhase.Canceled:
                    _isDragging = false;
                    break;
            }
        }
    }

    private void MoveForward()
    {
        Vector3 forwardMove = transform.forward * _forwardSpeed * Time.deltaTime;
        _controller.Move(forwardMove);
    }

    public void RotatePlayer(float angle)
    {
        if (_isRotating) return;

        _targetAngle = angle;
        _isRotating = true;
        _isFlipping = true;
    }

    private void SmoothRotate()
    {
        float currentY = transform.localEulerAngles.y;
        float newY = Mathf.MoveTowardsAngle(currentY, _targetAngle, _rotateSpeed * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0f, newY, 0f);

        if (Mathf.Approximately(Mathf.DeltaAngle(currentY, _targetAngle), 0f))
        {
            transform.localEulerAngles = new Vector3(0f, _targetAngle, 0f);
            _isRotating = false;
            _isFlipping = false;
        }
    }

    public void EndRotatePlayer()
    {
        _isFlipping = false;
    }
}