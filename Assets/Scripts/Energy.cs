using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float energy = 1;
    public float deltaEnergy = 0.01f;
    RectTransform energyBar;
    RectTransform spentEnergy;
    public bool exhausted = false;
    void Start()
    {
        energyBar = GetComponentsInChildren<RectTransform>()[2];
        spentEnergy = GetComponentsInChildren<RectTransform>()[3];
    }

    void FixedUpdate()
    {
        if (energy < 0)
        {
            exhausted = true;
            energy = 0;
        }
        else if (energy > 1)
        {
            energy = 1;
        }
        spentEnergy.sizeDelta = new Vector2(energyBar.rect.width * energy, spentEnergy.rect.height);
        energy -= deltaEnergy;
    }
}
