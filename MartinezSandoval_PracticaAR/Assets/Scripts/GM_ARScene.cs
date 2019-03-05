using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ARScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoMenu(string scene)
    {
        GameController.act.LoadNewScene(scene);
    }
}
