using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWonLostPresenter : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private ScoreModel _scoreModel;

    [Header("GameObjects")]
    [SerializeField] private GameObject _gameWonCanvas;
    [SerializeField] private GameObject _gameLostCanvas;

    [Header("GameWon Buttons")]
    [SerializeField] private Button _gameWonRestartButton;
    [SerializeField] private Button _gameWonMainMenuButton;
    [SerializeField] private Button _gameWonQuitButton;

    [Header("GameLost Buttons")]
    [SerializeField] private Button _gameLostRestartButton;
    [SerializeField] private Button _gameLostMainMenuButton;
    [SerializeField] private Button _gameLostQuitButton;

    [Header("GameWon Texts")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private UnityAction _restartAction;
    private UnityAction _mainMenuAction;
    private UnityAction _quitAction;

    private void Awake()
    {
        _restartAction = new UnityAction(OnRestartButtonClicked);
        _mainMenuAction = new UnityAction(OnMainMenuButtonClicked);
        _quitAction = new UnityAction(OnQuitButtonClicked);
    }

    public void ShowGameWonCanvas()
    {
        _gameWonRestartButton.onClick.AddListener(_restartAction);
        _gameWonMainMenuButton.onClick.AddListener(_mainMenuAction);
        _gameWonQuitButton.onClick.AddListener(_quitAction);

        _scoreText.text = $"Laughs: {_scoreModel.Score}";
        _highScoreText.text = $"HighScore: {_scoreModel.HighScore}";

        _gameWonCanvas.SetActive(true);
    }

    public void ShowGameLostCanvas()
    {
        _gameLostRestartButton.onClick.AddListener(_restartAction);
        _gameLostMainMenuButton.onClick.AddListener(_mainMenuAction);
        _gameLostQuitButton.onClick.AddListener(_quitAction);

        _gameLostCanvas.SetActive(true);
    }

    private void OnRestartButtonClicked()
    {
        SoundManager.Instance.PlaySfx(1);
        SceneManager.LoadSceneAsync(1);
    }

    private void OnMainMenuButtonClicked()
    {
        SoundManager.Instance.PlaySfx(1);
        SceneManager.LoadSceneAsync(0);
    }

    private void OnQuitButtonClicked()
    {
        SoundManager.Instance.PlaySfx(1);
        Application.Quit();
    }
}