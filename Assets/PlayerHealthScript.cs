using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int playerHealth= 20;
    public int healthFromPear =3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        System.Threading.Thread.Sleep(5000);
        playerHealth--;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pear")
        {
            playerHealth += healthFromPear;
           
            other.gameObject.SetActive(false);

            Debug.Log("CHANGEEEEE");
        }
    }
}
