using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ARScene : MonoBehaviour
{
    void Start()
    {
        
    }

    public void GoMenu(int index)
    {
        GameControllerUi.Instance.LoadNewScene(index);
    }
}
