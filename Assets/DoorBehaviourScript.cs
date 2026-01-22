using UnityEngine;

public class DoorBehaviourScript : MonoBehaviour
{
    public GameObject key;
    public GameObject hintBox;
    Vector3 defaultPosition = new Vector3 (424.6f, 0.876f, 375.953f);
    Vector3 rotatedPosition = new Vector3 (423.8f, 0.876f, 375.953f);

    bool doorToggled = false;
    bool doorOpened = false;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if key is picked up & O is pressed so door can open
        if (Input.GetKeyDown(KeyCode.O)&&key.gameObject.activeSelf==false)
        {
            doorToggled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        doorOpened = false;
        if(doorOpened == false)
        {
            hintBox.SetActive(true);
            //Shows appropriate hint for opening door
            if(key.gameObject.activeSelf == false)
            {
                hintBox.GetComponent<HintUpdateScript>().CanOpenDoor();
            }
            else
            {
                hintBox.GetComponent<HintUpdateScript>().UnableOpenDoor();
            }
            
        }


        Transform t = gameObject.transform;
       //checks if player is triggering door collider
        if (other.gameObject.name==player.gameObject.name)
        {
            if (doorToggled)
            {
                doorOpened = !doorOpened;

                //if door is opened - move door so it can be opened and player can walk through it
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

    void OnTriggerExit(Collider other)
    {
        //clears hintbox
        hintBox.GetComponent<HintUpdateScript>().ClearHint();
    }
}
