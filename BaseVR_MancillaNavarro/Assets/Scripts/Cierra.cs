using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cierra : MonoBehaviour {
	public float rot;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, rot);
	}
	void OnTriggerEnter2D(Collider2D col)
	{

    }
}
