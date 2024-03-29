﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControllers;


public class SlimeMobScript : MonoBehaviour
{

    private float knockbackForce = 135f;
    public int maxHealth = 100;
    bool beenHit = false;
    int currentHealth;
    public float speed;
    float reftoSpeed;
    public Transform target;
    public float minimumDistance;
    public PlayerCombatScript RefToPlayerCombatScript;
    public Animator RefToAnim;
    Vector2 PlayerDir;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        reftoSpeed = speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")  )
        {
            // Release the object from freeze constraints
            GetComponent<Pathfinding.AIPath>().enabled = false;
           
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
              // Calculate knockback direction
            Vector2 knockbackDir = transform.position - other.transform.position;

            // Apply knockback force
            GetComponent<Rigidbody2D>().AddForce(knockbackDir.normalized * knockbackForce, ForceMode2D.Impulse);
            
            // Attack Code
            if (!RefToPlayerCombatScript.mobcollided)
            {
                 GetComponent<Rigidbody2D>().AddForce(knockbackDir.normalized * knockbackForce, ForceMode2D.Impulse);
                
                 RefToPlayerCombatScript.TakeDamage(30);
            }
           
            if(RefToPlayerCombatScript.mobcollided)
            {
                 GetComponent<Rigidbody2D>().AddForce(knockbackDir.normalized * knockbackForce, ForceMode2D.Impulse);
                TakeDamage(50);
            }
        }



    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AITimer());

        }
        if (other.gameObject.CompareTag("Attack"))
        {
            RefToPlayerCombatScript.mobcollided = false;
            StartCoroutine(AITimer());


        }



    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        RefToAnim.SetTrigger("hasBeenHit");
        // Play hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        // Die animation
        Destroy(gameObject);

        // Destroy object
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator AITimer()
    {

        yield return new WaitForSeconds(0.9f);
        GetComponent<Pathfinding.AIPath>().enabled = true;

    }

}