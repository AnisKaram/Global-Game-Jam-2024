using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public GameState _gameState;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public GameState GameState
    {
        get { return _gameState; }
        set { _gameState = value; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        _gameState = GameState.Idle;

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex == 1)
        {
            _gameState = GameState.Running;
            Time.timeScale = 1;
        }
    }

    public static event UnityAction OnGameWon;
    public static event UnityAction OnGameLost;

    public void GameWon()
    {
        _gameState = GameState.Ended;
        Time.timeScale = 0;

        OnGameWon?.Invoke();
    }

    public void GameLost()
    {
        _gameState = GameState.Ended;
        Time.timeScale = 0;

        OnGameLost?.Invoke();
    }
}