using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class SpinWheelController : MonoBehaviour 
{
	public GameObject SpinNormal;
	public GameObject SpinAfterWatchAds;
	public Button SpinAfterWatchAds1;
	void Update () 
	{
		if (PlayerPrefs.GetInt ("GOLD") >= 100) {
			SpinNormal.SetActive (true);
			SpinAfterWatchAds.SetActive (false);
		} else 
		{
			SpinNormal.SetActive (false);
			SpinAfterWatchAds.SetActive (true);

            if(AdmobBannerController.Instance.rewardBasedVideo.IsLoaded())
            {
                SpinAfterWatchAds1.interactable = true;
            }
            else
                SpinAfterWatchAds1.interactable = false;

            /*if (Advertisement.IsReady ("rewardedVideo")) 
			{
				SpinAfterWatchAds1.interactable=true;
			}
			else
				SpinAfterWatchAds1.interactable=false;*/

		}
	}

	public void SpinResult1()
	{
		FXSound.THIS.fxSound.clip = FXSound.THIS.PlayerGetItem;
		PlayerPrefs.SetInt ("GOLD", PlayerPrefs.GetInt ("GOLD") +100);
		PlayerPrefs.Save ();
		Debug.Log ("1");
	}
	public void SpinResult2()
	{
		FXSound.THIS.fxSound.clip = FXSound.THIS.SpinningLose;
		Debug.Log ("2");
	}
	public void SpinResult3()
	{
		FXSound.THIS.fxSound.clip = FXSound.THIS.PlayerGetItem;
		PlayerPrefs.SetInt ("GOLD", PlayerPrefs.GetInt ("GOLD") +500);
		PlayerPrefs.Save ();
		Debug.Log ("3");
			
	}
	public void SpinResult4()
	{	
		FXSound.THIS.fxSound.clip = FXSound.THIS.SpinningLose;	
		Debug.Log ("4");
	}
	public void SpinResult5()
	{
		FXSound.THIS.fxSound.clip = FXSound.THIS.PlayerGetItem;
		PlayerPrefs.SetInt ("GOLD", PlayerPrefs.GetInt ("GOLD") +1000);
		PlayerPrefs.Save ();
		Debug.Log ("5");
	}
	public void SpinResult6()
	{
		FXSound.THIS.fxSound.clip = FXSound.THIS.SpinningLose;
		Debug.Log ("6");
	}
	public void SpinResult7()
	{	
		FXSound.THIS.fxSound.clip = FXSound.THIS.PlayerGetItem;
		PlayerPrefs.SetInt ("GOLD", PlayerPrefs.GetInt ("GOLD") +50000);
		PlayerPrefs.Save ();
		Debug.Log ("7");
	}
	public void SpinResult8()
	{
		FXSound.THIS.fxSound.clip = FXSound.THIS.SpinningLose;
		Debug.Log ("8");
	}
	public void SpinResult9()
	{
		FXSound.THIS.fxSound.clip = FXSound.THIS.PlayerGetItem;
		PlayerPrefs.SetInt ("GOLD", PlayerPrefs.GetInt ("GOLD") +2000);
		PlayerPrefs.Save ();
		Debug.Log ("9");
	}
	public void SpinResult10()
	{
		FXSound.THIS.fxSound.clip = FXSound.THIS.SpinningLose;
		Debug.Log ("10");
	}

}
