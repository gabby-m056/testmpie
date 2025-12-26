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
        
        int healthValue = player.GetComponent<PlayerHealthScript>().playerHealth;
        //Debug.Log(healthValue);
        Text txt =  GetComponent<Text>();
        txt.text = healthValue.ToString();
    }
}
