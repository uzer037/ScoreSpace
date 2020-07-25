using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    float energy = 0;
    public float deltaEnergy = 0.01f;
    RectTransform energyBar;
    RectTransform spentEnergy;
    public bool full = false;
    void Start()
    {
        energyBar = GetComponentsInChildren<RectTransform>()[2];
        spentEnergy = GetComponentsInChildren<RectTransform>()[3];
    }

    void FixedUpdate()
    {
        spentEnergy.sizeDelta = new Vector2(energyBar.rect.width * energy, spentEnergy.rect.height);
        energy += deltaEnergy;
        if (energy > 1)
        {
            full = true;
            energy = 1;
        }
    }
}
