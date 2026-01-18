using UnityEngine;

public class DoorBehaviourScript : MonoBehaviour
{
    public GameObject key;
    Vector3 defaultPosition = new Vector3 (424.6f, 0.876f, 375.953f);
    Vector3 rotatedPosition = new Vector3 (423.8f, 0.876f, 375.953f);

    bool doorToggled = false;
    public GameObject player;
     //Quaternion.Euler(0.0f, 90.0f, 0.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)&&key.gameObject.activeSelf==false)
        {
            doorToggled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        bool doorOpened = false;
        Transform t = gameObject.transform;
        //Input.GetKeyDown(KeyCode.O)&& 
        if (other.gameObject.name==player.gameObject.name )
        {
            Debug.Log("reach");
            if (doorToggled)
            {
                Debug.Log("reach2");
                doorOpened = !doorOpened;

                if (doorOpened)
                {
                    t.position = rotatedPosition;
                    t.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                }
                else
                {
                    t.position = defaultPosition;
                    t.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                }
            }

            
        }
        
    }
}
