using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
	public GameObject fadeObj;

	[TextArea (3, 10)]
	public string[] textTuto;
	public Sprite[] imgTuto;
	public Image imgUI_Tuto;

	public bool onlyOnce = false;

	private static Tutorial instance;
    public static Tutorial Instance {get{return instance;}}
	
	public GameObject lockMainDoor;

    // Use this for initialization
    void Start () {
		if(instance == null)
		{
			instance = this;
		}
		Invoke ("FadeObj", 1.1f);
	}

	void FadeObj () {
		Debug.Log ("Quito fade");
		fadeObj.SetActive (false);
		StartCoroutine (TutorialInstructions ());
	}

	IEnumerator TutorialInstructions () {
		int totalText = 0;
		ActiveEvent.Instance.ShowNoticeImg (0);
		while (totalText < textTuto.Length-1) 
		{
			if (totalText == textTuto.Length - 2) 
			{
				ActiveEvent.Instance.ActiveLigth (0);
				ActiveEvent.Instance.ShowNoticeImg (1);
			}
			ActiveEvent.Instance.ShowNoticeText (textTuto[totalText]);
			yield return new WaitForSeconds (5.3f);
			totalText++;
		}

		ActiveEvent.Instance.WaitTimeNotice ();
	}

	public void StartSecondInstructions()
	{
		StopAllCoroutines();
		ActiveEvent.Instance.WaitTimeNotice ();
		if(!onlyOnce)
			StartCoroutine(TutorialInstructions_Two());
	}
	IEnumerator TutorialInstructions_Two () 
	{
		Debug.Log("Inicio");
		int totalImg = 0;
		ActiveEvent.Instance.ShowNoticeImg (1);
		imgUI_Tuto.gameObject.SetActive (true);
		while (totalImg < imgTuto.Length) 
		{
			if (totalImg == imgTuto.Length - 1) 
			{
				ActiveEvent.Instance.ShowNoticeImg (2);
			}
			imgUI_Tuto.sprite = imgTuto[totalImg];
			yield return new WaitForSeconds (4.3f);
			totalImg++;
		}
		imgUI_Tuto.gameObject.SetActive (false);

		ActiveEvent.Instance.ShowNoticeText (textTuto[3]);
		lockMainDoor.GetComponent<Collider>().enabled = true;
		yield return new WaitForSeconds (4.3f);
		ActiveEvent.Instance.WaitTimeNotice ();
		onlyOnce = true;
	}
}