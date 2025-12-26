using UnityEngine;

public class FPSColliderScript : MonoBehaviour
{
    //public int healthPlayer = 20;
    //public int healthPear =3;
    bool gameWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerBed"){
            
            Debug.Log("Hit");
            other.gameObject.SetActive(false)  ;
            gameWon = true;
        } 

       
    
    }
}
