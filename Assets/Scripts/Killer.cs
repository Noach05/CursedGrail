using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private Animator animator;

    void Start()
    {
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject;
            Debug.Log("Player hit hazard, starting death transition.");
            StartCoroutine(DeathTransition(player));
        }
    }

    IEnumerator DeathTransition(GameObject player)
    {
        var rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.Play("Player_Death");
        yield return new WaitForSeconds(0.6f);
        Debug.Log("Respawning player at: " + destination.position);
        player.transform.position = destination.position;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.velocity = Vector2.zero;
    }
}