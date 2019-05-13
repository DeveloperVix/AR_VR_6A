using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ActiveEvent : MonoBehaviour 
{
	private static ActiveEvent instance;
	public static ActiveEvent Instance { get { return instance;}}
	/*	
		0 = Eye (Amarillo) => Observa - Texto - Cinematica
		1 = CrossFire (Rojo) => Dispara
		2 = Arrow (Verde) => Moverse - Moviendose
	 */

	public Color[] colorNoticeImg;
	public Sprite[] noticeImgs;
	public Image noticeAction;
	public TextMeshProUGUI noticeText;

	//0 = rigth, 1 = left
	public Sprite[] ligthSpriteUI;
	public Image ligthUI;

    // Use this for initialization
    void Start () 
	{
		if(instance == null)
		{
			instance = this;
		}	
	}

	public void ActiveLigth(int ligthOnUI)
	{
		ligthUI.gameObject.SetActive(true);
		ligthUI.sprite = ligthSpriteUI[ligthOnUI];
	}
	
	public void ShowNoticeText(string textOnUI)
	{
		noticeText.gameObject.SetActive(true);
		noticeText.text = textOnUI;
	}

	public void ShowNoticeImg(int index)
	{
		noticeAction.gameObject.SetActive(true);
		noticeAction.color = colorNoticeImg[index];
		noticeAction.sprite = noticeImgs[index];
	}

	public void WaitTimeNotice()
	{
		noticeAction.gameObject.SetActive(false);
		noticeText.gameObject.SetActive(false);
		ligthUI.gameObject.SetActive(false);
	}
}
