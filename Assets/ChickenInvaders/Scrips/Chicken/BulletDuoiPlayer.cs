using UnityEngine;
using System.Collections;

public class BulletDuoiPlayer : MonoBehaviour {

	public Vector3 endPosition;
	public float speed = 3;
	public float timeDieBullet;
	private float timeCount;
	public GameObject EF_PlayerDie;

	private GameManagerBehavior gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		if (timeCount < timeDieBullet) {
			endPosition = GameObject.Find ("Player_ingame").transform.position;
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, endPosition, speed * Time.deltaTime);

			Vector3 newDirection = (endPosition - gameObject.transform.position);
			float i = newDirection.x;
			float j = newDirection.y;
			float rotationAngle = Mathf.Atan2 (j, i) * 180 / Mathf.PI - 90f;
			gameObject.transform.rotation = Quaternion.AngleAxis (rotationAngle, Vector3.forward);
		} else
			gameObject.Recycle ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player") && !gameManager.gameOver) {
			//			Debug.Log ("Player Die");

			if (other.GetComponent<Player> ().saveZone == false) {
				
//				other.gameObject.SetActive (false);
				other.transform.parent.gameObject.SetActive (false);
				gameManager.Defeat ();
				EF_PlayerDie.Spawn (other.transform.position);
				FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerDie[Random.Range(0,3)]);
//				if (SoundManager.Sound)
//					SoundManager.Sound.Sound_PlayerDie ();
				
			} else {
				other.GetComponent<Player> ().saveZone = false;
				other.GetComponent<Player> ().SaveZone.SetActive (false);
			}

			gameObject.Recycle ();
			if(UnhideChickenMain.CheckVibrate==1){
				Handheld.Vibrate();
			}
		
		}
	}
}
