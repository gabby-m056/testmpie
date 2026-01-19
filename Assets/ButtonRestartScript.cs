using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonRestartScript : MonoBehaviour
{
    public Button btn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ButtonIsClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonIsClicked()
    {
        Application.LoadLevel(0);
    }
}
