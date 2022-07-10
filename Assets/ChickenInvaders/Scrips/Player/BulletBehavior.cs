using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	public float speed = 5;
	public int damage;
	public Vector3 startPosition;
	public Vector3 targetPosition;
	public GameObject BossDie_EF;
	public GameObject CoinPrefab;
	public GameObject CoinPrefabEffect;
	public GameObject CloverPrefab;
	private float distance;
	private float startTime;
	private GameManagerBehavior gameManager;
	private int hit;
	private int RandomCheckLucky;
	void Start () 
	{
		RandomCheckLucky = Random.Range (20,30);
		startTime = Time.time;
		distance = Vector3.Distance (startPosition, targetPosition);
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
	}

	void Update () {
		//
		float timeInterval = Time.time - startTime;
		gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);
		
		//
		if (gameObject.transform.position.Equals(targetPosition) || gameObject.transform.position.y > 5.1f
			||gameObject.transform.position.x<-3.4f||gameObject.transform.position.x>3.4f) {
			gameObject.Recycle();
		}	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("enemy")&& !gameManager.gameOver) 
		{
			other.GetComponent<MoveEnemy> ().Heath =other.GetComponent<MoveEnemy> ().Heath - damage;
			if (other.GetComponentInChildren<Animator> ())
				other.GetComponentInChildren<Animator> ().SetTrigger ("Hit");
			if (other.GetComponent<MoveEnemy> ().Heath < 1) 
			{ 
				if(gameManager.Checklucky==RandomCheckLucky)
				{
					gameManager.Checklucky = 0;
					CloverPrefab.Spawn (transform.position);
					CloverPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, Random.Range ( 0, 2f), 0);
				}
				other.GetComponent<MoveEnemy> ().ScoreAdd ();
				GameObject.Find("ChickenHouse").GetComponent<RandomBulletEnemy>().RandonItem(other.transform.position);
				other.Recycle ();

				int numberCoinAppear = UnityEngine.Random.Range (1, 2);
				for (int i = 0; i < numberCoinAppear; i++) 
				{
					CoinPrefab.Spawn(transform.position);
					CoinPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-1f, Random.Range (0, 2f), 0);
				}

				if (other.GetComponent<MoveEnemy> ().ChickenValue == 1)

					FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ChickenDie[Random.Range(0,3)]);
				
				if (other.GetComponent<MoveEnemy> ().ChickenValue == 2) 
					FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.StoneDestruction);
			}
			gameObject.Recycle ();
		}

		if (other.CompareTag("boss")&& !gameManager.gameOver) {

			other.GetComponent<MoveEnemy> ().Heath =other.GetComponent<MoveEnemy> ().Heath - damage;
			HealthBar.instance.currentHealth -= damage;
			if (other.GetComponent<MoveEnemy> ().Heath < 1) {
				int numberCoinAppear1 = UnityEngine.Random.Range (10, 20);
				for (int i = 0; i < numberCoinAppear1; i++) 
				{
					CoinPrefab.Spawn(transform.position);
					CoinPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, Random.Range (0, 2f), 0);
				}
				other.GetComponent<MoveEnemy> ().ScoreAdd ();
				other.Recycle ();

				BossDie_EF.Spawn (other.transform.position);

				FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.BossDie[Random.Range(0,4)]);
			}
			gameObject.Recycle ();
		}
	}
	}

