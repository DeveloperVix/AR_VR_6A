using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript1 : MonoBehaviour
{
    public static CubeScript1 act;
    public bool bandera = false;

    public void Start()
    {
        act = this;
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("CilindroTag"))
        {
            bandera = true;                       //Ya me tocaste
            if (CubeScript2.act2.bandera2 == true && bandera == true)
            {
                //Pasamos al siguiente puzzle
                GameController.act.Puzzle4();
            }
        }
    }
}
