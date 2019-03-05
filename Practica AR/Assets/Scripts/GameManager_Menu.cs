using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ButtonPlay(int index)
    {
        GameControllerUI.Instance.LoadNewScene(index);
    }

    public void QuitButton()
    {
        //Seguro quieres salir?
        //Guarda datos
        GameControllerUI.Instance.Exit();
    }
}
