using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {
	[HideInInspector]
	public GameObject[] waypoints;
	public int currentWaypoint = 0, scoreBonus;
	public GameObject ChickenHouse, ChickenStartHunt, EF_PlayerDie;

	private GameManagerBehavior gameManager;
	public int Heath,ChickenValue;
	private GameObject Dot;

	public float HeSovy ,HeSoelapse_time = 1.5f;

	//lastSpawnChicken Marked the last chicken spawn
	//beginMove stop update when go to target position
	public bool lastSpawnChicken,beginMove = true,loop,huntAlone,beginHuntAlone;  //loop with waves of chicken loop

	// Mark the location to find the player position and start moving to
	public bool beginHunt,checkInHunt,checkOutHunt;
	public float speed,timeHunt;  //Time to fly from chicken to player
	float vx, vy,PlayerY;
	private float elapse_time;

	void Start () {
		
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
		gameObject.transform.position = waypoints [0].gameObject.transform.position;

	}

	void OnEnable(){
		
	}


	void Update () {

		//beginMove Move from Spawn position into Maps
		if (beginMove) {
			Vector3 endPosition = new Vector3 (waypoints [currentWaypoint + 1].transform.position.x,
				                     waypoints [currentWaypoint + 1].transform.position.y, 0);
			
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, endPosition, speed * Time.deltaTime);
		 
			if (gameObject.transform.position.Equals (endPosition)) {
				if (currentWaypoint < waypoints.Length - 2)
					currentWaypoint++;
			else 
				{
					if (loop)
						currentWaypoint = 0;
					else {
						if (lastSpawnChicken) {
						
							GameObject.Find ("ChickenHouse").GetComponent<Animator> ().SetTrigger ("move");
						}
						beginMove = false;
					}
					if (huntAlone)
						beginHuntAlone = true;
				}
			}
		}

		//Check when it reaches the correct grid position, then chicken start animation,move
		if (checkInHunt) {
			if (ChickenHouse.transform.position.x<0.2f && ChickenHouse.transform.position.x>-0.2f) {
				gameObject.transform.SetParent (ChickenStartHunt.transform);
				beginHunt = true;
				checkInHunt = false;
			}
		}

		//beginHunt Start hunting the player
		if (beginHunt)
		{
			if (transform.position.y > PlayerY) {
				transform.Translate ((vx) * Time.deltaTime, (vy - 19.8f * elapse_time) * Time.deltaTime * HeSovy, 0);
				transform.position = new Vector3 (transform.position.x, transform.position.y, -1);
				elapse_time += Time.deltaTime * HeSoelapse_time;
			} else {
				beginHunt = false;
				checkOutHunt = true;
			}
		}

		//Check when move correct position on Map,then Put them on ChickenHouse
		if (checkOutHunt) {
			Vector3 endPosition = new Vector3 (waypoints [waypoints.Length - 1].transform.position.x,
				waypoints [waypoints.Length - 1].transform.position.y, 1);

			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, endPosition, speed * Time.deltaTime);

			if (gameObject.transform.position.Equals (endPosition)) {
				if (ChickenHouse.transform.position.x<0.01f && ChickenHouse.transform.position.x>-0.01f) {
					gameObject.transform.SetParent (ChickenHouse.transform);
					checkOutHunt = false;
				}
			}
		}

		//Hunting Player 
		if (huntAlone && beginHuntAlone) {
			if (GameObject.Find ("Player_ingame")) {
				currentWaypoint = 0;
				waypoints [0] =gameObject;
				if (!Dot)
					Dot = new GameObject();
				Dot.transform.position = GameObject.Find ("Player_ingame").transform.position;
				waypoints [1] =Dot;
				beginMove = true;
				beginHuntAlone = false;
			}
		}
	}

	public void moveparabol(Vector3 start, Vector3 end, float t)
	{
		PlayerY = end.y;
		float x = (end.x - start.x);
		float y = (end.y - start.y);
		vx = x / t;
		vy = (y + 0.5f * 19.8f * t * t) / t;
//		Debug.Log (vx + " " + vy);
	}

	void OnDestroy()
	{
		if (Dot) 
		{
			Dot.Recycle ();
		}
	}

	public void ScoreAdd()
	{

		gameManager.Checklucky += 1;
		gameManager.Score += scoreBonus;

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			if (other.GetComponent<Player> ().saveZone == false) {
				other.transform.parent.gameObject.SetActive (false);
				gameManager.Defeat ();
				gameManager.gameOver = true;

				Music.THIS.GetComponent<AudioSource> ().Stop ();
				FXSound.THIS.GetComponent<AudioSource> ().Stop ();
				FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerDie[Random.Range(0,3)]);	
				EF_PlayerDie.Spawn (other.transform.position);

			} else {
				other.GetComponent<Player> ().saveZone = false;
				other.GetComponent<Player> ().SaveZone.SetActive (false);
			}
			if (UnhideChickenMain.CheckVibrate == 1) {
				Handheld.Vibrate ();
			}
			if (gameObject.CompareTag ("enemy"))
				gameObject.Recycle ();
			}
	}
}
