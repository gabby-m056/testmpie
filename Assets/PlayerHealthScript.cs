using UnityEngine;
using System;

public class PlayerHealthScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject NormalHUD;
    public int playerHealth= 25;
    public int healthFromPear =3;
    public int intervalMilliseconds = 7000;
    private DateTime lastTrigger= DateTime.Now;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //https://learn.microsoft.com/en-us/dotnet/api/system.environment.tickcount?view=net-10.0
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
            NormalHUD.SetActive(false);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pear")
        {
            playerHealth += healthFromPear;
           
            other.gameObject.SetActive(false);

            Debug.Log("CHANGEEEEE");
        }
    }
}
