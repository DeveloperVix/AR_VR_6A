using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public bool isActive = false;
	public GameObject midPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isActive)
		{
			transform.LookAt(midPoint.transform);	
		}
	}
}
