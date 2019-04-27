using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Type of action/RotateObj", fileName = "RotateObj")]

public class RotateObject : Interactive
{
    public bool flag = false;
    public GameObject thisObj;

    public override void ExecuteAction()
    { 
        if (flag)
        {
            Debug.Log("hi " + thisObj.transform.rotation);
            //mono.GetComponent<MonoBehaviour>().
            thisObj.transform.Rotate(new Vector3(0, 0, 10));
        }
    }

    public override void Targeted()
    {
        flag = true;
    }

    public override void Untargeted()
    {
        flag = false;
    }
}
