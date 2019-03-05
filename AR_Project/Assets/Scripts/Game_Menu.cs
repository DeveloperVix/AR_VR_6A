using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayButtum(int index) // paso por referencia
    {
        GameControll.Instance.LoadNewScene(index);
    }

    public void ExitApp()
    {
        //seguro que quieres salir
        // guardar

        GameControll.Instance.ExitButt();
    }

}
