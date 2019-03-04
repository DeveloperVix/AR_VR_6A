using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndPanelController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    public void PanelPlay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Puzzle");
    }
}
