using UnityEngine;

public class FPSColliderScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject NormalHUD;
    public GameObject GameWonScreen;
    bool gameWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
          if(gameWon == true)
        {
            GameWonScreen.SetActive(true);
            NormalHUD.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerBed"){
            
            Debug.Log("Hit");
            other.gameObject.SetActive(false)  ;
            gameWon = true;
        } 

       
    
    }

    void Restart()
    {
        GameOverScreen.SetActive(false);
        GameWonScreen.SetActive(false);
        NormalHUD.SetActive(true);
    }
}
