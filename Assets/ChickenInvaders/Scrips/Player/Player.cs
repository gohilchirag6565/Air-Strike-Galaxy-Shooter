using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player: MonoBehaviour {
	public GameObject EF_TakeItem;
	public GameObject CoinPrefab,CoinPrefabEffect;
	public int numberStypeLast, valuegun, currentValueGun;
	public GameObject[] StypeGun;
	public static Player instance;
	private GameManagerBehavior gameManager;
	public GameObject FlyPower, SaveZone,Player_Parent;
	public bool saveZone;
	bool Power;
	float timePower = 6f,startTime,distance;
	public GameObject PauseObj;
	void Awake()
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();	
	}

	void Start()
	{
		instance = this ;
		if (PlayerPrefs.GetInt ("BoughtItem") == 3) {
			SaveZone.SetActive (true);
			saveZone = true;
			PlayerPrefs.SetInt ("BoughtItem",0);
		}
	}

	void OnEnable()
	{
	}

	void Update()
	{
		if (Power) {
			
			timePower -= Time.deltaTime;
			if (timePower < 1.5f) {
				FlyPower.GetComponent<Animator> ().SetTrigger ("play");
			}
			if (timePower < 0) {
				timePower = 6f;
				valuegun = gameManager.Power;
				Power = false;
				FlyPower.GetComponent<Animator> ().SetBool ("play",false);
				FlyPower.transform.GetChild (0).gameObject.SetActive (true);
				FlyPower.transform.GetChild (1).gameObject.SetActive (true);
				FlyPower.SetActive (false);
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			if (PlayScenes.CheckPaused == 0) {
				Time.timeScale = 1;
				Invoke ("HoldPlayer", 0.1f);
			}
		
		}

		if (Input.GetMouseButtonUp (0)) {
			if(PlayScenes.CheckPaused==0)
			{
				Time.timeScale = 0.5f;
				Invoke ("RealeashPlayer",0.1f);
			}
			else Time.timeScale = 0;
		
		}
	}
	public void HoldPlayer()
	{
		PauseObj.SetActive (false);
	}
	public void RealeashPlayer()
	{
		PauseObj.SetActive (true);
	}
	void OnMouseDrag ()
	{
		if (!gameManager.gameOver && Input.touchCount >0) {
			gameObject.transform.parent.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position).x,
				Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position).y,
				-2.0f);
		}

		if (!gameManager.gameOver ) {
			gameObject.transform.parent.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x,
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y,
				-2.0f);
		}
	}

	public void ChangeStypeGun(int numberStypeNew)
	{
		if (numberStypeNew < 3) {
			if (numberStypeNew == numberStypeLast)
				UplevelGun ();
			else {
				StypeGun [numberStypeLast].SetActive (false);
				StypeGun [numberStypeNew].SetActive (true);
				numberStypeLast = numberStypeNew;
			}
		} 
	}

	public void UplevelGun()
	{
		if (Player.instance.valuegun == 12 ) {
			if (Power && gameManager.Power < 12) {
				gameManager.Power++;
			}
		} else {
			Player.instance.valuegun++;
			gameManager.Power++;
		}
	}

	public void TakePowerBullet()
	{
		Power = true;
		FlyPower.SetActive (true);
		valuegun = 12;
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if ( other.tag=="Clover") {
			EF_TakeItem.Spawn (other.transform.position);
			StartCoroutine (RandomMoreCoin (other.gameObject));
		}

	}

	IEnumerator RandomMoreCoin (GameObject other)
	{
		Destroy (other);
		GameObject goodLuck = GameObject.Find ("Canvas_InGame").transform.GetChild (5).gameObject;
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.BonusTime);
		goodLuck.SetActive (true);
		yield return new WaitForSeconds (1f);
		goodLuck.SetActive (false);
		float i = 0;
		while (i < 15) {
			i++;
			CoinPrefab.Spawn(CoinPrefab.transform.position);
			CoinPrefabEffect.Spawn(CoinPrefab.transform.position);
			if (CoinPrefab != null) {
				CoinPrefab.transform.position = new Vector3 (Random.Range (-2.3f, 2.3f), Random.Range (3.0f, 0.8f), 0);
				CoinPrefabEffect.transform.position = CoinPrefab.transform.position;
				FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.RandomCoins[Random.Range(0,5)]);
				CoinPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector3 (Random.Range (-2, 2), Random.Range (3, 6), 0);
			}
			yield return new WaitForSeconds (0.2f);
			other.Recycle ();
			yield return new WaitForSeconds (0.3f);
		}

		Resources.UnloadUnusedAssets ();
		System.GC.Collect ();
	}
}
