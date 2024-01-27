using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScoreTextOnUI(int score)
    {
        _scoreText.text = $"Score: {score}";
    } 
}
