using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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
        //https://stackoverflow.com/questions/65851443/how-do-i-restart-the-scene-that-im-currently-in-through-script-in-unity-2d-so
        //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/SceneManagement.SceneManager.GetSceneByName.html
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
