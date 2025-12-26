using UnityEngine;

public class TextUpdateScript : MonoBehaviour
{
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int healthValue = Player.GetComponent<PlayerHealth>().health;
        Text txt =  GetComponent<Text>();
        txt.Text = healthValue.ToString();
    }
}
