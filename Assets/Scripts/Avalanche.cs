using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Avalanche : MonoBehaviour
{
    public UnityEvent chanceChanged;
    public float width = 0.5f;
    public int spread = 10;
    public int count = 3;
    public float chance = 0;
    public GameObject player;
    int[] avalanches;

    void Start()
    {
        avalanches = new int[3];
        CreateAvalanches();
    }

    public void ProcessTurn()
    {
        if (UnityEngine.Random.Range(0, 99) < chance)
        {
            LaunchAvalanches();
            CreateAvalanches();
            chance = 0;
        }
        chance += UnityEngine.Random.Range(0, 100);
        if (chance > 100)
        {
            chance = 100;
        }
        chanceChanged.Invoke();
    }

    void LaunchAvalanches()
    {
        Debug.Log("OMG AVALANCHES!1!!11!");
        foreach (int i in avalanches)
        {
            CheckHit(i);
        }
    }

    void CreateAvalanches()
    {
        avalanches = Enumerable.Range(-spread, 2 * spread + 1).
                     OrderBy(x => System.Guid.NewGuid()).Take(count).ToArray();
        foreach (int i in avalanches)
        {
            Debug.Log(i);
        }
    }

    void CheckHit(int pos)
    {
        float playerX = player.transform.position.x;
        if (playerX > pos * width - width / 2 && playerX < pos * width + width / 2)
        {
            Debug.Log("HIT YA");
        };
    }
}
