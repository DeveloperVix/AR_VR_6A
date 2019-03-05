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
    void Update()
    {
        
    }

    public void PlayButton(int index)
    {
        GameControllerUI.Instance.LoadNewScene(index);
    }

    public void ExitApp()
    {
        //Seguro que quieres salir?
        //Guarda datos

        GameControllerUI.Instance.BtnExit();
    }
}
