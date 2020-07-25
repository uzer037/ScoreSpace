using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chance : MonoBehaviour
{
    int chance = 0;
    Text chanceText;
    void Start()
    {
        chanceText = GetComponentsInChildren<Text>()[0];
        chanceText.text = chance.ToString() + "%";
    }
    
    public void ChangeChance()
    {
        chance += Random.Range(0, 100);
        if (chance >= 100)
        {
            chance -= 100;
        }
        chanceText.text = chance.ToString() + "%";
    }
}
