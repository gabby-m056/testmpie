using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HintUpdateScript : MonoBehaviour
{
    //hint message to be shown
    string hint;

    public GameObject hintTitle;
    
    //the list of all hint messages to be shown to the player
    [TextArea]
    public List<string> hintList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //shows hint title when hint box is enabled
    void OnEnable()
    {
       hintTitle.SetActive(true);
    }

    //hides hint title when hint box is disabled
    void OnDisable()
    {
        hintTitle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //shows hint message on HUD
        Text txt = GetComponentInChildren<Text>(true);
        txt.text = hint;
    }

    //clears hint box and sets it inactive
    public void ClearHint()
    {
        hint ="";
        gameObject.SetActive(false);
    }

    //changes hint message to indicate to player to open chest
    public void OpenChest()
    {
        hint = hintList[0];
    }

    //changes hint message to indicate to player to pick up key and pear
    public void PickUpItems()
    {
        hint = hintList[1];
    }

    //changes hint message to indicate to player to open door
    public void CanOpenDoor()
    {
        hint = hintList[3];
    }

    //changes hint message to indicate to player that they can't open door
    public void UnableOpenDoor()
    {
        hint = hintList[2];
    }
}
