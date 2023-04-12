using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMobScript : MonoBehaviour
{
    private float knockbackForce = 5f;
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


}
