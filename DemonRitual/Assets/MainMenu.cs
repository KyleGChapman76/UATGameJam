using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string level1Name;

    public void BeginGame ()
    {
        SceneManager.LoadScene(level1Name);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }
}
