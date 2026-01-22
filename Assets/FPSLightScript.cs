using UnityEngine;

public class FPSLightScript : MonoBehaviour
{
    public Light playerflashlight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //toggles flashlight
        if(Input.GetKeyDown(KeyCode.F)){
            playerflashlight.enabled = !playerflashlight.enabled;
        }
    }

    
}
