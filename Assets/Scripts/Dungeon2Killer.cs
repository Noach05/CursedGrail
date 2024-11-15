using UnityEngine;

namespace DefaultNamespace
{
    public class Dungeon2Killer : MonoBehaviour
    {
        private Transform destination;
        void Start()
        {
            destination = GameObject.Find("Dungeon2Spawn").transform;
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
}