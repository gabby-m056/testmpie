using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueUpdateScript : MonoBehaviour
{
    public GameObject CharacterSpeakingBox;
    string dialogue;
    bool dialogueStarted = false;
    bool dialogueToContinue = false;

    bool enterPressed = false;

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
        if(dialogueStarted == false)
        {
            dialogue = dialogueList[0];
        }

        if (dialogueStarted && dialogueToContinue)
        {
            Debug.Log("continue dialogue onenable");
        }
        
        
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
            if (dialogueStarted == false)
            {
                HideDialogue();
            }
            if(dialogueStarted && dialogueToContinue){
                Debug.Log("continue dialogue enter");
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
        Debug.Log("slay");
        if (dialogueStarted == false)
        {
            dialogueStarted = true;
            dialogueToContinue = true;
        }
        gameObject.SetActive(false);
        CharacterSpeakingBox.SetActive(false);
    }

    void OnDisable()
    {
        
    }

    void ContinueDialogue()
    {
        int i=1;
        Debug.Log("reach");
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
