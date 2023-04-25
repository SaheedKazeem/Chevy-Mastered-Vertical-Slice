using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControllers;

public class BeeMobScript : MonoBehaviour
{
    private float knockbackForce = 5f;
    public int maxHealth = 100;
    int currentHealth;
    public float speed;
    public Transform target;
    public float minimumDistance;
    public PlayerCombatScript RefToPlayerCombatScript;
    public GameObject BeeBullet;
    public Animator RefToAnim;
    void Start()
    {
        currentHealth = maxHealth;
        StartCoroutine(BulletCloneTimer());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Make the object lock in place
        if (other.gameObject.CompareTag("Player"))
        {
            //Attack Code
            RefToPlayerCombatScript.TakeDamage(15);
            //Disable Pathfinder for Knockback
            GetComponent<Pathfinding.AIPath>().enabled = false;

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            // Calculate knockback direction
            Vector2 knockbackDir = transform.position - other.transform.position;

            // Apply knockback force
            GetComponent<Rigidbody2D>().AddForce(knockbackDir.normalized * knockbackForce, ForceMode2D.Impulse);
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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
    void Update()
    {
        
        {
           

        }
    }
    IEnumerator AITimer()
    {

        yield return new WaitForSeconds(1f);
        GetComponent<Pathfinding.AIPath>().enabled = true;

    }
     IEnumerator BulletCloneTimer()
    {
        while (true)
    {
        // Instantiate new GameObject from the same position as this GameObject
        
        yield return new WaitForSeconds(0.8f);

        // Check if the GameObject this script is attached to still exists
        if (gameObject == null)
        {
            yield break; // exit the coroutine if it doesn't exist
        }

        // Instantiate a new bullet from the same position as this GameObject
        
        GameObject bullet = Instantiate(BeeBullet, transform.position, Quaternion.identity, transform.parent);

        // Destroy the bullet after 3 seconds
       
        
    

    }
    }


}
