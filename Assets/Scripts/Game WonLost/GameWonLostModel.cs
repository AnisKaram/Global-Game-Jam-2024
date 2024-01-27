using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonLostModel : MonoBehaviour
{
    [SerializeField] private GameWonLostPresenter _gameWonLostPresenter;

    private void Awake()
    {
        GameManager.OnGameWon += GameWon;
        GameManager.OnGameLost += GameLost;
    }

    private void OnDestroy()
    {
        GameManager.OnGameWon -= GameWon;
        GameManager.OnGameLost -= GameLost;
    }

    private void GameWon()
    {
        _gameWonLostPresenter.ShowGameWonCanvas();
        Debug.Log($"Game won");
    }

    private void GameLost()
    {
        Time.timeScale = 0;
        _gameWonLostPresenter.ShowGameLostCanvas();
        Debug.Log($"Game Lost");
    }
}