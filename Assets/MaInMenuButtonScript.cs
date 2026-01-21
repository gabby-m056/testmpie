using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MaInMenuButtonScript : MonoBehaviour
{
    public void StartClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    
}
