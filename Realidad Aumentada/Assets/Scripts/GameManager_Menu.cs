using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayButton(int index)
    {
        GameControlerUI.Instance.LoadNewScene(index);//paso por referencia
    }

    public void ExitApp()
    {
        //Seguro que queires salir?
        //guardar datos

        GameControlerUI.Instance.BtnExit();
    }
}
