using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueUpdateScript : MonoBehaviour
{
    public GameObject CharacterSpeakingBox;
    public GameObject Ghost;
    //dialogue message to be shown
    string dialogue;
    bool dialogueStarted = false;
    public bool disableTorchCollider = false;
    public bool startPlayerHealth = false;
    //the number in the dialogue list that is to be shown
    int dialogueNo = 0;
    //checks if all dialogue is finished
    bool finishDialogue = false;

    //the list of all dialogue messages to be shown to the player
    [TextArea]
    public List<string> dialogueList;
    //text object that dialogue is shown in
    Text txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       txt = GetComponentInChildren<Text>(true);
    }

    void OnEnable()
    {
        //sets dialogue to current dialogue number in list
        dialogue = dialogueList[dialogueNo];
    }

    // Update is called once per frame
    void Update()
    {   
        
        txt.text = dialogue;

        if (gameObject.activeInHierarchy)
        {
            CharacterSpeakingBox.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            

            if(dialogueNo <= dialogueList.Count)
            {
                //checks if dialogue has finished
                if(dialogueNo == dialogueList.Count-1)
                {
                    finishDialogue = true;
                    
                }
                else
                {
                    //updates dialogue to be shown
                    dialogueNo++;
                    dialogue = dialogueList[dialogueNo];
                }
                
            }
            //checks if dialogue should disappear
            if (dialogueStarted == false|| finishDialogue==true)
            {
                if (finishDialogue)
                {
                    Ghost.GetComponent<GhostColliderScript>().instructionsFinished();
                }
                HideDialogue();
                
            }
        }
    }

    //hides dialogue from screen
    void HideDialogue()
    {
        //runs if main dialogue sequence has not started
        if (dialogueStarted == false)
        {
            dialogueStarted = true;
        }
        //runs if all dialogue is finished
        else
        {
            disableTorchCollider = true;
            startPlayerHealth = true;
        }
        
        CharacterSpeakingBox.SetActive(false);
        gameObject.SetActive(false);
    }

}
