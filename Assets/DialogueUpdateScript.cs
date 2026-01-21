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

    //called when component is first enabled - https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.OnEnable.html
    void OnEnable()
    {
        /*if(dialogueStarted == false)
        {
            dialogue = dialogueList[0];
        }*/

        dialogue = dialogueList[dialogueNo];

        /*if (dialogueStarted && dialogueToContinue)
        {
            dialogue = dialogue
        }*/
        
        
    }

    // Update is called once per frame
    void Update()
    {   //https://docs.unity3d.com/ScriptReference/Component.GetComponentInChildren.html
        
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
                    Debug.Log("Dialogue count : "+ dialogueNo);
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

       /* if (dialogueStarted == false && gameObject.activeInHierarchy)
        {
            
           
        }*/

        if(dialogueStarted == true && gameObject.activeInHierarchy)
        {
            ContinueDialogue();
        }

        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            enterPressed = true;
        }*/
    }

    void ShowDialogue()
    {
        
    }

    void HideDialogue()
    {
        //Debug.Log("slay");
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

    void OnDisable()
    {
    }

    void ContinueDialogue()
    {
        //int i=1;
        //Debug.Log("reach");
        /*while (i<dialogueList.Count - 1)
        {
            dialogue = dialogueList[i];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                i++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.SetActive(false);
        }*/

        

        
        
    }
}
