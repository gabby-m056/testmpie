using UnityEngine;

public class FPSMovementScript : MonoBehaviour
{
    public Collider parentCollider;
    
    public GameObject GameOverScreen;
    public GameObject NormalHUD;
    public GameObject GameWonScreen;
    public GameObject DialogueBox;
    public GameObject CharacterSpeakingBox;
    public GameObject HintBox;
    public GameObject HintTitle;
    //health HUD
    public GameObject heartImage;
    public GameObject healthText;
    //audio slips of footsteps
    public AudioClip walk;
    public AudioClip jump;
    //bool to see if health points are enabled
    bool healthEnabled = false;
   
    Transform t;
    Vector3 prevPosition;
    AudioSource fs;
    CharacterController controller;
    bool canPlay = false;
    bool canJump = false;
    bool jumpAlreadyPlayed=false;
    bool isGroundedBefore = true;

    //bool to see if game has been won
    bool gameWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //populates gameobject components from FPcontroller
        fs = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        t = gameObject.transform;
        //assigns first previous position to starting position of player
        prevPosition = t.position;
        //starts/restarts first game mechanics
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        canJump = false;
        canPlay = false;
        /*
        * These lines of code are based upon syntax from the Unity Script Reference
        *
        * Author: Unity Technologies (author name unknown)
        * Location: https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CharacterController-isGrounded.html
        * Accessed: 20/01/2026
        */
        //checks if player has pressed space to activate jump and fires once before player being in the air
        if (Input.GetKeyDown(KeyCode.Space)&&controller.isGrounded)
        {
            
            jumpAlreadyPlayed = false;
            canJump = true;
            canPlay = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space)&&controller.isGrounded==false&&isGroundedBefore==true)
        {
            jumpAlreadyPlayed = false;
            canJump = true;
            canPlay = true;
        }
        //checks if player is mid jump
        else if (controller.isGrounded == false && isGroundedBefore == false)
        {

            canPlay = false;
        }
        //checks if player is walking/moving or still
        else
        {
            
            canPlay = CheckToPlayFootsteps();
        }

      
        //checks if a sound is to be played
        if (canPlay)
        {
            
            /**
            * This script is based upon 2 examples from the Unity Script Reference
            *
            * Example 1:
            * Author: Unity Technologies (author name unknown)
            * Location: //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/AudioSource.PlayOneShot.html
            * Accessed: 20/01/2026
            *
            * Example 2:
            * Author: Unity Technologies (author name unknown)
            * Location: https://docs.unity3d.com/6000.3/Documentation/ScriptReference/AudioSource-isPlaying.html
            * Accessed: 20/01/2026
            */
            //checks if a footsteps sound is already playing to prevent multiple footsteps sound at same time
            if(fs.isPlaying == false)
            {
                //checks if player has jumped
                if (canJump)
                {   //checks if jump has been played
                    if (!jumpAlreadyPlayed)
                    {    //plays jump sound once
                        fs.PlayOneShot(jump,0.8f);
                        //once jump has played this is set to true - prevents it being played multiple times if player is jumping
                        jumpAlreadyPlayed = true; 
                    }
                    
                }
                else
                {   
                    //plays walk sound once
                    fs.PlayOneShot(walk,0.8f);
                    //this is set to false as previous sound was player walking
                    jumpAlreadyPlayed = false;
                }
                
            }
            else
            {
                //checks if player has jumped and the jump sound hasn't been played yet in that jump
                if (canJump && !jumpAlreadyPlayed)
                {
                    //stops current sound if player starts to jump
                    fs.Stop();
                    //plays jump sound once
                    fs.PlayOneShot(jump,0.8f);
                    //once jump has played this is set to true - prevents it being played multiple times if player is jumping
                    jumpAlreadyPlayed = true;
                }
            }
            
        }

        if (healthEnabled == false)
        {
            //checks if dialogue has finished and allows player health to start
            if(DialogueBox.GetComponent<DialogueUpdateScript>().startPlayerHealth == true)
            {
                //enables and shows player health on HUD
                GetComponent<PlayerHealthScript>().enabled = true;
                healthText.SetActive(true);
                heartImage.SetActive(true);
                healthText.GetComponent<TextUpdateScript>().enabled = true;
                healthEnabled = true;
            }
        }
        //checks if player has won game
        if(gameWon == true)
        {
            ////game won screen is shown and fp controller disabled
            GameWonScreen.SetActive(true);
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
        //sets bool so it can be compared in the next frame
        isGroundedBefore = controller.isGrounded;

    }

    void OnTriggerEnter(Collider other)
    {
        //checks if player collides with bed
        if(other.gameObject.name == "PlayerBed")
        {
            //hides bed
            other.gameObject.SetActive(false);
            //player wins
            gameWon = true;
        } 

    }

    void Restart()
    {
        //hides game won/over screens
        GameOverScreen.SetActive(false);
        GameWonScreen.SetActive(false);
        //disables health
        GetComponent<PlayerHealthScript>().enabled = false;
        //enables HUD parent object
        NormalHUD.SetActive(true);
        //hides health HUD
        healthText.SetActive(false);
        heartImage.SetActive(false);
        //disables health HUD text updating
        healthText.GetComponent<TextUpdateScript>().enabled = false;
        //hides dialogue HUD
        DialogueBox.SetActive(false);
        CharacterSpeakingBox.SetActive(false);
        //hides hint HUD
        HintBox.SetActive(false);
        HintTitle.SetActive(false);
    }

    //checks if character is walking so footsteps walk sound can be played
    bool CheckToPlayFootsteps()
    {
        bool canPlay;
        //current position of player
        Vector3 currentPosition = t.position;
        //checks current position against position in previous frame/frame that method last was called
        if(currentPosition == prevPosition)
        {
            canPlay = false;
        }
        else
        {
            canPlay = true;
        }
        //sets previous position so it can be checked against in the next frame/method call
        prevPosition = currentPosition;
        return canPlay;
    }
}
