using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag.Equals("SphereTag"))
        {
            GameController.act.Puzzle2();
            Destroy(this.gameObject);
        }
    }
}
