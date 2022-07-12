using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforePlayControl : MonoBehaviour {

	public GameObject BeforePlayObj;
	public GameObject ShopObj;
	public void BP_ShowShop()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		BeforePlayObj.SetActive (false);
		ShopObj.SetActive (true);
	}
	public void BP_ShowBeforePanel()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		BeforePlayObj.SetActive (true);
		ShopObj.SetActive (false);
	}
}
