using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _playerState;
    [SerializeField] private GameStart _gameStart;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _restartButton;

    private int _playerScore = 40;
    private int _currentState = 0;

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

            if (_playerScore >= firstLevel && _currentState == 0)
            {
                _playerAnimator.SetBool("IsLvlUpFirst", true);
                ChangePlayerState(true);
            }

            if (_playerScore >= secondLevel && _currentState == 1)
            {
                _playerAnimator.SetBool("IsLvlUpSecond", true);
                ChangePlayerState(true);
            }

            if (_playerScore < secondLevel && _currentState == 2)              
            {
                _playerAnimator.SetBool("IsLvlUpSecond", false);
                ChangePlayerState(false);
            }

            if (_playerScore < firstLevel && _currentState == 1)
            {
                _playerAnimator.SetBool("IsLvlUpFirst", false);
                ChangePlayerState(false);
            }
        }

    }

    private void ChangePlayerState(bool lvlUp)
    {
        _playerState[_currentState].SetActive(false);

        _currentState = lvlUp ? ++_currentState : --_currentState;
        print(_currentState);
        _playerState[_currentState].SetActive(true);
    }

    public void IncreaseScore(int pointValue)
    {
        _playerScore += pointValue;
        _scoreText.text = _playerScore.ToString();
    }

    public void DecreaseScore(int pointValue)
    {
        if (_playerScore - pointValue < 0)
        {
            _playerScore = 0;
            return;
        }

        _playerScore -= pointValue;
        _scoreText.text = _playerScore.ToString();
    }

    public void GameComplete()
    {
        _playerAnimator.SetTrigger("Win");
        _restartButton.SetActive(true);
    }

    public void GameFailed()
    {
        _playerAnimator.SetTrigger("Fail");
        _restartButton.SetActive(true);
    }
}