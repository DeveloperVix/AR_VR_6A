using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ARScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void GoMenu(int index){
	GameControl.Instance.LoadNewScene(index);
}
}
