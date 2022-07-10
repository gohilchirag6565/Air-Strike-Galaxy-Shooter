using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour {

	public int scenesValue;
	private float onesecond;
	public Text waveLabel,waveMax,finalwave,CoinText,Level_Infor,powerText;
	public bool gameOver = false;
	public GameObject panel_Defeat,panel_Victory;
	public static int CoinsEarn;
	public int checkDefeat;
	public GameObject PauseBtn;

	/// <summary>
	/// PlayerPrefs.Getint("Level"); Save current level selected
	/// PlayerPrefs.Getint("HighScore_"+ ...); Save score level ...
	/// PlayerPrefs.Getint("TotalLevelDone"); Save level maps unlock
	/// PlayerPrefs.Getint("Bought"); =0: Not Buy // = 1: Buy Bullet   // = 2: Buy power  // = 3: Buy Heath
	/// PlayerPrefs.Getint("GOLD"); Amount Coins of player
	/// </summary>
	/// 
	void Start () {
		checkDefeat = 0;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		if (scenesValue == 0) {
		} else 
		{
			if (TrackingSceneController.THIS.gameState == GameState.AdventureScene) {
				Level_Infor.text = "LEVEL " + scenesValue; 
				TIME = 0;
				Score = 0;
				Power = 1;
				CoinsEarn = 0;
			} else if (TrackingSceneController.THIS.gameState == GameState.EndlessScene) 
			{
				Level_Infor.text = "ENDLESS MODE"; 
				TIME = 0;
				Score = 0;
				Power = 1;
				CoinsEarn = 0;
			}
		}
	}
	void Update () {
		if (!gameOver && scenesValue !=0) {
			onesecond -= Time.deltaTime;
			if (onesecond < 0) {
				onesecond = 1f;
				TIME++;
			}
			if(checkDefeat==1){
				CoinsEarn = 0;
				CoinText.text = "" + 0;
				checkDefeat = 0;
			}
			CoinText.text = "" + CoinsEarn;


		}
	}

	void OnEnable () {
		Time.timeScale = 1;
		if (scenesValue == 0) {

			if (PlayerPrefs.GetInt ("FirstOnApp") == 0) {
				PlayerPrefs.SetInt ("Music", 1);
				PlayerPrefs.SetInt ("Sound", 1);
				PlayerPrefs.SetInt ("FirstOnApp", 1);
				PlayerPrefs.SetInt ("Money", 0);
				PlayerPrefs.Save ();
			}

			Music.THIS.GetComponent<AudioSource> ().Stop ();
			Music.THIS.GetComponent<AudioSource> ().loop = true;
			Music.THIS.GetComponent<AudioSource> ().clip = Music.THIS.music[Random.Range(2,5)];
			Music.THIS.GetComponent<AudioSource> ().Play ();
		}
		else {
			Music.THIS.GetComponent<AudioSource> ().Stop ();
			Music.THIS.GetComponent<AudioSource> ().loop = true;
			Music.THIS.GetComponent<AudioSource> ().clip = Music.THIS.music[Random.Range(2,5)];
			Music.THIS.GetComponent<AudioSource> ().Play ();
		}
	}

	public Text scoreIngame;
	private int score;
	private int checklucky;
	private int checkGunTye;
	public int Score {
		get { return score; }
		set {
			score = value;
			scoreIngame.GetComponent<Text>().text = "" + score;
		}
	}
	public int Checklucky {
		get { return checklucky; }
		set {
			checklucky = value;
		}
	}
	public int CheckGunTye {
		get { return checkGunTye; }
		set {
			checkGunTye = value;
		}
	}

	private int wave;
	public int Wave {
		get { return wave; }
		set {
			wave = value;
			if (wave == MaxWave) {
				Victory();
			} else
			if ((wave == MaxWave - 1 )) {
				waveLabel.gameObject.SetActive (false);
				waveMax.gameObject.SetActive (false);
				finalwave.gameObject.SetActive (true);
				StartCoroutine (UnHideWave());
			} else {
				waveLabel.text = "WAVE " + (wave + 1);
				waveLabel.gameObject.SetActive (true);
					if(TrackingSceneController.THIS.gameState == GameState.AdventureScene)
					{
						waveMax.gameObject.SetActive (true);
					}
					else if(TrackingSceneController.THIS.gameState == GameState.EndlessScene)
					{
						waveMax.gameObject.SetActive (false);
					}
				
				StartCoroutine (UnHideWave());
			}
		}
	}

	private int maxwave;
	public int MaxWave {
		get { return maxwave; }
		set {
			maxwave = value;

			waveMax.text = "/" + maxwave;
		}
	}


	public Text healthLabel;

	private int health;
	public int Health {
		get { return health; }
		set {
			health = value;
			// 
			if (health <= 0 && !gameOver) {
				gameOver = true;
			}
		}
	}

	private int time;
	public int TIME{
		get{return time; }
		set {
		time = value;

		}
	}

	private int power;
	public int Power{
		get{return power; }
		set {
			power = value;

			powerText.text = "POWER " + power+"/12";
		}
	}
	IEnumerator UnHideWave()
	{
		yield return new WaitForSeconds (2f);
		waveLabel.gameObject.SetActive (false);
		finalwave.gameObject.SetActive (false);
		waveMax.gameObject.SetActive (false);
	}

	public void Defeat()
	{
		
		Music.THIS.GetComponent<AudioSource> ().Stop ();
		if(TrackingSceneController.THIS.gameState == GameState.EndlessScene)
		{
			PlayerPrefs.SetInt ("GOLD", PlayerPrefs.GetInt ("GOLD") + (int)(CoinsEarn/10));
			PlayerPrefs.Save ();
		}
		checkDefeat = 1;
		gameOver = true;
		StartCoroutine (WaitDefeat());

	}

	public void Victory()
	{
		Music.THIS.GetComponent<AudioSource> ().Stop ();
		PlayerPrefs.SetInt ("GOLD", PlayerPrefs.GetInt ("GOLD") + CoinsEarn);
		PlayerPrefs.Save ();
		gameOver = true;
		StartCoroutine (WaitVictory());
	}
	IEnumerator WaitDefeat()
	{
		yield return new WaitForSeconds (1.0f);
		panel_Defeat.SetActive (true);
		PauseBtn.SetActive (false);
	}

	IEnumerator WaitVictory()
	{
		yield return new WaitForSeconds (1.0f);
		panel_Victory.SetActive (true);
		PauseBtn.SetActive (false);
	}
}
