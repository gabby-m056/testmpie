using UnityEngine;

public class FPSColliderScript : MonoBehaviour
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
    bool healthEnabled = false;
    public AudioClip walkSound1;
    public AudioClip walkSound2;

    bool gameWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {

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
            NormalHUD.SetActive(false);
        }

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
}
