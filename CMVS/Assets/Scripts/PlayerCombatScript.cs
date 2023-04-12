using System.Threading;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MasterController;

public class PlayerCombatScript : MonoBehaviour
{
    private TarodevController.IPlayerController _player; // Reference to PlayerController Interface
    public int maxHealth = 100, currentHealth;
    public HealthBarScript RefToHealthBar;
   // public DialogueManagerScript RefToDialogueManager;
    //public DialogueTrigger RefToDialogueTrigger;
    public TarodevController.PlayerAnimator RefToPlayerAnimator;
  
    public GameObject LoseScreen;

    public bool hasDied;
    public bool mobcollided;
    public bool HasDoneAnAttack;
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
        
        RefToHealthBar.SetMaxHealth(maxHealth); // Reference To Health Bar UI
      
        
        


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && HasDoneAnAttack)
        {
           mobcollided = true;
        }
        else mobcollided = false;


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
        if (!HasDoneAnAttack)
        {
            HasDoneAnAttack = true;
           
        }
        Thread.Sleep
        if (HasDoneAnAttack)
        {
          HasDoneAnAttack = false; 
          return;     
        }
      
     
      
       
    
    }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage; //Decrement Health Function
        RefToHealthBar.SetHealth(currentHealth); //Display UI
       // RefToPlayerAnimator.HasBeenDamaged();

    }
    public void onDeath()
    {
        //Hidden Dialogue Manager script data disabled because no dialogue

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
        anim.Play("Death forward"); //Play death animation
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; //Freeze RigidBody
        StartCoroutine(LoseScreenCo()); //Start Lose Screen Coroutine
       
        
        






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

