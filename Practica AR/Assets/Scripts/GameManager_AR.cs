using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_AR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoMenu(int index)
    {
        GameControllerUI.Instance.LoadNewScene(index);
    }

}
