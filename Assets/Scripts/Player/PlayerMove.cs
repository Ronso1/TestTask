using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 5f;
    [SerializeField] private float _boundaryLeft = -3f;
    [SerializeField] private float _boundaryRight = 3f;

    private float _dragSensitivity = 0.01f;
    private bool _isDragging = false;

    private void Update()
    {
        HandleTouchInput();
        MoveDirectionPlayer();
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
        if (Input.touchCount > 0)
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
                        float moveX = touchDelta.x * _dragSensitivity;

                        Vector3 newPosition = transform.position;

                        newPosition.x += moveX;

                        transform.position = newPosition;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _isDragging = false;
                    break;
            }
        }
    }

    private void MoveDirectionPlayer()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
    }

    public void RotatePlayer(float angle)
    {
        if (transform.localEulerAngles.y < angle)
        {
            transform.Rotate(0f, angle * Time.deltaTime, 0f);
            print(transform.localEulerAngles.y);
        }

    }
}