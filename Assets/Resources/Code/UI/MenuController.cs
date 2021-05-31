using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void LoadMenuScene(string levelSelectionMenuName)
    {
        SceneManager.LoadScene(levelSelectionMenuName, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }

    public void DisplayPopUp()
    {

    }

    public void DisplayLevelSelectionMenu()
    {

    }

}