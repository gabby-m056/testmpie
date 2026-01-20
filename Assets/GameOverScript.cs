using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
    {
        Debug.Log("GOScript");
        GameIsOver();
    }

    // Update is called once per frame
    void Update()
    {

        GameIsOver();
    }

    public void GameIsOver()
    {
        Debug.Log("gameover");
    }
}
