using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject[] Level;
	int level_current;
	private GameManagerBehavior gameManager;
	public bool spawnedAll;
	public static int CheckBuyHeath;
	void Awake () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
	}

	void Start()
	{
		gameManager.MaxWave = Level.Length;
		gameManager.Wave = level_current;
		StartCoroutine (WaitFirstTurn());
	}


	void OnEnable()
	{
		
	}
	int count = 0;
	void Update () {
		if (count == 0 && spawnedAll)
		if (GameObject.FindGameObjectWithTag("enemy") == null &&GameObject.FindGameObjectWithTag("boss") == null && GameObject.Find("Player_ingame")) {
			gameManager.Wave = level_current +1;
			if (level_current < Level.Length-1)
			StartCoroutine(Wait2TurnSpawn());
			GameObject.Find ("ChickenHouse").GetComponent<Animator> ().SetBool ("move",false);
			count = 1;
		}
	}

	public void NextLevel(){
		Level [level_current].SetActive (false);
		level_current++;
		Level [level_current].SetActive (true);
		spawnedAll = false;
	}

	IEnumerator Wait2TurnSpawn(){
		yield return new WaitForSeconds (3f);
		NextLevel ();
		count = 0;
	}
	IEnumerator WaitFirstTurn(){
		yield return new WaitForSeconds (3f);
		Level [level_current].SetActive (true);
	}
}
