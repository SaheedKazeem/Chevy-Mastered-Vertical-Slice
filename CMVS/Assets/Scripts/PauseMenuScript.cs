using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuScript : MonoBehaviour
{
   public static bool GameIsPaused = false;
   public GameObject PauseMenuUI, RefToResumeButton, RefToOptionsButton, RefToBackButton;
   public DialogueManagerScript RefToDialogueMan;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
            
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
         EventSystem.current.SetSelectedGameObject(null);
        //set a new selected button
        EventSystem.current.SetSelectedGameObject(RefToDialogueMan.RefToSkipButton);
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        //clear selected button 
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected button
        EventSystem.current.SetSelectedGameObject(RefToResumeButton);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);

        //clear selected button 
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected button
        EventSystem.current.SetSelectedGameObject(RefToOptionsButton);
    }
    public void QuitGame()
    {
        Application.Quit(); //the goodbye button
    }
    
}
