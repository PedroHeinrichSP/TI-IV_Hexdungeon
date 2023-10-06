using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject healthBarMax;
    public GameObject healthBar;
    public GameObject energyBarMax;
    public GameObject energyBar;

    public float healthMax = 100;
    public float energyMax = 100;
    public float health = 100;
    public float energy = 100;

    void Update () {
        //Sets the m_sizeDelta.x of the "MAX" panel to 100*slider value
        healthBarMax.GetComponent<RectTransform>().sizeDelta = new Vector2(healthMax, 20);
        energyBarMax.GetComponent<RectTransform>().sizeDelta = new Vector2(energyMax, 20);
        //Sets the m_sizeDelta.x of the "CUR" panel to 100*slider value or max value if slider value is greater than max value
        if (health > healthMax) {
            healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(healthMax, 20);
            health = healthMax;
        } else {
            healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(health, 20);
        }
        if (energy > energyMax) {
            energyBar.GetComponent<RectTransform>().sizeDelta = new Vector2(energyMax, 20);
            energy = energyMax;
        } else {
            energyBar.GetComponent<RectTransform>().sizeDelta = new Vector2(energy, 20);
        }
    }
}
