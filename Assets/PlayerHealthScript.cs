using UnityEngine;
using System;

public class PlayerHealthScript : MonoBehaviour
{
    
    public GameObject GameOverScreen;
    public GameObject NormalHUD;
    // value of players health
    public int playerHealth= 41;
    //amount of health a player gets from eating pear
    public int healthFromPear =5;
    //how long it takes in ms for 1 health to deplete
    public int intervalMilliseconds = 7000;
    //stores the last millisecond that players health depleted at
    private DateTime lastTrigger= DateTime.Now;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /* I based the code for this millisecond countdown timer on an example written in JavaScript from forum.processing.org *
        Author: User @amnon.owed on forum.processing.org
        URL: https://forum.processing.org/one/topic/how-to-perform-an-action-every-x-seconds-time-delays#25080000001539463.html
        Accessed: 27/12/2025
       */
       //This was the algorithm i used in a previous project so this time I used it and wrote the code equivalent in C#
        DateTime msPassed = DateTime.Now;
        int elapsed = Convert.ToInt32((msPassed-lastTrigger).TotalMilliseconds);
      
        if (elapsed>=intervalMilliseconds)
        {
                
            //if 7 seconds have passed 1 health is taken off the player
            playerHealth--;
            lastTrigger = msPassed;
        }
        
        if (playerHealth == 0)
        {
            //game over screen is shown to player and fp controller disabled
            GameOverScreen.SetActive(true);
            GetComponent<CharacterController>().enabled= false;
            GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().enabled = false;

            /*
                I used this documentation to help me write the following line of code

                Author: Unity Technologies (author name unknown)
                Location : https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CursorLockMode.html
                Accessed : 19/01/2026
            */
            Cursor.lockState = CursorLockMode.None;
        
            // This makes the cursor visible again
            Cursor.visible = true;
            //hides HUD
            NormalHUD.SetActive(false);
            
            
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        //bool checks if torch collider is disabled and if it returns true the player can pick up the pear
        bool canPickUp = NormalHUD.GetComponentInChildren<DialogueUpdateScript>(true).disableTorchCollider;
        //checks if player has collided with a pear and if they can pick it up
        if(other.gameObject.tag == "Pear"&& canPickUp)
        {
            //adds health to player
            playerHealth += healthFromPear;
           //hides pear
            other.gameObject.SetActive(false);
        }

        
    }
}
