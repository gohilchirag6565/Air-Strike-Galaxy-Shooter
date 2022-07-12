using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using UnityEngine.Advertisements;

public class Defeat : MonoBehaviour {

	public Text text_Score, text_Time, text_Bonus, text_Total, text_HighScore;
	public Button btn_Replay, btn_TakeHeath, btn_Back;
	public GameObject panel_Defeat,panel_BeforePlay,Player_Ingame; 
	Player _player;
	private GameManagerBehavior gameManager;
	bool TextTime = true;
	int countTakeHeath = 0 ;
	public static int isTakeHeath=0;
	public int randomuniads;
	public Button TakeHeathBtn;
	void Awake()
	{
		
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}
	void Start () {
		btn_Replay.onClick.AddListener (() => OnClick_Replay ());
		btn_Back.onClick.AddListener (() => OnClick_Back ());
		btn_TakeHeath.onClick.AddListener (() => OnClick_TakeHeath ());
	}
	
	void Update () {
		if (AdmobBannerController.Instance.rewardBasedVideo.IsLoaded()|| LevelManager.CheckBuyHeath==1) {
			TakeHeathBtn.interactable = true;
		}
		else
			TakeHeathBtn.interactable = false;


		if (int.Parse (text_Score.text) < gameManager.Score)
			text_Score.text = (int)(int.Parse (text_Score.text) + gameManager.Score / 50) + "";
		else if (int.Parse (text_Time.text)	< gameManager.TIME && TextTime) {
			text_Score.text = gameManager.Score + "";
			text_Time.gameObject.SetActive (true);
			if (gameManager.TIME < 50)
				text_Time.text = (int)(int.Parse (text_Time.text) + 1) + "";
			else
				text_Time.text = (int)(int.Parse (text_Time.text) + gameManager.TIME / 50) + "";
		} else if (int.Parse (text_Total.text) < gameManager.Score || gameManager.Score == 0) {
			TextTime = false;
			text_Time.text = gameManager.TIME + "";
			text_Bonus.gameObject.SetActive (true);
			text_Total.gameObject.SetActive (true);
			if (gameManager.Score == 0) {
				FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			}
			text_Total.text = (int)(int.Parse (text_Total.text) + gameManager.Score / 50) + "";

		} else {
			text_Total.text = gameManager.Score + "";
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			if (TrackingSceneController.THIS.gameState == GameState.AdventureScene) {
				text_HighScore.text = PlayerPrefs.GetInt ("HighScore_" + gameManager.scenesValue.ToString ()) + "";
			}
			if(TrackingSceneController.THIS.gameState == GameState.EndlessScene)
			{
				text_HighScore.text = ""+PlayerPrefs.GetInt("HighScoreEndless",gameManager.Score);
				PlayerPrefs.SetInt ("BestScoreAll",gameManager.Score);
			}
		}
	}

	void OnEnable()
	{
		randomuniads = Random.Range (1,3);
		if (countTakeHeath == 1) {
			btn_TakeHeath.gameObject.SetActive (false);
		}
		text_Score.gameObject.SetActive (true);
		if (TrackingSceneController.THIS.gameState == GameState.AdventureScene) {
			text_HighScore.text = "0";
		}
		else if(TrackingSceneController.THIS.gameState == GameState.EndlessScene)
		{
			text_HighScore.text = "0";
		}
		GameObject.FindObjectOfType<FXSound> ().Sound_Timecount ();
	}

	void OnClick_Replay()
	{
		
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		if(TrackingSceneController.THIS.gameState == GameState.AdventureScene)
		{
			//ads
			AdmobBannerController.Instance.ShowInterstitial ();
			panel_Defeat.SetActive (false);
			panel_BeforePlay.SetActive (true);
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			TrackingSceneController.THIS.gameState = GameState.AdventureScene;
		}
		else if(TrackingSceneController.THIS.gameState == GameState.EndlessScene)
		{
            //ads
            //GameObject.FindObjectOfType<AdManagerUnity> ().ShowAd ("video");
            AdmobBannerController.Instance.ShowRewardBasedVideo();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			TrackingSceneController.THIS.gameState = GameState.EndlessScene;
		}

	}

