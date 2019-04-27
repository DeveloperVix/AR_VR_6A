using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Type of action/Action", fileName = "Action_1")]

public abstract class Interactive : ScriptableObject, TargetActionInterface
{
    //public MonoBehaviour mono;
    public string actionName;

    ScriptableObject myScriptableObject;

    public abstract void ExecuteAction();

    public abstract void Targeted();
    public abstract void Untargeted();
}
