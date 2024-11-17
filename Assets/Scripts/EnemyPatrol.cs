using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float patrolSpeed = 2f;        // Movement speed of the enemy
    public float patrolDistance = 1000f;     // How far the enemy will patrol in each direction
    public Transform groundCheck;         // A transform to check the ground (used for edge detection)
    public LayerMask groundLayer;         // Layer mask to check ground collision

    private Rigidbody2D rb;               // Rigidbody to move the enemy
    private Animator anim;                // Reference to the animator
    private bool movingRight = true;      // Whether the enemy is moving to the right or left
    private Vector2 patrolStartPosition;  // The initial position of the enemy

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        patrolStartPosition = transform.position;  // Store the initial position
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        // Update animation speed based on movement
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        // Move the enemy left or right
        if (movingRight)
        {
            rb.velocity = new Vector2(patrolSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-patrolSpeed, rb.velocity.y);
        }

        // Check if the enemy has reached the edge of its patrol area
        if (Vector2.Distance(transform.position, patrolStartPosition) >= patrolDistance)
        {
            movingRight = !movingRight;  // Reverse direction
            Flip();  // Flip the sprite horizontally
            patrolStartPosition = transform.position;  // Reset the patrol start position
        }

        // Edge detection using ground check
        if (!Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        {
            movingRight = !movingRight;  // Reverse direction if no ground is detected
            Flip();  // Flip the sprite
        }
    }

    void Flip()
    {
        // Flip the sprite horizontally
        Vector3 localScale = transform.localScale;
        localScale.x = -localScale.x;
        transform.localScale = localScale;
    }
}