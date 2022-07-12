using UnityEngine;
using System.Collections;

public class RandomBulletEnemy : MonoBehaviour {
	public float timecount,timeSpawnBullet, minSpeedBullet,maxSpeedBullet;
	//timeSpawnBullet  Interval random test to spawn bullet of chicken
	public int rateSpawn, numberRandom;

	public GameObject[] bulletPrefab;

	public int rateSpawnItem, rateSpawnPower , MaxPowerSpawn, SpawnedPower = 0;
	public GameObject[] GunPrefab;
	public GameObject itemPrefab, PowerPrefab, chickenDieEF;

	int numberGetChild;
	public bool begin;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("BoughtItem") == 1) {
			PlayerPrefs.SetInt ("BoughtItem",0);
			rateSpawnItem = 15;
		}

		if (PlayerPrefs.GetInt ("BoughtItem") == 2) {
			PlayerPrefs.SetInt ("BoughtItem",0);
			GameObject newItem = PowerPrefab.Spawn ();
			newItem.GetComponent<MoveItem> ().startPosition = new Vector3(0,6f,0);
			newItem.GetComponent<MoveItem> ().targetPosition = new Vector3(0,-6f,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (begin && GameObject.Find("Player_ingame"))
		{
			timecount += Time.deltaTime;
			if (timecount >= timeSpawnBullet) {
				numberRandom = Random.Range (0, 100);
				if (numberRandom < rateSpawn) {
					if (gameObject.transform.childCount > 1) {
						numberGetChild = Random.Range (0, gameObject.transform.childCount);
						if (gameObject.transform.GetChild (numberGetChild))
							InstantiateBullet (gameObject.transform.GetChild (numberGetChild).transform.position);
					}
				}
				timecount = 0;
			}
		}
	}

	void InstantiateBullet(Vector3 value)
	{
		Vector3 startPosition = new Vector3 (value.x,value.y, 1);
		Vector3 endPosition = new Vector3 (value.x,value.y-10.5f, 1);

		GameObject newBullet = bulletPrefab[Random.Range(0,3)].Spawn(startPosition);
		newBullet.GetComponent<BulletEnemy> ().speed = Random.Range (minSpeedBullet,maxSpeedBullet);
		newBullet.GetComponent<BulletEnemy> ().startPosition = startPosition;
		newBullet.GetComponent<BulletEnemy> ().targetPosition = endPosition;
	}

	public void RandonItem(Vector3 positionChicken)
	{
		Vector3 startPosition = new Vector3 (positionChicken.x,positionChicken.y,1);
		Vector3 endPosition = new Vector3 (positionChicken.x,positionChicken.y-15,1);

		if (SpawnedPower < MaxPowerSpawn && Random.Range (0, 100) <= rateSpawnPower) 
		{
			GameObject newItem = PowerPrefab.Spawn (startPosition);
			newItem.GetComponent<MoveItem> ().startPosition = startPosition;
			newItem.GetComponent<MoveItem> ().targetPosition = endPosition;
			SpawnedPower++;

		} else if (Random.Range (0, 100) <= rateSpawnItem) 
		{
			GameObject newItem;
			if (Random.Range(0,100)< 50)
				newItem = GunPrefab [Random.Range (0, 3)].Spawn (startPosition);
			else 
				newItem = itemPrefab.Spawn(startPosition);
			newItem.GetComponent<MoveItem> ().startPosition = startPosition;
			newItem.GetComponent<MoveItem> ().targetPosition = endPosition;
		} 
		chickenDieEF.Spawn (positionChicken);
	}
}
