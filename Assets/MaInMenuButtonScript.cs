using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MaInMenuButtonScript : MonoBehaviour
{
    public void StartClicked()
    {
        /*
            I used this documentation to help me write the following line of code

            Author: Unity Technologies (author name unknown)
            Location : https://docs.unity3d.com/6000.3/Documentation/ScriptReference/SceneManagement.SceneManager.LoadScene.html
            Accessed : 19/01/2026
        */
        SceneManager.LoadScene("Game");
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    
}
