using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonRestartScript : MonoBehaviour
{
    
    public void ButtonIsClicked()
    {
        /*
            This line of code is based upon a solution on Stack Overflow

            Author: Joseph Hodes (User on Stack Overflow)
            Location: https://stackoverflow.com/questions/65851443/how-do-i-restart-the-scene-that-im-currently-in-through-script-in-unity-2d-so
            Accessed: 18/01/2026
        */
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
