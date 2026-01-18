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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //https://docs.unity3d.com/ScriptReference/Component.GetComponentInChildren.html
        Text txt = GetComponentInChildren<Text>(true);
        txt.text = dialogue;

        if (gameObject.activeInHierarchy)
        {
            CharacterSpeakingBox.SetActive(true);
        }

        if (dialogueStarted == false && gameObject.activeInHierarchy)
        {
            dialogueStarted = true;
            dialogue = dialogueList[0];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("slay");
                dialogueToContinue = true;
                gameObject.SetActive(false);
            }
        }

        if(dialogueStarted == true && gameObject.activeInHierarchy)
        {
            ContinueDialogue();
        }

        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            enterPressed = true;
        }*/
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
