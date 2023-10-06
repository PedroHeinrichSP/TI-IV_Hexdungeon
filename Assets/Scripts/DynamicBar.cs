using UnityEngine;
using UnityEngine.UI;

public class DynamicBar : MonoBehaviour
{
    public Slider slider; // Reference to a UI Slider component for the bar.

    public void SetMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue; // Set the bar to its maximum value initially.
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }
}
