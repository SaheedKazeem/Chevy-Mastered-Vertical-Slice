using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MasterController;

public class PlayerCombatScript : MonoBehaviour
{
    private TarodevController.IPlayerController _player;
    public int maxHealth = 100, currentHealth;
    public HealthBarScript RefToHealthBar;
    public DialogueManagerScript RefToDialogueManager;
    public DialogueTrigger RefToDialogueTrigger;
    //public PlayerAnimator RefToPlayerAnimator;
    CapsuleCollider2D RefToKnockbackCollider;
    public GameObject LoseScreen;
    Knockback RefToKnockback;
    public bool hasDied;
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
        RefToHealthBar.SetMaxHealth(maxHealth);
        RefToKnockbackCollider = attackPoint.GetComponent<CapsuleCollider2D>();
        RefToKnockback = attackPoint.GetComponent<Knockback>();
        if (RefToKnockback != null)
        {
            RefToKnockback.enabled = false;
            RefToKnockbackCollider.enabled = false;
        }
        


    }


    // Update is called once per frame
    void Update()
    {
        
        if (currentHealth <= 0)
        {
            onDeath();
        }
        if (transform.position.y <= -10.5f)
        {
            transform.position = new Vector2(transform.position.x, 56f);
            TakeDamage(10);
        }


    }
    public void BabyKick()
    {
       
        // Detect enemies in range of attack
        RefToKnockbackCollider.enabled = true;
        RefToKnockback.enabled = true;
        Collider2D[] EnemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // Damage them

        foreach (Collider2D enemy in EnemiesHit)
        {
            enemy.GetComponent<SlimeMobScript>().TakeDamage(25);
        }
        StartCoroutine(ColliderTimer(RefToKnockback, RefToKnockbackCollider));
    }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        RefToHealthBar.SetHealth(currentHealth);
       // RefToPlayerAnimator.HasBeenDamaged();

    }
    public void onDeath()
    {
        /* if (gameObject != null)
        {
             if (RefToDialogueManager.HasSentenceEnded == true)
            {
                RefToDialogueTrigger.TriggerDialogue();
                RefToDialogueManager.HasSentenceEnded = false;
                anim.SetTrigger("hasDied");
                hasDied = true;
                StartCoroutine(RestartScene());


            }
        }
        */
        anim.SetTrigger("hasDied");
        
        StartCoroutine(LoseScreenCo());
        StartCoroutine(RestartScene());
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        






    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    IEnumerator ColliderTimer(Knockback RefToKnockback, CapsuleCollider2D RefToKnockbackCollider)
    {                                                                                                                                                                                                                               
        if (attackPoint != null)
        {
            yield return new WaitForSeconds(0.5f);
            RefToKnockbackCollider.enabled = false;
            RefToKnockback.enabled = false;
        }
    }
    IEnumerator RestartScene()
    {

        yield return new WaitForSeconds(3.15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
     IEnumerator LoseScreenCo()
    {

        yield return new WaitForSeconds(1.5f);
        LoseScreen.SetActive(true);

    }



}

