using UnityEngine;
using System;

public class PlayerHealthScript : MonoBehaviour
{
    
    public GameObject GameOverScreen;
    public GameObject NormalHUD;
    public int playerHealth= 41;
    public int healthFromPear =5;
    public int intervalMilliseconds = 7000;
    private DateTime lastTrigger= DateTime.Now;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            DateTime msPassed = DateTime.Now;
            Debug.Log(msPassed);
            
            
            int elapsed = Convert.ToInt32((msPassed-lastTrigger).TotalMilliseconds);
            Debug.Log(elapsed);
            if (elapsed>=intervalMilliseconds)
            {
            
                //if 7 seconds have passed 1 health is taken off the player
                playerHealth--;
                lastTrigger = msPassed;
            }
        
        
        

        if (playerHealth == 0)
        {
            GameOverScreen.SetActive(true);
            GetComponent<CharacterController>().enabled= false;
            GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().enabled = false;
            //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Cursor-lockState.html#:~:text=A%20locked%20cursor%20is%20positioned,from%20interacting%20with%20UI%20elements.
            //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CursorLockMode.html
            Cursor.lockState = CursorLockMode.None;
        
            // This makes it visible again
            Cursor.visible = true;
            
            NormalHUD.SetActive(false);
            //GameOverScreen.GetComponent<GameOverScript>().GameIsOver();
            
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        bool canPickUp = NormalHUD.GetComponentInChildren<DialogueUpdateScript>(true).disableTorchCollider;
        if(other.gameObject.tag == "Pear"&& canPickUp)
        {
            playerHealth += healthFromPear;
           
            other.gameObject.SetActive(false);

            Debug.Log("CHANGEEEEE");
        }

        
    }
}
