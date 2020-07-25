using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{
    public float energyHeal = 0.1f;
    public GameObject energy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            energy.GetComponent<Energy>().energy += energyHeal;
            Destroy(gameObject);
        }
    }
}
