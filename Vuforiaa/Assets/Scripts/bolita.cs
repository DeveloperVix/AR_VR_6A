using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolita : MonoBehaviour {

	void OnTriggerEnter(Collider coll) {
        if (coll.name == "Player")
        {
            Destroy(gameObject);
        }
            
	}
}
