using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour {

	public Text text_Score, text_Time, text_Bonus, text_Total, text_HighScore,text_GOLD;
	public Button btn_Replay, btn_Next, btn_Back;
	public GameObject panel_Victory,panel_BeforePlay,particle; 

	private GameManagerBehavior gameManager;
	bool TextTime = true;
	int bonusScore= 0,totalScore=0 ,GOLDbonus;
	public int randomuniads;
	void Awake()
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}
	void Start () {
		btn_Replay.onClick.AddListener (() => OnClick_Replay ());
		btn_Back.onClick.AddListener (() => OnClick_Back ());
		btn_Next.onClick.AddListener (() => OnClick_Next ());
	}

	void Update () {
		//Ascending text score
		if (int.Parse (text_Score.text) < gameManager.Score)
			text_Score.text = (int)(int.Parse (text_Score.text) + gameManager.Score / 50) + "";

		//Ascending text time
		else if (int.Parse (text_Time.text)	< gameManager.TIME && TextTime) {
			
			text_Score.text = gameManager.Score + "";
			text_Time.gameObject.SetActive (true);
			if (gameManager.TIME < 50)
				text_Time.text = (int)(int.Parse (text_Time.text) + 1) + "";
			else
				text_Time.text = (int)(int.Parse (text_Time.text) + gameManager.TIME / 50) + "";

			//Ascending text Bonus
		} else if (int.Parse (text_Bonus.text) < bonusScore) {
			
			TextTime = false;
			text_Bonus.gameObject.SetActive (true);
			text_Bonus.text = (int)(int.Parse (text_Bonus.text) + bonusScore / 50) + "";
			if (int.Parse (text_Time.text)	> 0)
				text_Time.text = (int)(int.Parse (text_Time.text) - gameManager.TIME / 50) + "";
			else
				text_Time.text = "0";

			//Ascending text total
		} else if (int.Parse (text_Total.text) < totalScore) {
			
			text_Bonus.text = bonusScore + "";
			text_Time.text = gameManager.TIME + "";
			text_Total.gameObject.SetActive (true);
			text_Total.text = (int)(int.Parse (text_Total.text) + gameManager.Score / 50) + "";
		} else if (int.Parse (text_Total.text) <= totalScore){
			text_Total.text = totalScore + "";
//			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
		}
		
		else if (int.Parse (text_GOLD.text) < PlayerPrefs.GetInt ("GOLD")) {
			text_GOLD.text = (int)(int.Parse (text_GOLD.text) + GOLDbonus / 40) + "";
		} else {
			text_GOLD.text = PlayerPrefs.GetInt ("GOLD") + "";
			text_HighScore.text = PlayerPrefs.GetInt ("HighScore_"+ gameManager.scenesValue.ToString()) + "";
			if (PlayerPrefs.GetInt ("HighScore_" + gameManager.scenesValue.ToString ()) < totalScore)
				PlayerPrefs.SetInt ("HighScore_" + gameManager.scenesValue.ToString (), totalScore);
//			if (PlayerPrefs.GetInt ("TotalLevelDone") < gameManager.scenesValue)
//				PlayerPrefs.SetInt ("TotalLevelDone", gameManager.scenesValue );
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			PlayerPrefs.SetInt ("BestScoreAll",totalScore);
		}
	}

	void OnEnable()
	{
		randomuniads = Random.Range (1,3);
		text_GOLD.gameObject.SetActive (true);
		text_Score.gameObject.SetActive (true);
		text_HighScore.text = "0";
		bonusScore = gameManager.Score - gameManager.TIME * 10;
		totalScore = gameManager.Score + bonusScore;
		text_HighScore.text ="0";
//		if (PlayerPrefs.GetInt ("HighScore_" + gameManager.scenesValue.ToString ()) < totalScore)
//			PlayerPrefs.SetInt ("HighScore_" + gameManager.scenesValue.ToString (), totalScore);
		if (PlayerPrefs.GetInt ("TotalLevelDone") < gameManager.scenesValue)
			PlayerPrefs.SetInt ("TotalLevelDone", gameManager.scenesValue );
		GOLDbonus = (int)(gameManager.Score / 1000) * 10;
		PlayerPrefs.SetInt ("GOLD", PlayerPrefs.GetInt ("GOLD") + GOLDbonus);
		PlayerPrefs.Save ();
		particle.Spawn (new Vector3(0,2.76f,0));
		GameObject.FindObjectOfType<FXSound> ().Sound_Timecount ();
		GameObject.FindObjectOfType<FXSound> ().PlayerWinMethod ();

	}

	void OnClick_Replay()
	{
        //ads
        //		GameObject.FindObjectOfType<AdManagerUnity> ().ShowAd ("video");
        int randomads = Random.Range(1, 3); 
        if (randomads == 1)
        {
            AdmobBannerController.Instance.ShowRewardBasedVideo();
        }
        else
            AdmobBannerController.Instance.ShowInterstitial();

        FXSound.THIS.GetComponent<AudioSource> ().Stop ();
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		if (TrackingSceneController.THIS.gameState == GameState.AdventureScene) {
			panel_Victory.SetActive (false);
			panel_BeforePlay.SetActive (true);
			TrackingSceneController.THIS.gameState = GameState.AdventureScene;
		}
		else if(TrackingSceneController.THIS.gameState == GameState.EndlessScene)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			TrackingSceneController.THIS.gameState = GameState.EndlessScene;
		}

		Music.THIS.GetComponent<AudioSource> ().loop = true;
		Music.THIS.GetComponent<AudioSource> ().clip = Music.THIS.music[Random.Range(2,6)];
		Music.THIS.GetComponent<AudioSource> ().Play ();
	}

	void OnClick_Next()
	{
		//ads
		AdmobBannerController.Instance.ShowInterstitial ();
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		if (TrackingSceneController.THIS.gameState == GameState.AdventureScene) {
			SceneManager.LoadScene ("Map_Level");
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			TrackingSceneController.THIS.gameState = GameState.BeforeStart;
		} else if (TrackingSceneController.THIS.gameState == GameState.EndlessScene) {
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			SceneManager.LoadScene ("Main");
			TrackingSceneController.THIS.gameState = GameState.HomeScene;
		}
	}

	void OnClick_Back()
	{
		if(randomuniads==1)
		{
			//ads
			AdmobBannerController.Instance.ShowInterstitial ();
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
