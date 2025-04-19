using UnityEngine;

public class TriggerToFlags : MonoBehaviour
{
    [SerializeField] private Animator _flagAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            _flagAnimator.enabled = true;
        }
    }
}
