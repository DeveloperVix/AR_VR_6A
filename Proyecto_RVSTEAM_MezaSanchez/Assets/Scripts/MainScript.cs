using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{

    public List<Interactive> actions;

    void Start()
    {
        
        //actions = new List<Interactive>();
    }

    void Update()
    {
        foreach (Interactive count in actions)
        {
            count.ExecuteAction();
        }
    }

    public void ExecuteActions()
    {
        foreach(Interactive count in actions)
        {
            count.Targeted();
        }
    }

    public void StopActions()
    {
        foreach (Interactive count in actions)
        {
            count.Untargeted();
        }
    }
}
