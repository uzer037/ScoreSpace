using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject energy;
    public string sceneAfterDeath = "SampleScene";
    bool dead = false;
    void Start()
    {
    }

    void Update()
    {
        dead = energy.GetComponent<Energy>().exhausted;
        if (dead)
        {
            Death();
        }
    }

    void Death()
    {
        SceneManager.LoadScene(sceneAfterDeath);
    }
}
