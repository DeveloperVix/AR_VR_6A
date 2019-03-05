using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayButton(int index)
    {
        GameControllerUI.Instance.LoadNewScene(index);  //se resetea la referencia al index 
    }

    public void ExitApp(int index)
    {
        //vamo a salirnos ?
        //ya guardo?

        GameControllerUI.Instance.BtnExit();  //se resetea la referencia al index 
    }
}
