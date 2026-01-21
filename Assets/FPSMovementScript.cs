using UnityEngine;

public class FPSMovementScript : MonoBehaviour
{
    public Collider parentCollider;
    //public C parentCollider;
    
    public GameObject GameOverScreen;
    public GameObject NormalHUD;
    public GameObject GameWonScreen;
    public GameObject DialogueBox;
    public GameObject CharacterSpeakingBox;
    public GameObject HintBox;
    public GameObject HintTitle;

    public GameObject heartImage;
    public GameObject healthText;

    public AudioClip walk;
    public AudioClip jump;
    bool healthEnabled = false;
   
    Transform t;
    Vector3 prevPosition;
    AudioSource fs;
    CharacterController controller;
    bool canPlay = false;
    bool canJump = false;
    bool jumpAlreadyPlayed=false;
    bool isGroundedBefore = false;

    bool gameWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fs = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        t = gameObject.transform;
        prevPosition = t.position;
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        canJump = false;
        canPlay = false;

       // jumpAlreadyPlayed = false;
        /**
            * This line of code is based upon syntax from the Unity Script Reference
            *
            * Example 1:
            * Author: Unity Technologies (author name unknown)
            * Location: https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CharacterController-isGrounded.html
            * Accessed: 20/01/2026
        */
        
        //if(controller.isGrounded == false/*line of code reference ends*/) 
        //{

        //check if grounded BEFORE pressing space
        
        if (Input.GetKeyDown(KeyCode.Space)&&controller.isGrounded==false&&isGroundedBefore==true)
        {
            Debug.Log("Space Pressed");
            
            jumpAlreadyPlayed = false;
            canJump = true;
            canPlay = true;
        }
        else if (controller.isGrounded == false && isGroundedBefore == false)
        {
            canPlay = false;
        }
            
        
        else
        {
            canPlay = CheckToPlayFootsteps();
        }

      

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
            
            if(fs.isPlaying == false)
            {
                if (canJump)
                {
                    Debug.Log("Called");
                    if (!jumpAlreadyPlayed)
                    {
                        fs.PlayOneShot(jump,0.8f);
                        
                        jumpAlreadyPlayed = true; 
                    }
                    
                }
                else
                {   
                    fs.PlayOneShot(walk,0.8f);
                    jumpAlreadyPlayed = false;
                }
                
            }
            else
            {
                if (canJump && !jumpAlreadyPlayed)
                {
                    fs.Stop();
                    fs.PlayOneShot(jump,0.8f);
                    jumpAlreadyPlayed = true;
                }
            }
            
        }

        if (healthEnabled == false)
        {
            
            if(DialogueBox.GetComponent<DialogueUpdateScript>().startPlayerHealth == true)
            {
                Debug.Log("enable health");
                GetComponent<PlayerHealthScript>().enabled = true;
                healthText.SetActive(true);
                heartImage.SetActive(true);
                healthText.GetComponent<TextUpdateScript>().enabled = true;
                healthEnabled = true;
            }
        }

          if(gameWon == true)
        {
            GameWonScreen.SetActive(true);
            GetComponent<CharacterController>().enabled= false;
            GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().enabled = false;
            //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Cursor-lockState.html#:~:text=A%20locked%20cursor%20is%20positioned,from%20interacting%20with%20UI%20elements.
            //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CursorLockMode.html
            Cursor.lockState = CursorLockMode.None;
        
            // This makes it visible again
            Cursor.visible = true;
            NormalHUD.SetActive(false);
        }
        isGroundedBefore = controller.isGrounded;

    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "PlayerBed"){
            
            
            other.gameObject.SetActive(false);
            gameWon = true;
        } 

       if(other.gameObject.name == "key")
        {
            other.gameObject.SetActive(false);
        }

        
    
    }

    void Restart()
    {
        GameOverScreen.SetActive(false);
        GameWonScreen.SetActive(false);
        GetComponent<PlayerHealthScript>().enabled = false;
        
        NormalHUD.SetActive(true);
        healthText.SetActive(false);
        heartImage.SetActive(false);
        healthText.GetComponent<TextUpdateScript>().enabled = false;
        DialogueBox.SetActive(false);
        CharacterSpeakingBox.SetActive(false);
        HintBox.SetActive(false);
        HintTitle.SetActive(false);
    }

    bool CheckToPlayFootsteps()
    {
        bool canPlay;
       
        
        Vector3 currentPosition = t.position;
        //Debug.Log("prev "+prevPosition);
        if(currentPosition == prevPosition)
        {
            canPlay = false;
        }
        else
        {
            canPlay = true;
        }
        prevPosition = currentPosition;
        return canPlay;
            
        
    }
}
