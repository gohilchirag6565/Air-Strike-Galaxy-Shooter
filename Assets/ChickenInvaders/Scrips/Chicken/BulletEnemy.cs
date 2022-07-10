using UnityEngine;
using System.Collections;

public class BulletEnemy: MonoBehaviour {

	public float speed = 5;
	public int damage;
	public Vector3 startPosition;
	public Vector3 targetPosition;
	public GameObject Prefab_BulletDestroy,Prefab_EnemyDestroy,EF_PlayerDie;

	private float distance;
	private float startTime;

		private GameManagerBehavior gameManager;
	private int hit;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		distance = Vector3.Distance (startPosition, targetPosition);
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
	}

	void Update () {
		//
		float timeInterval = Time.time - startTime;
		gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

		//
		if (gameObject.transform.position.Equals(targetPosition) || gameObject.transform.position.y < -5.5f
			||gameObject.transform.position.x<-3.4f||gameObject.transform.position.x>3.4f) 
		{
			gameObject.Recycle();
		}	
	}

	void PlayParticle()
	{
		ParticleSystem pt;
		GameObject EF = Prefab_BulletDestroy.Spawn();
		EF.transform.position = targetPosition;
		pt = EF.GetComponent<ParticleSystem> ();
		if (pt.isStopped)
			pt.Recycle();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player") && !gameManager.gameOver) {
			if (other.GetComponent<Player> ().saveZone == false) {
				other.transform.parent.gameObject.SetActive (false);
				gameManager.Defeat ();
				EF_PlayerDie.Spawn (other.transform.position);
				Music.THIS.GetComponent<AudioSource> ().Stop ();
				FXSound.THIS.GetComponent<AudioSource> ().Stop ();
				FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerDie[Random.Range(0,3)]);
				
			} else {
				
				other.GetComponent<Player> ().saveZone = false;
				other.GetComponent<Player> ().SaveZone.SetActive (false);
			}
			gameObject.Recycle ();
			if (UnhideChickenMain.CheckVibrate == 1) {
				Handheld.Vibrate ();
			}

		}
	}
}
