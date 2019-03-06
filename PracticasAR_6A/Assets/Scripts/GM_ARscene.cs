using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ARscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoMenu(int index)
    {
        GameControlerUI.Instance.LoadNewScene(index);

    }
}
