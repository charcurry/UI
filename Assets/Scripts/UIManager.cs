using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public void Awake()
    {
        scoreText.text = "Score: 0";
    }

    public void ScoreUpdate(int num)
    {
        if (num == 0)
        {
            score = 0;
        }
        else
        {
            score += num;
        }
        scoreText.text = "Score: " + score.ToString();
    }
}
