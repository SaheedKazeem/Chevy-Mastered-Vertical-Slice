using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
   // public DialogueManagerScript ReftoDialogueManager;
   public GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {

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
            WinScreen.SetActive(true);
            StartCoroutine(NextSceneLoader());
         }
         else  WinScreen.SetActive(false);
        

    }

    public IEnumerator NextSceneLoader()
    {
        yield return new WaitForSeconds(1.35f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
