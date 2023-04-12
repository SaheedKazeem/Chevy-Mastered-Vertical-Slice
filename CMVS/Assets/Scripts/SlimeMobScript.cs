using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMobScript : MonoBehaviour
{
    private float knockbackForce = 180f;
    public int maxHealth = 100;
    bool beenHit = false;
    int currentHealth;
    public float speed;
    float reftoSpeed;
    public Transform target;
    public float minimumDistance;
    public PlayerCombatScript RefToPlayerCombatScript;
    public Animator RefToAnim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        reftoSpeed = speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Release the object from freeze constraints
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
             

            // Calculate knockback direction
            Vector2 knockbackDir = transform.position - other.transform.position;

            // Apply knockback force
            GetComponent<Rigidbody2D>().AddForce(knockbackDir.normalized * knockbackForce, ForceMode2D.Impulse);

            // Attack Code
            RefToPlayerCombatScript.TakeDamage(30);
        }


    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Lock the object again
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
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
        gameObject.SetActive(false);

        // Destroy object
    }

    // Update is called once per frame
    void Update()
    {

    }

}