using UnityEngine;

public class TimerModel : MonoBehaviour
{
    [SerializeField] private TimerPresenter _timerPresenter;

    private float _timer;
    private const float _timerSpeed = 50f;

    private void Awake()
    {
        _timer = Random.Range(28f, 35f);    
    }

    private void Update()
    {
        if (GameManager.Instance.GameState == GameState.Running)
        {
            if (_timer > 0f)
            {
                _timer -= _timerSpeed / 60f * Time.deltaTime;
                int seconds = ((int)_timer % 60);
                int minutes = ((int)_timer / 60);
                string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
                _timerPresenter.UpdateTimerOnUI(timerString);
            }

            if (_timer <= 0f)
            {
                GameManager.Instance.GameWon();
            }
        }
    }
}
