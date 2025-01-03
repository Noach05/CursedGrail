using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonKillPane : MonoBehaviour
{
    private Transform destination;
    void Start()
    {
        destination = GameObject.Find("DungeonSpawn").transform;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.transform.position = destination.position;
            }
        }
}
