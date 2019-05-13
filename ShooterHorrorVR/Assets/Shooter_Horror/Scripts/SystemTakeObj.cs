using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemTakeObj : MonoBehaviour 
{
	public GameObject handPlayer;
	GameObject objTemp;
	public void TakingObj(GameObject theObj)
	{
		objTemp = theObj;
		Invoke("WaitTime", 1.4f);
	}

	public void WaitTime()
	{
		Debug.Log("Tome el objeto");
		objTemp.transform.SetParent(handPlayer.transform);
		objTemp.transform.SetPositionAndRotation(handPlayer.transform.position, handPlayer.transform.rotation);

		if(objTemp.GetComponent<ObjInteractivo>().currentType == ObjInteractivo.TypeObj.Weapon)
		{
			objTemp.GetComponent<Collider>().enabled = false;
			objTemp.GetComponent<Weapon>().isActive = true;
			Tutorial.Instance.StartSecondInstructions();
		}
	}

	public void ActionFinished()
	{
		Debug.Log("Solte objeto o tome el arma o deje de verlo");
		CancelInvoke("WaitTime");
		objTemp = null;
	}
}
