using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class raycal : MonoBehaviour {

    public float raylength;
    public LayerMask layermask;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit, raylength, layermask))
            {
                Debug.Log(hit.collider.name);
            }
        }
	}
}
