using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackTime, Thrust;
    // Start is called before the first frame update
    void Start()
    {

    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
               
               Vector2 difference = enemy.transform.position - transform.position;
               difference = difference.normalized * Thrust;
               enemy.AddForce(difference, ForceMode2D.Impulse);
               enemy.isKinematic = true;
               StartCoroutine(KnockbackCo(enemy));
              
            }
        }
    }
   IEnumerator KnockbackCo(Rigidbody2D enemy)
   {
       if (enemy != null)
       {
           yield return new WaitForSeconds(knockbackTime);
           enemy.velocity = Vector2.zero;
           
       }

   }
    
}
