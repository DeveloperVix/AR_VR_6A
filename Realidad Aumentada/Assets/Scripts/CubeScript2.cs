using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript2 : MonoBehaviour
{
    public static CubeScript2 act2;

    public bool bandera2 = false;
    //public GameObject cube1;

    public void Start()
    {
        act2 = this;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("CilindroTag2"))
        {
            bandera2 = true;
            if(CubeScript1.act.bandera == true && bandera2 == true)
            {
                //Pasara al siguiente puzzle
                GameController.act.Puzzle4();
            }
            
        }
    }
}
