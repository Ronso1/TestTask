using UnityEditor;
using UnityEngine;

public class ItemInteractLogic : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private bool _isGoodItem;
    [Space]
    [SerializeField] private int _score = 2;

    private void OnDisable()
    {
#if UNITY_EDITOR
        if (!EditorApplication.isPlayingOrWillChangePlaymode) return;
#endif

        ItemBehavior();
    }

    private void ItemBehavior()
    {
        if (_isGoodItem)
        {
            _gameManager.IncreaseScore(_score);
        }
        else
        {
            _gameManager.DecreaseScore(_score);
        }
        _audioSource.PlayOneShot(_audioClip);
    }
}
