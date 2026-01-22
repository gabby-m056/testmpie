using UnityEngine;

public class TorchColliderScript : MonoBehaviour
{
    public GameObject DialogueBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueBox.GetComponent<DialogueUpdateScript>().disableTorchCollider == true)
        {
            GetComponent<SphereCollider>().enabled=false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //fires first set of dialogue
        if(other.gameObject.name == "GhostNPCTrigger"){
            
            DialogueBox.SetActive(true);
        } 
        

    }
}
