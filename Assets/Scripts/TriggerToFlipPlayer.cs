using UnityEngine;

public class TriggerToFlip : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private float _angleToFlip;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            _player.RotatePlayer(_angleToFlip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            _player.EndRotatePlayer();
        }
    }
}