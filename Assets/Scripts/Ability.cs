using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{

    Image ability;
    public Image abilityRadial;
    public Sprite abilityColor;
    public Sprite abilityGrey;

    public TextMeshProUGUI timerText;

    float timeRemaining;
    public float maxCountDownTime;

    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "";
        ability = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && timeRemaining == 0)
        {
            UseAbility();
        }

        if (timeRemaining > 0)
        {
            timerText.text = timeRemaining.ToString("N0");
            timeRemaining -= Time.deltaTime;
            abilityRadial.fillAmount = timeRemaining / maxCountDownTime;
        }
        else
        {
            RefreshAbility();
        }
    }

    public void RefreshAbility()
    {
        ability.sprite = abilityColor;
        timerText.text = "";
        timeRemaining = 0;
    }

    public void UseAbility()
    {
        if (timeRemaining == 0)
        {
            ability.sprite = abilityGrey;
            abilityRadial.fillAmount = 1;
            timeRemaining = maxCountDownTime;
        }
    }
}
