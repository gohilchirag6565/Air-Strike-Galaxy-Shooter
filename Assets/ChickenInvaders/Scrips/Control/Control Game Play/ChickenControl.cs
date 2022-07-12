using UnityEngine;
using System.Collections;

/// <summary>
/// Dieu khien chicken hunt Player 
/// </summary>
public class ChickenControl : MonoBehaviour {
	public GameObject ChickenHouse, ChickenStartHunt;
	public bool checkHunt,willSpawnBullet;
	public float timeHunt,timeBeginHunt = 2, HeSovy = 0.1f,HeSoElapse_time = 2f;
	public GameObject[] chicken;

	bool beginHunt;
	float timeCount;
	int chickenCount = 0;

	// Use this for initialization
	void Start () {
		GameObject.Find ("ChickenHouse").GetComponent<RandomBulletEnemy> ().begin = willSpawnBullet;
	}
	
	// Update is called once per frame
	void Update () {
		if (beginHunt) {
			timeCount += Time.deltaTime;


	 ////////////////////////////////0.5f la khoang time giua 2 chicken hunt player////////////////////////////////
			if (timeCount > 0.5f) {
				if (GameObject.Find ("Player_ingame")) {
					//Tim chicken gan nhat chua bi die
					if (chickenCount < 35) {
						while (!chicken [chickenCount] && chickenCount < 34) {
							chickenCount++;
						}
						if (chicken [chickenCount]) {
							chicken [chickenCount].GetComponent<MoveEnemy> ().checkInHunt = true;
							chicken [chickenCount].GetComponent<MoveEnemy> ().ChickenHouse = ChickenHouse;
							chicken [chickenCount].GetComponent<MoveEnemy> ().ChickenStartHunt = ChickenStartHunt;
//					chicken [chickenCount].GetComponent<MoveEnemy> ().beginHunt = true;
							chicken [chickenCount].GetComponent<MoveEnemy> ().timeHunt = timeHunt;
							if (GameObject.Find ("Player_ingame")) {
								chicken [chickenCount].GetComponent<MoveEnemy> ().moveparabol (
									chicken [chickenCount].transform.position,
									GameObject.Find ("Player_ingame").transform.position,
									timeHunt);
							}
						}
					}
					timeCount = 0;
					if (chickenCount < 35)
						chickenCount++;
				}
			}
		}
	}

	public void MakeArrayWithChicken()
	{
		int max = ChickenHouse.transform.childCount;
		//old 41
		if (max<50)
		for (int i=0; i < max; i++) {
				if (ChickenHouse.transform.GetChild (i).gameObject) {
					ChickenHouse.transform.GetChild (i).GetComponent<MoveEnemy>().HeSovy = HeSovy;
					ChickenHouse.transform.GetChild (i).GetComponent<MoveEnemy> ().HeSoelapse_time = HeSoElapse_time;
					chicken [i] = ChickenHouse.transform.GetChild (i).gameObject;
				}
		}

		StartCoroutine (WaitTime());

//		if (checkHunt)
//			beginHunt = true;
	}

	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds (timeBeginHunt);
		if (checkHunt)
			beginHunt = true;
	}
}
