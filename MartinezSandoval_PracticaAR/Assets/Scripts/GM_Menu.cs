using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayButton(string scene)
    {
        GameController.act.LoadNewScene(scene);
    }

    void ExitApp()
    {
        GameController.act.ButtonExit();
    }
}
