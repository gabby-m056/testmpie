using UnityEngine;

public class FootstepsScript : MonoBehaviour
{
    public AudioSource player;
    public AudioSource tempSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.Play();
            tempSound.PlayDelayed(0.5f);
        }
    }
}
