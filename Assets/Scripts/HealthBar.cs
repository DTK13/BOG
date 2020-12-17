using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthBarSlider;
    public TextMeshProUGUI healthText;

    public void SetMaxHealth(int health)
    {
        healthBarSlider.maxValue = health;
        healthBarSlider.value = health;
        healthText.text=$"{healthBarSlider.value}/{healthBarSlider.maxValue}";
    }

    public void SetHealth(int health)
    {
        healthBarSlider.value = health;
        if (health <= 0)
        {
            healthText.text = $"{0}/{healthBarSlider.maxValue}";
        }
        else
        {
            healthText.text = $"{health}/{healthBarSlider.maxValue}";
        }


    }
}
