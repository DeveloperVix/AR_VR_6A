using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractive : MonoBehaviour
{
    public Interactive[] interactions;
    public bool detected;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < interactions.Length; i++)
        {
            if (detected) interactions[i].OnSeen(gameObject);
            else interactions[i].OnNotSeen(gameObject);
        }   
    }

    public void Detectado(bool value)
    {
        detected = value;
    }
}
