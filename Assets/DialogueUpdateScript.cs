using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueUpdateScript : MonoBehaviour
{
    public GameObject CharacterSpeakingBox;
    public GameObject Ghost;
    string dialogue;
    bool dialogueStarted = false;
    bool dialogueToContinue = false;
    public bool disableTorchCollider = false;
    public bool startPlayerHealth = false;
    int dialogueNo = 0;
    bool finishDialogue = false;

    [TextArea]
    public List<string> dialogueList;
    Text txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       txt = GetComponentInChildren<Text>(true);
    }

    void OnEnable()
    {
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
                if(dialogueNo == dialogueList.Count-1)
                {
                    finishDialogue = true;
                    
                }
                else
                {
                    dialogueNo++;
                    dialogue = dialogueList[dialogueNo];
                }
                
            }

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

    void HideDialogue()
    {
        if (dialogueStarted == false)
        {
            dialogueStarted = true;
            dialogueToContinue = true;
        }
        else
        {
            disableTorchCollider = true;
            startPlayerHealth = true;
        }
        
        CharacterSpeakingBox.SetActive(false);
        gameObject.SetActive(false);
    }

}
