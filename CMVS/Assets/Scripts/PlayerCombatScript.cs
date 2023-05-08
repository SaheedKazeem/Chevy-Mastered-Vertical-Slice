using System.Threading;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;



namespace PlayerControllers
{
public class PlayerCombatScript : MonoBehaviour
{
    private TarodevController.IPlayerController _player; // Reference to PlayerController Interface
    [SerializeField] int maxHealth = 100, currentHealth;
    [SerializeField] HealthBarScript RefToHealthBar;
   // public DialogueManagerScript RefToDialogueManager;
    //public DialogueTrigger RefToDialogueTrigger;
    [SerializeField] TarodevController.PlayerAnimator RefToPlayerAnimator;
  
    [SerializeField]GameObject LoseScreen;

   
    public bool mobcollided;
    public bool HasDoneAnAttack;
    public Animator anim;
    public Transform attackPoint;
    
    public GameObject AttackPoint;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
        RefToHealthBar.SetMaxHealth(maxHealth); // Reference To Health Bar UI
      
        
        


    }

    void OnTriggerEnter2D(Collider2D other)
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
            if(this != null)
            {
                 TakeDamage(10);
            }
           
        }


    }
    public async void BabyKick()
    {
       if (!HasDoneAnAttack)
    {
        
             AttackPoint.SetActive(true);
        HasDoneAnAttack = true;
        await Task.Delay(500); // Wait for 1 second (1000 milliseconds)
        HasDoneAnAttack = false; // Reset the flag
        if (AttackPoint != null)
        {
        AttackPoint.SetActive(false);
        }
       
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

}

