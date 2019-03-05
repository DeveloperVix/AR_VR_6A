using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PlayButton(int index)
    {
        GameControlUI.Instance.LoadNewScene(index);

    }
    public void ExitApp()
    {
        //Seguro Quieres Salir?
        //Guardar Datos

        GameControlUI.Instance.BtnExit();

    }
}
