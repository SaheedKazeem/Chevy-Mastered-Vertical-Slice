using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMobScript : MonoBehaviour
{
    private float knockbackForce = 180f;
    public int maxHealth = 100;
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

   private void OnCollisionStay2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        // Release the object from freeze constraints
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

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
        
        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (transform.position.y <= -10.5f)
        {
            transform.position = new Vector2(transform.position.x, 56f);
        }
    }

}
