﻿using System.Threading;
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

        [SerializeField] GameObject LoseScreen;
        


        public bool mobcollided;
        public bool HasDoneAnAttack;
        public Animator anim;
        CapsuleCollider2D attackPoint;

        //public GameObject AttackPoint;



        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;

            RefToHealthBar.SetMaxHealth(maxHealth); // Reference To Health Bar UI
            //attackPoint = AttackPoint.GetComponent<CapsuleCollider2D>();
            //attackPoint.enabled = false;




        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (HasDoneAnAttack)
            {
                mobcollided = true;
                
            }
            if (!HasDoneAnAttack)
            {
                mobcollided = false;
                Vector2 knockbackDir = transform.position - other.transform.position;

            // Apply knockback force
            GetComponent<Rigidbody2D>().AddForce(knockbackDir.normalized * 145, ForceMode2D.Impulse);
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
                transform.position = new Vector2(transform.position.x, 55f);
                if (this != null)
                {
                    TakeDamage(10);
                }

            }
            else if (transform.position.y >= 56f)
            {   
                transform.position = new Vector2(transform.position.x, 56f);
            }


        }
        public async void BabyKick()
        {
            if (!HasDoneAnAttack)
            {

               // AttackPoint.SetActive(true);
                // attackPoint.enabled = true;
                HasDoneAnAttack = true;
                await Task.Delay(750); // Wait for 1 second (1000 milliseconds)
                HasDoneAnAttack = false; // Reset the flag
                /*if (AttackPoint != null)
                {
                    //AttackPoint.SetActive(false);
                    attackPoint.enabled = false;
                }
                */
            }




        }
        public void TakeDamage(int Damage)
        {
            currentHealth -= Damage; //Decrement Health Function
            if (RefToHealthBar != null)
            {
                RefToHealthBar.SetHealth(currentHealth); //Display UI
            }

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

            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        IEnumerator LoseScreenCo()
        {

            yield return new WaitForSeconds(1.5f);
            LoseScreen.SetActive(true);

        }



    }

}

