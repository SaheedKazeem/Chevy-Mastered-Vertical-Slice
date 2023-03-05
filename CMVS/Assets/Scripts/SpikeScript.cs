using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public PlayerCombatScript RefToPlayer;
    Animator SpikeAnimator;
    bool spikeHasBeenPressed;
    private void Awake()
    {
        SpikeAnimator = GetComponent<Animator>();
        RefToPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spikeHasBeenPressed = true;
            if(spikeHasBeenPressed == true)
            {
                SpikeAnimator.SetTrigger(SpikeActivateKey);
                RefToPlayer.TakeDamage(20);
            }
            
        }
        else spikeHasBeenPressed = false;
    }
    private static readonly int SpikeActivateKey = Animator.StringToHash("ActivateWhenStandingOn");
}
