using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = System.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{

    public Slider red;
    public Slider green;
    public Slider blue;
    public Slider alpha;

    public Image healthBar;
    public float health;
    public float maxHealth;

    public TextMeshProUGUI showHideButtonText;
    public GameObject coin;
    public Image colorChangeImage;

    bool show = false;

    public int score;
    public TextMeshProUGUI scoreText;

    public void Awake()
    {
        scoreText.text = "Score: 0";
    }

    public void Update()
    {
        ColorChange();
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
        score = Mathf.Clamp(score, 0, 999999999);
        scoreText.text = "Score: " + score.ToString("n0");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Random()
    {
        Random rnd = new();
        int num = rnd.Next(-999999999, 999999999);
        if (num == 0)
        {
            num = 1;
        }
        ScoreUpdate(num);
    }

    public void ColorChange()
    {
        colorChangeImage.color = new Color(red.value, green.value, blue.value, alpha.value);
    }

    public void ShowHide()
    {
        show = !show;

        if (show == true)
        {
            showHideButtonText.text = "Hide";
            coin.SetActive(true);
        }
        else if (show == false)
        {
            showHideButtonText.text = "Show";
            coin.SetActive(false);
        }
    }

    public void UpdateHealth(int healthChange)
    {
        health += healthChange;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;
    }
}
