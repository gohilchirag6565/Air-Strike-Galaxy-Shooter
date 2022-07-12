using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class Main : MonoBehaviour {
	
	public GameObject panel_Setting1;
	public GameObject panel_Setting2;
	public int randomads;
	void Start()
	{
		randomads = Random.Range (1,3);
	}

	public void OnClick_Exit()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		Application.Quit ();
	}
	public void OnClick_Setting()
	{
		GameObject.FindObjectOfType<HomeAnimation> ().Show ();
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		panel_Setting1.SetActive (true);
		panel_Setting2.SetActive (true);
		TrackingSceneController.THIS.gameState = GameState.SettingPopup;
	}
	public void OnClick_CloseSetting()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		GameObject.FindObjectOfType<HomeAnimation> ().Hide ();
		TrackingSceneController.THIS.gameState = GameState.HomeScene;
	}

	public void OnClick_Start()
	{
//		AdmobBannerController.Instance.DestroyBanner ();
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		SceneManager.LoadScene("Map_level");
		TrackingSceneController.THIS.gameState = GameState.BeforeStart;
	}
	public void OnClick_StartEndless()
	{
		
		AdmobBannerController.Instance.DestroyBanner ();
		if (randomads == 1) {
            //ads
            //GameObject.FindObjectOfType<AdManagerUnity> ().ShowAd ("video");
            AdmobBannerController.Instance.ShowRewardBasedVideo();

        } else
			AdmobBannerController.Instance.ShowInterstitial ();
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		SceneManager.LoadScene("Endless");
		TrackingSceneController.THIS.gameState = GameState.EndlessScene;
	}

	public void OnClick_LeaderBoard()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
	}

	public void OnClick_FreeCoins()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
	}
}

