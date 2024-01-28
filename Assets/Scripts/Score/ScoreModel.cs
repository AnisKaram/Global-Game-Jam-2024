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
        GameManager.OnGameWon += SaveTotalLaughs;

        _score = 0;
        _scorePresenter.UpdateScoreTextOnUI(_score);

        _highScore = LoadSavedHighScore();
    }

    private void OnDestroy()
    {
        HitDetection.OnCarHitCharacter -= IncrementScore;
        GameManager.OnGameWon -= SaveHighScore;
        GameManager.OnGameWon -= SaveTotalLaughs;
    }

    private void IncrementScore()
    {
        _score += 1;
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

    private void SaveTotalLaughs()
    {
        int previousTotalLaughs = PlayerPrefs.GetInt("totalLaughs_value", 0);
        PlayerPrefs.SetInt("totalLaughs_value", _score + previousTotalLaughs);
        PlayerPrefs.Save();
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
