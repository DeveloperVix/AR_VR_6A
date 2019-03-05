using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameARScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoMenu(int index)
    {
        SceneAndPanelController.Instance.LoadNewScene(index);
    }
}
