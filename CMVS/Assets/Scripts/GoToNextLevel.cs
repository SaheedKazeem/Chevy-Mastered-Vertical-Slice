using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    // public DialogueManagerScript ReftoDialogueManager;
    public GameObject WinScreen;
    public WinTreeScript RefToWinArt;
    Boolean ifWinScreenIsActive;
    // Start is called before the first frame update
    void Start()
    {
        RefToWinArt.WinTree.enabled = false;
        ifWinScreenIsActive = false;
    }

    // Start is called before the first frame update
    /* public void OnCollisionEnter2D(Collision2D other)
    {
        if (ReftoDialogueManager.HasSentenceEnded == true)
        {
            StartCoroutine(NextSceneLoader());
            ReftoDialogueManager.HasSentenceEnded = false;
        }


    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            if (!ifWinScreenIsActive) // Check if the coroutine has already started
            {
                StartCoroutine(WinStateAnim());
                ifWinScreenIsActive = true; // Set the flag to true when starting the coroutine
            }
        }
        else
        {
            ifWinScreenIsActive = false;
        };

    }

    public IEnumerator WinStateAnim()
    {

            RefToWinArt.WinTree.enabled = true;
            RefToWinArt.WinTree.Play("star fx");
            yield return new WaitForSeconds(1.2f);
            RefToWinArt.WinTree.StopPlayback();
            WinScreen.SetActive(true);
            


    }
    // Update is called once per frame
    void Update()
    {

    }
}
