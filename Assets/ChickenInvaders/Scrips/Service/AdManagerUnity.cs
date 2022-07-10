using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//#if UNITY_ADS
using UnityEngine.Advertisements;
//#endif
public class AdManagerUnity : MonoBehaviour 
{
//	#if UNITY_ADS
	public static AdManagerUnity ads;
	//Insert you Unity Ads ID here
	#if UNITY_IOS
	[SerializeField] string gameID = "";
	#elif UNITY_ANDROID
	[SerializeField] string gameID = "3757603";
	#endif
	void Awake()
	{
		/*Advertisement.Initialize (gameID, true);*/
		if (ads != null)
		{
			Destroy(gameObject);
		}
		else
		{
			ads = this;
			DontDestroyOnLoad(gameObject);
		}
		/*if (Advertisement.IsReady ("rewardedVideo")) 
		{
			//ShowAd("rewardedVideo");
		}*/

	}

	public void ShowAd(string zone = "")
	{
		#if UNITY_EDITOR
		StartCoroutine(WaitForAd ());
		#endif

		if (string.Equals (zone, ""))
			zone = null;

		/*ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.IsReady (zone))
			Advertisement.Show (zone, options);*/
	}

	/*void AdCallbackhandler (ShowResult result)
	{
		switch(result)
		{
		case ShowResult.Finished:
			Advertisement.Initialize (gameID, false);
			if (I2.MiniGames.PrizeWheel.checkFreeSpinInt == 1) {
				GameObject.FindObjectOfType<I2.MiniGames.PrizeWheel> ().SpinningCallBackAfterWatchVideoAds ();
			} 
			if (FreeCoinRewardUI.isFreeAd == 1) {
				GameObject.FindObjectOfType<FreeCoinRewardUI> ().FreeAdsCallBack ();
			}
			if (Defeat.isTakeHeath == 1) {
				GameObject.FindObjectOfType<Defeat> ().CallBackAfterWatchUnityAds ();
			}
			break;
		case ShowResult.Skipped:
			Advertisement.Initialize (gameID, false);
			Debug.Log ("Ad skipped. Son, I am dissapointed in you");
			break;
		case ShowResult.Failed:
			Advertisement.Initialize (gameID, false);
			Debug.Log("I swear this has never happened to me before");
			break;
		}
	}*/

	IEnumerator WaitForAd()
	{
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;

		/*while (Advertisement.isShowing)
			yield return null;*/

		Time.timeScale = currentTimeScale;
	}
//#endif
}