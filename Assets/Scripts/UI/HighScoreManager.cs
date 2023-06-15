using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    private int _highScore;
    private TMP_Text _highScoreText;

    public int HighScore => _highScore;

    private void Awake()
    {
        _highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        _highScoreText = GetComponent<TMP_Text>();
        UpdateHighScoreUI();
    }

    public void UpdateHighScore(int newScore)
    {
        if (newScore > _highScore)
        {
            _highScore = newScore;
            PlayerPrefs.SetInt(HighScoreKey, _highScore);
            UpdateHighScoreUI();
        }
    }

    public void ResetHighScore()
    {
        _highScore = 0;
        PlayerPrefs.DeleteKey(HighScoreKey);
        UpdateHighScoreUI();
    }

    private void UpdateHighScoreUI()
    {
        _highScoreText.text = _highScore.ToString();
    }
}
