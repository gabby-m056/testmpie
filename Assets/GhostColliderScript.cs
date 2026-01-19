using UnityEngine;

public class GhostColliderScript : MonoBehaviour
{
    //This script's purpose is to fire the SECOND set of dialogue only - first set is fired by ghost triggering torch collider
    public Collider parentCollider;
    public Collider childCollider;
    
    public GameObject DialogueBox;
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
       
        if(other.gameObject.name == "FirstPersonController"&& other != childCollider && other == parentCollider)
        {
            Debug.Log("triggercontinue");
            DialogueBox.SetActive(true);
        }
    }
}
