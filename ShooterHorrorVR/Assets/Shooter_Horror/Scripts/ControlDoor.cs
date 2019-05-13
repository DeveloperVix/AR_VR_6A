using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDoor : MonoBehaviour {

	Animator ctrlDoorAnimations;
	public GameObject lockDoor;

	bool isOpen = false;

	// Use this for initialization
	void Start () 
	{
		ctrlDoorAnimations = GetComponent<Animator>();	
	}
	
	public void WaitToOpen()
	{
		StartCoroutine(BehaviourDoor(1.1f));
	}

	IEnumerator BehaviourDoor(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		lockDoor.GetComponent<Collider>().enabled = false;
		
		isOpen = true;
		Debug.Log("Abro puerta");
		ctrlDoorAnimations.Play("MainDoorOpen");
		yield return new WaitForSeconds(5f);
		Debug.Log("Cierro puerta");
		isOpen = false;
		ctrlDoorAnimations.Play("MainDoorClose");
		lockDoor.GetComponent<Collider>().enabled = true;
	}

	public void CancelOpen()
	{
		if(!isOpen)
			StopAllCoroutines();
	}
}
