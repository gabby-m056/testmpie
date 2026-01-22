using UnityEngine;

public class GhostColliderScript : MonoBehaviour
{
    //This script's purpose is to fire the SECOND set of dialogue only - first set is fired by ghost triggering torch collider
    public Collider parentCollider;
    public Collider childCollider;
    
    public GameObject DialogueBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    enum GhostState
    {
        GIVEINSTRUCTIONS,
        WANDERING
    };

    GhostState state = GhostState.GIVEINSTRUCTIONS;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (agent.remainingDistance <= 1.0f&&state == GhostState.WANDERING)
        {
            float x = Random.Range(-20.0f,200.0f);
            float z =Random.Range(-20.0f,200.0f);

            agent.destination = new Vector3(x,0.0f,z);
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if(state == GhostState.GIVEINSTRUCTIONS)
        {
            if(other.gameObject.name == "FirstPersonController"&& other != childCollider && other == parentCollider)
        {
            Debug.Log("triggercontinue");
            DialogueBox.SetActive(true);
        }
        }
       
        
    }

    public void instructionsFinished()
    {
        state = GhostState.WANDERING;
    }
}
