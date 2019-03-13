using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolitawin : bolita
{
    public GameObject win; 

    void OnTriggerEnter(Collider coll) {
        if (coll.tag.Equals("Player"))
        {
            win.SetActive(true);
        }
        if (coll.name == "Player")
        {
            Destroy(gameObject);
        }

    }
}
