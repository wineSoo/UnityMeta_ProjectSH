using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("LastMiniGameScore", 0);
        scoreText.text = $"미니게임 점수: {score}";
    }
}
