using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTimeAdjust : MonoBehaviour
{
    public Light light;
    public float time;

    // Change the time of day
    public void ChangeTime(float time){
        // Take the time value and convert it to a intensity value, then set the light intensity to that value
        // 0 = Midnight, 1 = Midday
        light.intensity = time * 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Call ChangeTime() with the current time of day
        ChangeTime(System.DateTime.Now.Hour / 24f);
    }
}
