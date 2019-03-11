using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public bool toco = false;
    public bool puede_moverse = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Finish"))
        {
            toco = true;
        }
    }


}
