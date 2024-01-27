using UnityEngine;
using TMPro;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public void UpdateTimerOnUI(string timer)
    {
        _timerText.text = timer;
    }
}
