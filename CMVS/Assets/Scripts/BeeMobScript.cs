using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMobScript : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public float speed;
    public Transform target;
    public float minimumDistance;
    public PlayerCombatScript RefToPlayerCombatScript;
    public Animator RefToAnim;
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        //Make the object lock in place
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

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
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //Attack Code
            RefToPlayerCombatScript.TakeDamage(15);

        }
    }

   

}
