using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int maxhealth){
        slider.maxValue=maxhealth;
        slider.value =maxhealth;
    }

    public void SetHealth(int health){
        slider.value = health;
    }
}