	void OnClick_TakeHeath()
	{
		if(LevelManager.CheckBuyHeath==1)
		{
			//Use Item Continue 
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			TextTime = true;
			countTakeHeath++;
			text_Score.text = "0";text_Score.gameObject.SetActive (false);
			text_Time.text = "0";text_Time.gameObject.SetActive (false);
			text_Total.text = "0";text_Total.gameObject.SetActive (false);
			text_Bonus.text = "0";text_Bonus.gameObject.SetActive (false);
			panel_Defeat.SetActive (false);
			gameManager.gameOver = false;
			Player_Ingame.transform.position = new Vector3(0, -3f,0);
			Player_Ingame.SetActive(true);
			Player_Ingame.GetComponentInChildren<Animator> ().SetTrigger ("bool");
			Music.THIS.GetComponent<AudioSource> ().loop = true;
			Music.THIS.GetComponent<AudioSource> ().clip = Music.THIS.music[Random.Range(2,5)];
			Music.THIS.GetComponent<AudioSource> ().Play ();
			LevelManager.CheckBuyHeath = 0;
		}
		else
		{
			// Watch Video To Continue!!
			// Call Watch UnityAds Method
			//ads
			if (AdmobBannerController.Instance.rewardBasedVideo.IsLoaded())
			{
				isTakeHeath=1;
				FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
                //GameObject.FindObjectOfType<AdManagerUnity> ().ShowAd ("rewardedVideo");
                AdmobBannerController.Instance.ShowRewardBasedVideo();
            }
			else
				FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.DisActiveBtn);

		}
	}
	public void CallBackAfterWatchUnityAds()
	{
		isTakeHeath=0;
		FXSound.THIS.GetComponent<AudioSource> ().Stop ();
		TextTime = true;
		countTakeHeath++;
		text_Score.text = "0";text_Score.gameObject.SetActive (false);
		text_Time.text = "0";text_Time.gameObject.SetActive (false);
		text_Total.text = "0";text_Total.gameObject.SetActive (false);
		text_Bonus.text = "0";text_Bonus.gameObject.SetActive (false);
		panel_Defeat.SetActive (false);
		gameManager.gameOver = false;
		Player_Ingame.transform.position = new Vector3(0, -3f,0);
		Player_Ingame.SetActive(true);
		Player_Ingame.GetComponentInChildren<Animator> ().SetTrigger ("bool");
		Music.THIS.GetComponent<AudioSource> ().loop = true;
		Music.THIS.GetComponent<AudioSource> ().clip = Music.THIS.music[Random.Range(2,5)];
		Music.THIS.GetComponent<AudioSource> ().Play ();
	}

	void OnClick_Back()
	{
		FXSound.THIS.GetComponent<AudioSource> ().Stop ();
		if(randomuniads==1)
		{
            //ads
            //GameObject.FindObjectOfType<AdManagerUnity> ().ShowAd ("video");
            AdmobBannerController.Instance.ShowRewardBasedVideo();
        }
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		FXSound.THIS.GetComponent<AudioSource> ().Stop ();
		if(TrackingSceneController.THIS.gameState == GameState.AdventureScene)
		{
			SceneManager.LoadScene ("Map_Level");
			TrackingSceneController.THIS.gameState = GameState.BeforeStart;
			AdmobBannerController.Instance.ShowBanner ();
		}
		else if(TrackingSceneController.THIS.gameState == GameState.EndlessScene){
			SceneManager.LoadScene ("Main");
			TrackingSceneController.THIS.gameState = GameState.HomeScene;
			AdmobBannerController.Instance.ShowBanner ();
		}


	}

}
