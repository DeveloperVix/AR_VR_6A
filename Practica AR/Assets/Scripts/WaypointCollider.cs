using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollider : MonoBehaviour
{
    Raycast raykst;
    
    void Start()
    {
        raykst = GameObject.Find("ARCamera").GetComponent<Raycast>();
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("TOCARON LOS WAYPOINTS");
        if (col.tag.Equals("capsula"))
        {
            Debug.Log("CHOCARON TODOS");
            //Destroy(col.gameObject);
            Debug.Log("HAZ GANADO :'D");
            raykst.ganar.SetActive(true);
        }
    }
}
