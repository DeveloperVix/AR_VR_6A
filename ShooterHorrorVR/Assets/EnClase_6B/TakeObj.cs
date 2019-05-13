using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObj : MonoBehaviour 
{

	public GameObject playerHand;
	GameObject objTemp;

	public void TakeObjMethod(GameObject theObj)
	{
		objTemp = theObj;
		Invoke("WaitTime", 1f);
	}

	public void WaitTime()
	{
		Debug.Log("Tomo el objeto");
		objTemp.transform.SetParent(playerHand.transform);
		objTemp.transform.SetPositionAndRotation(playerHand.transform.position, playerHand.transform.rotation);
	
		if(objTemp.CompareTag("Weapon"))
		{
			objTemp.GetComponent<Collider>().enabled = false;
		}
	}

	public void ActionFinished()
	{
		Debug.Log("Solto obj o tomo el arma o tomo el objeto");
		CancelInvoke("WaitTime");
		objTemp = null;
	}
}
