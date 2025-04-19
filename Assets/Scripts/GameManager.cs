using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;
    [SerializeField] private Animator _playerAnimator;

    private int _playerScore = 40;

    public int PlayerScore => _playerScore;

    private void Update()
    { 
        CheckPlayerState();
    }

    private void CheckPlayerState()
    {
        const int firstLevel = 60;
        const int secondLevel = 90;

        if (_gameStart.GameStarted)
        {
            if (_playerAnimator.GetBool("IsStarted") is false) _playerAnimator.SetBool("IsStarted", true);
            print(_playerScore);
            if (_playerScore >= firstLevel)
            {
                _playerAnimator.SetBool("IsLvlUpFirst", true);
            }

            if (_playerScore >= secondLevel)
            {
                _playerAnimator.SetBool("IsLvlUpSecond", true);
            }

            if (_playerScore < secondLevel)
            {
                _playerAnimator.SetBool("IsLvlUpSecond", false);
            }

            if (_playerScore < firstLevel)
            {
                _playerAnimator.SetBool("IsLvlUpFirst", false);
            }
        }

    }

    public void IncreaseScore(int pointValue)
    {
        _playerScore += pointValue;
    }

    public void DecreaseScore(int pointValue)
    {
        if (_playerScore - pointValue < 0)
        {
            _playerScore = 0;
            return;
        }

       _playerScore -= pointValue;
    }
}