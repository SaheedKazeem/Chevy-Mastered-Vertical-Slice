﻿using UnityEngine;

public class TutorialTrigScript : MonoBehaviour
{

    bool TutorialHasBeenTriggered = false;
    public GameObject RefToDialogueBox;
   public DialogueTrigger RefToDialogueTrigger;
   private void OnTriggerEnter2D(Collider2D other) 
  {
      TutorialHasBeenTriggered = true;
        if (TutorialHasBeenTriggered)
      {  
        RefToDialogueTrigger.TriggerDialogue();
        Destroy(this.GetComponent<TutorialTrigScript>());
      }
      
  }
}
