using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMobScript : MonoBehaviour
{
    public float knockbackForce = 100f;
    public int maxHealth = 100;
    int currentHealth;
    public float speed;
    float reftoSpeed;
    public Transform target;
    public float minimumDistance;
    public PlayerCombatScript RefToPlayerCombatScript;
    public Animator RefToAnim;

    // New variable to track if the slime has already damaged the player in the current collision
    private bool hasDamagedPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        reftoSpeed = speed;
    }

   private void OnCollisionStay2D(Collision2D other)
   {
       if (other.gameObject.CompareTag("Player") && !hasDamagedPlayer)
       {
           // Release the object from freeze constraints
           GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

           // Calculate knockback direction
           Vector2 knockbackDir = transform.position - other.transform.position;

           // Apply knockback force
           GetComponent<Rigidbody2D>().AddForce(knockbackDir.normalized * knockbackForce, ForceMode2D.Impulse);

           // Attack Code
           RefToPlayerCombatScript.TakeDamage(30);

           // Set the hasDamagedPlayer variable to true so that the slime won't damage the player again in this collision
           hasDamagedPlayer = true;
       }
   }

   void OnCollisionExit2D(Collision2D other)
   {
       // Lock the object again
    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    
    
       // Reset the hasDamagedPlayer variable when the collision ends
       hasDamagedPlayer = false;
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
