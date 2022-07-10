using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeforePlay : MonoBehaviour {
	public Button btn_Start, btn_Back, btn_Bullet, btn_Power,btn_Heath;
	public GameObject panel_BeforePlay;
	public Text text_Gold, text_Level;
	string sceneName;
	private AsyncOperation async;
	int count =0,gold;

	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetInt ("GOLD",1000000);
		Time.timeScale = 1;
		btn_Bullet.onClick.AddListener(() => OnClick_Bough(1));
		btn_Power.onClick.AddListener(() => OnClick_Bough(2));
		btn_Heath.onClick.AddListener(() => OnClick_Bough(3));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable()
	{
		text_Level.text = "LEVEL " + (PlayerPrefs.GetInt ("Level") + 1).ToString ();
		gold = PlayerPrefs.GetInt ("GOLD");
		text_Gold.text = "" + gold;
		PlayerPrefs.SetInt ("Bought",0);
		PlayerPrefs.SetInt ("BoughtItem",0);
//		PlayerPrefs.Save ();
	}


	public void OnClick_BackBeforePlay()
	{

		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		panel_BeforePlay.SetActive (false);
	}

	public void OnClick_BackInGame()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		SceneManager.LoadScene ("Map_Level");
	}

	public void OnClick_StartBeforePlay()
	{
		//ads destroy
		AdmobBannerController.Instance.DestroyBanner ();
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		sceneName = "Level" + (PlayerPrefs.GetInt ("Level")+1).ToString ();
		SceneManager.LoadScene (sceneName);
		PlayerPrefs.SetInt("GOLD",gold);
		TrackingSceneController.THIS.gameState = GameState.AdventureScene;
	}

	IEnumerator LoadSceneAsync ()
	{
		if (!string.IsNullOrEmpty (sceneName)) {
			async = SceneManager.LoadSceneAsync (sceneName);
			while (!async.isDone) {
				yield return 0;
				Time.timeScale=1;
			}
		}
	}

	void OnClick_Bough(int index)
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		if (count == 0) {
			switch (index) {
			case 1: 
				if (gold >= 3000) {
					PlayerPrefs.SetInt ("BoughtItem", index);
					btn_Bullet.image.color = new Vector4 (255, 255, 255, 255);
					count = 1;
					gold -= 3000;
					text_Gold.text = "" + gold;
				}
				break;
			case 2:
				if (gold >= 2000) {
					PlayerPrefs.SetInt ("BoughtItem", index);
					btn_Power.image.color = new Vector4 (255, 255, 255, 255);
					count = 1;
					gold -= 2000;
					text_Gold.text = "" + gold;
				}
				break;
			case 3:
				if (gold >= 8000) {
					LevelManager.CheckBuyHeath = 1;
					PlayerPrefs.SetInt ("BoughtItem", index);
					btn_Heath.image.color = new Vector4 (255, 255, 255, 255);
					count = 1;
					gold -= 8000;
					text_Gold.text = "" + gold;
				}
				break;
			}

		}

	}
}
