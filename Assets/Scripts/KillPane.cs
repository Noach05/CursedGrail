using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPane : MonoBehaviour
{
    private Transform destination;
    
    private void Start()
    {
        destination = GameObject.Find("SpawnLocation").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = destination.position;
        }
    }
}
