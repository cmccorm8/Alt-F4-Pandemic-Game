using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionMeter : MonoBehaviour
{
    public Slider slider;

    public void set(int value)
    {
        slider.value = value;
    }

    public void add(int value)
    {
        slider.value += value;
    }

    public void subtract(int value)
    {
        slider.value -= value;
    }

    public float get()
    {
        return slider.value;
    }
}
