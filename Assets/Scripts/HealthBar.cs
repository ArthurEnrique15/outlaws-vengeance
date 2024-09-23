using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    void Start()
    {
        healthSlider.value = 100f;
    }

    public void SetHealthSliderValue(float health)
    {
        healthSlider.value = health;
    }
}
