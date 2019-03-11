using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiiButton : MonoBehaviour
{
    public bool isCorrect;
    bool selected = false;
    MeshRenderer meshRender;
	// Use this for initialization
	void Start ()
    {
        meshRender = GetComponent<MeshRenderer>();
        
	}

    public void ButtonReset()
    {
        selected = false;
        meshRender.material = GM_ARScene.act.miiNormal;
    }

    private void OnMouseDown()
    {
        if (GM_ARScene.act.objWin.activeInHierarchy) return;
        meshRender.material = GM_ARScene.act.miiSelected;
        if (isCorrect) GM_ARScene.act.miiCorrect++;
        else GM_ARScene.act.miiForceFail = true;
    }
}
