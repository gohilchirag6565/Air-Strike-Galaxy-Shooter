using UnityEngine;
using System.Collections;

public class RandomItem : MonoBehaviour {

//	public float timecount,timeSpawnBullet, minSpeedBullet,maxSpeedBullet;
//
//	public int rateSpawn, numberRandom;
//
//	public GameObject[] bulletPrefab;
//
//	int numberGetChild;
//	public bool begin;
//	// Use this for initialization
//	void Start () {
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//		if (begin)
//		{
//			timecount += Time.deltaTime;
//			if (timecount >= timeSpawnBullet) {
//				numberRandom = Random.Range (0, 100);
//				if (numberRandom < rateSpawn) {
//					if (gameObject.transform.childCount > 1) {
//						numberGetChild = Random.Range (0, gameObject.transform.childCount);
//						if (gameObject.transform.GetChild (numberGetChild))
//							InstantiateBullet (gameObject.transform.GetChild (numberGetChild).transform.position);
//					}
//				}
//				timecount = 0;
//			}
//		}
//	}
//
//	void InstantiateBullet(Vector3 value)
//	{
//		Vector3 startPosition = new Vector3 (value.x,value.y, 0);
//		Vector3 endPosition = new Vector3 (value.x,value.y-10.5f, 0);
//
//		GameObject newBullet = bulletPrefab[Random.Range(0,3)].Spawn(startPosition);
//		newBullet.GetComponent<BulletEnemy> ().speed = Random.Range (minSpeedBullet,maxSpeedBullet);
//		newBullet.GetComponent<BulletEnemy> ().startPosition = startPosition;
//		newBullet.GetComponent<BulletEnemy> ().targetPosition = endPosition;
//
//	}

	public void Randomitem()
	{
		
	}
}
