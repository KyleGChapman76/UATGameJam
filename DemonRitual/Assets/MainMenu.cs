using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public string level1Name;

    public void BeginGame ()
    {
        Application.LoadLevel(level1Name);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }
}
