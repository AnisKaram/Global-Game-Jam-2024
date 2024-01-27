using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    [SerializeField] private ScorePresenter _scorePresenter;
    [SerializeField] private int _score;
    [SerializeField] private int _highScore;

    public int Score
    {
        get { return _score; }
    }

    public int HighScore
    {
        get { return _highScore; }
    }

    private void Awake()
    {
        HitDetection.OnCarHitCharacter += IncrementScore;
        GameManager.OnGameWon += SaveHighScore; 

        _score = 0;
        _scorePresenter.UpdateScoreTextOnUI(_score);

        _highScore = LoadSavedHighScore();
    }

    private void OnDestroy()
    {
        HitDetection.OnCarHitCharacter -= IncrementScore;
        GameManager.OnGameWon -= SaveHighScore;
    }

    private void IncrementScore()
    {
        _score += 10;
        _scorePresenter.UpdateScoreTextOnUI(_score);

        if (_score > _highScore)
        {
            _highScore = _score;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SaveHighScore();
        }
    }

    private void SaveHighScore()
    {
        if (_highScore <= _score)
        {
            PlayerPrefs.SetInt("highScore_value", _highScore);
            PlayerPrefs.Save();
        }
    }

    private int LoadSavedHighScore()
    {
        if (PlayerPrefs.HasKey("highScore_value"))
        {
            return PlayerPrefs.GetInt("highScore_value");
        }
        return 0;
    }
}
