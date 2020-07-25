using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chance : MonoBehaviour
{
    Text chanceText;
    public GameObject controller;

    void Start()
    {
        chanceText = GetComponentsInChildren<Text>()[0];
        chanceText.text = controller.GetComponent<Avalanche>().chance.ToString() + "%";
    }
    
    public void ChangeChance()
    {
        chanceText.text = controller.GetComponent<Avalanche>().chance.ToString() + "%";
    }
}
