using UnityEngine;
using System;

public class PlayerHealthScript : MonoBehaviour
{
    
    public GameObject GameOverScreen;
    public GameObject NormalHUD;
    public int playerHealth= 50;
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
            Cursor.lockState = CursorLockMode.None;
        
            // This makes it visible again
            Cursor.visible = true;
            
            NormalHUD.SetActive(false);
            //GameOverScreen.GetComponent<GameOverScript>().GameIsOver();
            
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameObject.name);
        if(other.gameObject.tag == "Pear")
        {
            playerHealth += healthFromPear;
           
            other.gameObject.SetActive(false);

            Debug.Log("CHANGEEEEE");
        }

        
    }
}
