using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueUpdateScript : MonoBehaviour
{
    public GameObject CharacterSpeakingBox;
    string dialogue;
    bool dialogueStarted = false;

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
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        dialogue = dialogueList[0];
    }
}
