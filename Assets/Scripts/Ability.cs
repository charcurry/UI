using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{

    Image ability;
    public Image abilityRadial;
    public Sprite abilityColor;
    public Sprite abilityGrey;

    float timeRemaining;
    public float maxCountDownTime;

    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
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
        timeRemaining = 0;
    }

    public void UseAbility()
    {
        ability.sprite = abilityGrey;
        abilityRadial.fillAmount = 1;
        timeRemaining = maxCountDownTime;
    }
}
