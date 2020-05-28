using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image greenHealth;
    public Image yellowHealth;
    public Image redHealth;
    public Image deadHealth;
    private GradientColorKey[] colorKeys;
    private GradientAlphaKey[] alphaKeys;

    void Start()
    {
        colorKeys = new GradientColorKey[3];
        alphaKeys = new GradientAlphaKey[2];

        alphaKeys[0].time = 0f;
        alphaKeys[0].alpha = 1;

        alphaKeys[1].time = 1f;
        alphaKeys[1].alpha = 1;

        colorKeys[0].time = 1f;
        colorKeys[0].color = Color.green;

        colorKeys[1].time = 0.60f;
        colorKeys[1].color = Color.yellow;

        colorKeys[2].time = 0.25f;
        colorKeys[2].color = Color.red;

        gradient.SetKeys(colorKeys, alphaKeys);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        Color color = gradient.Evaluate(slider.normalizedValue);
        fill.color = color;
        SetStatusImage(color, slider.normalizedValue);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        Color color = gradient.Evaluate(slider.normalizedValue);
        fill.color = color;
        SetStatusImage(color, slider.normalizedValue);
    }

    public float GetHealth()
    {
        return slider.value;
    }

    private void SetStatusImage(Color color, float normalizedValue)
    {
        if (normalizedValue > 0)
        {
            if (color == Color.green)
            {
                greenHealth.enabled = true;
                yellowHealth.enabled = false;
                redHealth.enabled = false;
                deadHealth.enabled = false;
            }
            else if (color == Color.yellow)
            {
                greenHealth.enabled = false;
                yellowHealth.enabled = true;
                redHealth.enabled = false;
                deadHealth.enabled = false;
            }
            else if (color == Color.red)
            {
                greenHealth.enabled = false;
                yellowHealth.enabled = false;
                redHealth.enabled = true;
                deadHealth.enabled = false;
            }
        }else
        {
            greenHealth.enabled = false;
            yellowHealth.enabled = false;
            redHealth.enabled = false;
            deadHealth.enabled = true;
        }
    }
}
