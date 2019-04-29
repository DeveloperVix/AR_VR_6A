using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjVR : MonoBehaviour
{
    public Scriptables[] scriptable;
    public bool detected;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scriptable.Length; i++)
        {
            if (detected) scriptable[i].OnSeen(gameObject);
            else scriptable[i].OnNotSeen(gameObject);
        }
    }

    public void Detectado(bool value)
    {
        detected = value;
    }
}
