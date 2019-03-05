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
        SceneAndPanelController.Instance.LoadNewScene(index);
    }
    public void ExitApp()
    {
        SceneAndPanelController.Instance.ExitGame();
    }
}
