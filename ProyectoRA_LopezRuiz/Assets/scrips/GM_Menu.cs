using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Menu : MonoBehaviour
{


    void Start()
    {
        
    }


    public void PlayButton(int index)
    {
        controller_ui.Instace.LoadNewScene(index);
    }

    public void ExitApp(int index)
    {
        //seguro quieres salir?
        //guarda datos

        controller_ui.Instace.BtnExit();
    }
}
