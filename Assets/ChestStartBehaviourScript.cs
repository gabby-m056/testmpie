using UnityEngine;

public class ChestStartBehaviourScript : MonoBehaviour
{
    public GameObject player;
    bool gameplayStarted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<bauScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       gameplayStarted = player.GetComponent<PlayerHealthScript>().enabled; 
    }

    void OnTriggerEnter()
    {
        
        Debug.Log("gameplay started" + gameplayStarted);
        if (gameplayStarted)
        {
           GetComponent<bauScript>().enabled = true; 
        }
        
    }
}
