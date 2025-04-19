using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _playerScore = 0;

    public int PlayerScore => _playerScore;

    public void IncreaseScore(int pointValue)
    {
        _playerScore += pointValue;
        print(_playerScore);
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