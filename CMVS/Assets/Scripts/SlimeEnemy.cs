using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public enum SlimeStates { Chase, Patrol }
    SlimeStates SlimeState;
    public float speed = 3f; // The speed at which the slime moves
    public float detectionRadius = 5f; // The radius in which the slime can detect the player
    public LayerMask playerLayer; // The layer the player is on
    public Transform groundDetection; // The point from which the slime checks if it's about to fall off a platform

    private Rigidbody2D rb;
    private bool facingRight = true; // Whether the slime is facing right or not
     private bool isFlipping = false; // flag to prevent multiple simultaneous flips
    private bool isChasing = false; // Whether the slime is chasing the player or not
    private Transform player; // The player's transform

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SlimeState = SlimeStates.Patrol;
    }

    void Update()
    {
        if (SlimeState == SlimeStates.Patrol)
        {
            // Check if the player is within the detection radius
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);
            if (colliders.Length > 0)
            {
                player = colliders[0].transform;
                isChasing = true;
            }
            else
            {
                isChasing = false;
            }
            // Move the slime left or right depending on its facing direction
            Vector2 movement = Vector2.right * (facingRight ? 1 : -1) * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
            // Flip the slime if it's about to fall off a platform
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
            if (!groundInfo.collider)
            {
                Flip();

            }
        }
        if (isChasing)
        {SlimeState = SlimeStates.Chase;}

        if (SlimeState == SlimeStates.Chase)
        {
            // Flip the slime if it's chasing the player and the player is on the other side
            if (isChasing && player.position.x < transform.position.x && facingRight)
            {
                Flip();
            }
            else if (isChasing && player.position.x > transform.position.x && !facingRight)
            {
                Flip();
            }
            // Move the slime left or right depending on its facing direction
            Vector2 movement = Vector2.right * (facingRight ? 1 : -1) * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }






    }


    void Flip()
    {
        if (isFlipping) return; // exit if Flip is already running
        isFlipping = true; // set the flag to indicate that Flip is running

        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

        // Check if the slime is about to fall off the platform
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
        if (!groundInfo.collider)
        {
            StartCoroutine(FlipDelay()); // If it's about to fall off, flip again after a delay
        }
        else
        {
            isFlipping = false; // reset the flag if Flip has finished
        }
    }

    IEnumerator FlipDelay()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 1 second before flipping again
        Flip(); // Flip again
    }

}
