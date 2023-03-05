using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollisionSceneChange : MonoBehaviour
{
    public DialogueManagerScript ReftoDialogueManager;
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (ReftoDialogueManager.HasSentenceEnded == true)
        {
            StartCoroutine(NextSceneLoader());
            ReftoDialogueManager.HasSentenceEnded = false;
        }


    }
   
    IEnumerator NextSceneLoader()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
