using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[System.Serializable]
public class Wave {
	public GameObject[] enemyPrefab;
	public int[] numberWave;
}

public class SpawnChicken : MonoBehaviour {

	public GameObject[]  waypoints,waypoints2, waypoints3, waypoints4,waypoints5,waypoints6,waypoints7;

	public Wave waves;		//Number of chickens on the way
	public float timeBeginWaves = 0.5f;		//Wait time to start spawn chicken
	public float speedChicken;		//Moving speed of chickens on the way
	public int HeathChicken;

//	private GameManagerBehavior gameManager;

	bool check_NextWave = false;		//Variable checks the interval between two waves spawn chicken
	public float timeSpawn;

	public GameObject ChickenHouse,ChickenHunt;

	public bool lastSpawnChicken,loop,huntAlone;		//Mark last chicken spawn, to find the last chicken spawn
	private int i = 0;

//	public int rateSpawnItem, rateSpawnPower, rateSpawnGun;
//	public GameObject[] GunPrefab;
//	public GameObject itemPrefab, PowerPrefab;

	void Start () {
//		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
	}
	void OnEnable()
	{
		i = 0;
		check_NextWave = false;
		StartCoroutine (WaitTimeBeginWave(timeBeginWaves));
//		gameManager.MaxWave = waves.enemyPrefab.Length;
	}

	void Update () {
		if (check_NextWave == true)
			
		if (i<waves.enemyPrefab.Length )  //Number of chicken spawn i < Sum chicken can spawn
		{
			GameObject newEnemy = waves.enemyPrefab[i].Spawn(waves.enemyPrefab[i].transform.position);
			MoveEnemy MoveNewEnemy = newEnemy.GetComponent<MoveEnemy> ();
			MoveNewEnemy.speed = speedChicken;
			if (MoveNewEnemy.Heath == 0) 
			{
				MoveNewEnemy.Heath = HeathChicken;
			}
			if (loop)
				MoveNewEnemy.loop = true;

			if (huntAlone)
				MoveNewEnemy.huntAlone = true;
			
			//Move all chicken in HouseChicken to move left right
			newEnemy.transform.SetParent (ChickenHouse.transform);
			switch (waves.numberWave [i]) {
			case 1:
				MoveNewEnemy.waypoints = waypoints;
				break;
			case 2:
				MoveNewEnemy.waypoints = waypoints2;
				break;
			case 3:
				MoveNewEnemy.waypoints = waypoints3;
				break;
			case 4:
				MoveNewEnemy.waypoints = waypoints4;
				break;
			case 5:
				MoveNewEnemy.waypoints = waypoints5;
				break;
			case 6:
				MoveNewEnemy.waypoints = waypoints6;
				break;
			case 7:
				MoveNewEnemy.waypoints = waypoints7;
				break;
			}

			check_NextWave = false;
			if ((i + 1) < waves.enemyPrefab.Length)
				StartCoroutine (WaitBetween2Chicken ());
			else {
				//If last chicken spawn of last turn chicken in waves , so remarked
				if (lastSpawnChicken) {
					MoveNewEnemy.lastSpawnChicken = true;
					//Report to levelmanager is spawned all chicken
					GameObject.Find ("LevelManager").GetComponent<LevelManager> ().spawnedAll = true;

					//Move all spawn chicken into grid to control
					GetComponentInParent<ChickenControl> ().MakeArrayWithChicken ();
				}
			}
		}
	
	}

	/// <summary>
	/// Wait time index to start spawn
	/// </summary>
	/// <returns>The time begin wave.</returns>
	/// <param name="index">Index.</param>
	IEnumerator WaitTimeBeginWave(float index)
	{
		yield return new WaitForSeconds (index);
		check_NextWave = true;
	}

	/// <summary>
	/// WaitBetween2Chicken
	/// </summary>
	/// <returns>The between2 chicken.</returns>
	IEnumerator WaitBetween2Chicken()
	{
		yield return new WaitForSeconds (timeSpawn);
		i++;
		check_NextWave = true;
	}
}
