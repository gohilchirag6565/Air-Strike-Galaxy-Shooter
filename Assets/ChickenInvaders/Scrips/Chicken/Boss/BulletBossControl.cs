using UnityEngine;
using System.Collections;

public class BulletBossControl : MonoBehaviour {

	public GameObject[] Level;
	int level_current;
	public bool spawnedAll;

	void Awake () {
	}

	void Start()
	{
	}


	void OnEnable()
	{
		Music.THIS.GetComponent<AudioSource> ().Stop ();
		Music.THIS.GetComponent<AudioSource> ().loop = true;
		Music.THIS.GetComponent<AudioSource> ().clip = Music.THIS.music[5];
		Music.THIS.GetComponent<AudioSource> ().Play ();
		Level [level_current].SetActive (true);
	}

	int count = 0;

	void Update () {
		
		if (count == 0 && spawnedAll)
		if (GameObject.FindGameObjectWithTag("Player") != null ) {
			Level [level_current].SetActive (false);
			StartCoroutine(Wait2TurnSpawn());
			count = 1;
		}
	}

	public void NextLevel(){
		if (level_current < Level.Length - 1)
			level_current++;
		else
			level_current = 0;
		Level [level_current].SetActive (true);
		spawnedAll = false;
	}

	IEnumerator Wait2TurnSpawn(){
		yield return new WaitForSeconds (2f);
		NextLevel ();
		count = 0;
	}
}
