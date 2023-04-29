using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
   // public DialogueManagerScript ReftoDialogueManager;
   public GameObject WinScreen;
   public WinTreeScript RefToWinArt;
    // Start is called before the first frame update
    void Start()
    {
        RefToWinArt.WinTree.enabled = false;
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
        
            StartCoroutine(WinStateAnim());
         }
         else  WinScreen.SetActive(false);
        

    }

    public IEnumerator WinStateAnim()
    {
        RefToWinArt.WinTree.enabled = true;
        RefToWinArt.WinTree.Play("star fx");
        yield return new WaitForSeconds(1.2f);
        WinScreen.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
