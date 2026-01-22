using UnityEngine;

public class GhostColliderScript : MonoBehaviour
{
    //This script's purpose is to fire the SECOND set of dialogue only - first set is fired by ghost triggering torch collider
    //Collider on parent object
    public Collider parentCollider;
    //collider on child object
    public Collider childCollider;
    
    public GameObject DialogueBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //all states that ghost has
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
        //Checks if state is wandering and if so makes ghost randomly wander around map
        if (agent.remainingDistance <= 1.0f&&state == GhostState.WANDERING)
        {
            float x = Random.Range(-20.0f,200.0f);
            float z =Random.Range(-20.0f,200.0f);

            agent.destination = new Vector3(x,0.0f,z);
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        //fires second/main set of dialogue
        if(state == GhostState.GIVEINSTRUCTIONS)
        {
            //checks if collider that is triggering ghost is the parent collider on actual controller before enabling dialogue
            //child collider is the torch collider
            if(other.gameObject.name == "FirstPersonController"&& other != childCollider && other == parentCollider)
            {
                DialogueBox.SetActive(true);
            }
        }
    }

    public void instructionsFinished()
    {
        //when instructions dialogue has finished, ghost changes to wandering state
        state = GhostState.WANDERING;
    }
}
