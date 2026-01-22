using UnityEngine;
using UnityEngine.UI;

public class TextUpdateScript : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //gets health value from player health script
        int healthValue = player.GetComponent<PlayerHealthScript>().playerHealth;
        //shows health value on HUD 
        Text txt =  GetComponent<Text>();
        txt.text = healthValue.ToString();
    }
}
