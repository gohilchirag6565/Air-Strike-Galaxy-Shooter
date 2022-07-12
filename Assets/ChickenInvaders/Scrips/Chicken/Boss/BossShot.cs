using UnityEngine;
using System.Collections;

public class BossShot : MonoBehaviour {
	public float fireRate,speedBullet;	//toc do dan truyen vao khi instante
	public float lastShotTime;
	public GameObject bulletPrefab, bulletBossControl;	
	public GameObject Boss;
	public int totalBullet,countBullet = 0,valueStypeGun;
	// valueStypeGun quy dinh kieu ban cua turn dan
	//countBullet so dan da ban ra
	//totalBullet tong so dan trong turn

	//	private GameManagerBehavior gameManager;
	Vector3 startPosition,endPosition;

	// Use this for initialization
	void Start () {
	//		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}

	void Update () {
		
		if (Time.time - lastShotTime > fireRate && countBullet < totalBullet) {
			if (GameObject.Find("Player_ingame")) 
				Shoot ();

			lastShotTime = Time.time;

		} 
//		else if (countBullet >= totalBullet) {
//			bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
//			countBullet = 0;
//		}
	}

	void Shoot() {
		//		value = 11;
		switch (valueStypeGun) {
		case 1:
			//Stype Boss lv4,8

			InstantiateBulletRotate (-4f, -6.92f);
			InstantiateBulletRotate (-2.6f, -7.5f);
			InstantiateBulletRotate (-1.4f, -7.9f);
			InstantiateBulletRotate (0, -8f);
			InstantiateBulletRotate (1.4f, -7.9f);
			InstantiateBulletRotate (2.6f, -7.5f);
			InstantiateBulletRotate (4f, -6.92f);

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 2:
			//Stype boss lv 4,8
			InstantiateBulletRotate ((GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y)*2);
			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 3:

			//Stype Boss lv 4
			StartCoroutine (Wait(0,0,-7.9f, -1.4f));

//			InstantiateBulletRotate (-7.9f, -1.4f);
//			InstantiateBulletRotate (-7.5f, -2.6f);
//			InstantiateBulletRotate (-6.9f, -4f);
//			InstantiateBulletRotate (-6.13f, -5.15f);S
//			InstantiateBulletRotate (-5.15f, -6.13f);
//			InstantiateBulletRotate (-4f, -6.92f);S
//			InstantiateBulletRotate (-2.6f, -7.5f);
//			InstantiateBulletRotate (-1.4f, -7.9f);
//			InstantiateBulletRotate (0, -8f);
//			InstantiateBulletRotate (1.4f, -7.9f);
//			InstantiateBulletRotate (2.6f, -7.5f);
//			InstantiateBulletRotate (4f, -6.92f);
//			InstantiateBulletRotate (5.15f, -6.13f);
//			InstantiateBulletRotate (6.13f, -5.15f);
//			InstantiateBulletRotate (6.9f, -4f);
//			InstantiateBulletRotate (7.5f, -2.6f);
//			InstantiateBulletRotate (7.9f, -1.4f);
//			InstantiateBulletRotate (8f, 0f);
//			InstantiateBulletRotate (7.9f, 1.4f);
//			InstantiateBulletRotate (7.5f, 2.6f);
//			InstantiateBulletRotate (6.9f, 4f);
//			InstantiateBulletRotate (6.13f, 5.15f);
//			InstantiateBulletRotate (5.15f, 6.13f);
//			InstantiateBulletRotate (4f, 6.92f);

			countBullet++;
//
//			if (countBullet >= totalBullet) {
//				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
//				countBullet = 0;
//			}
			break;
		case 4:
			//Stype Boss lv 8
			StartCoroutine (Wait2(-7.9f, -1.4f));
			countBullet++;
			break;

		case 5:
			//Stype 1 Boss lv 12
			InstantiateBullet (0, -1.7f);
			InstantiateBullet (0.92f, -1.55f);
			InstantiateBullet (-0.92f, -1.55f);

			InstantiateBulletRotateMAX (0.92f, -1.55f, -1.4f, -7.9f);
			InstantiateBulletRotateMAX (0.92f, -1.55f, -6.13f, -5.15f);
			InstantiateBulletRotateMAX (0.92f, -1.55f, -8f, 0);
			InstantiateBulletRotateMAX (0.92f, -1.55f, -6.13f, 5.15f);
			InstantiateBulletRotateMAX (0.92f, -1.55f, -1.4f, 7.9f);
			InstantiateBulletRotateMAX (0.92f, -1.55f, 4f, -6.92f);
			InstantiateBulletRotateMAX (0.92f, -1.55f, 7.5f, -2.73f);
			InstantiateBulletRotateMAX (0.92f, -1.55f, 7.5f, 2.73f);
			InstantiateBulletRotateMAX (0.92f, -1.55f, 4f, 6.92f);

			InstantiateBulletRotateMAX (-0.92f, -1.55f, -1.4f, -7.9f);
			InstantiateBulletRotateMAX (-0.92f, -1.55f, -6.13f, -5.15f);
			InstantiateBulletRotateMAX (-0.92f, -1.55f, -8f, 0);
			InstantiateBulletRotateMAX (-0.92f, -1.55f, -6.13f, 5.15f);
			InstantiateBulletRotateMAX (-0.92f, -1.55f, -1.4f, 7.9f);
			InstantiateBulletRotateMAX (-0.92f, -1.55f, 4f, -6.92f);
			InstantiateBulletRotateMAX (-0.92f, -1.55f, 7.5f, -2.73f);
			InstantiateBulletRotateMAX (-0.92f, -1.55f, 7.5f, 2.73f);
			InstantiateBulletRotateMAX (-0.92f, -1.55f, 4f, 6.92f);

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;

		case 6:
			//Stype 2 Boss Level 12
			InstantiateBulletRotateMAX (0, -1.7f,(GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y+1.7f)*2);

			InstantiateBulletRotateMAX (-0.92f, -1.55f,(GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x+0.92f)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y+1.55f)*2);

			InstantiateBulletRotateMAX (0.92f, -1.55f,(GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x-0.92f)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y+1.55f)*2);

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 7:
			//Stype 3 Boss Level 12
			InstantiateBulletRotateMAX (-0.92f, -1.55f, (GameObject.Find ("Player_ingame").transform.position.x - Boss.transform.position.x + 0.92f) * 2,
				(GameObject.Find ("Player_ingame").transform.position.y - Boss.transform.position.y + 1.55f) * 2);

			InstantiateBulletRotateMAX (0, -1.7f,-2.6f, -7.5f);
			InstantiateBulletRotateMAX (0, -1.7f,2.6f, -7.5f);
			InstantiateBulletRotateMAX (0, -1.7f,0, -8f);
			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 8:
			//Stype 1 Boss lv 16
//			InstantiateBullet (0, -1.16f);
//			InstantiateBullet (-0.64f, -0.3f);
//			InstantiateBullet (0.64f, -0.3f);
			if (countBullet == 0) {
				InstantiateBulletRotateMAX (0.64f, -0.3f, 1.4f, -7.9f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, 6.13f, -5.15f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, 8f, 0);
				InstantiateBulletRotateMAX (0.64f, -0.3f, 6.13f, 5.15f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, 1.4f, 7.9f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, -4f, -6.92f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, -7.5f, -2.73f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, -7.5f, 2.73f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, -4f, 6.92f);

				InstantiateBulletRotateMAX (-0.64f, -0.3f, 1.4f, -7.9f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, 6.13f, -5.15f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, 8f, 0);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, 6.13f, 5.15f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, 1.4f, 7.9f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, -4f, -6.92f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, -7.5f, -2.73f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, -7.5f, 2.73f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, -4f, 6.92f);

				InstantiateBulletRotateMAX (0, -1.16f, -1.4f, -7.9f);
				InstantiateBulletRotateMAX (0, -1.16f, -6.13f, -5.15f);
				InstantiateBulletRotateMAX (0, -1.16f, -8f, 0);
				InstantiateBulletRotateMAX (0, -1.16f, -6.13f, 5.15f);
				InstantiateBulletRotateMAX (0, -1.16f, -1.4f, 7.9f);
				InstantiateBulletRotateMAX (0, -1.16f, 4f, -6.92f);
				InstantiateBulletRotateMAX (0, -1.16f, 7.5f, -2.73f);
				InstantiateBulletRotateMAX (0, -1.16f, 7.5f, 2.73f);
				InstantiateBulletRotateMAX (0, -1.16f, 4f, 6.92f);
			} else {
				InstantiateBulletRotateMAX (0.64f, -0.3f, -1.4f, -7.9f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, -6.13f, -5.15f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, -8f, 0);
				InstantiateBulletRotateMAX (0.64f, -0.3f, -6.13f, 5.15f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, -1.4f, 7.9f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, 4f, -6.92f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, 7.5f, -2.73f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, 7.5f, 2.73f);
				InstantiateBulletRotateMAX (0.64f, -0.3f, 4f, 6.92f);

				InstantiateBulletRotateMAX (-0.64f, -0.3f, -1.4f, -7.9f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, -6.13f, -5.15f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, -8f, 0);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, -6.13f, 5.15f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, -1.4f, 7.9f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, 4f, -6.92f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, 7.5f, -2.73f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, 7.5f, 2.73f);
				InstantiateBulletRotateMAX (-0.64f, -0.3f, 4f, 6.92f);

				InstantiateBulletRotateMAX (0, -1.16f, 1.4f, -7.9f);
				InstantiateBulletRotateMAX (0, -1.16f, 6.13f, -5.15f);
				InstantiateBulletRotateMAX (0, -1.16f, 8f, 0);
				InstantiateBulletRotateMAX (0, -1.16f, 6.13f, 5.15f);
				InstantiateBulletRotateMAX (0, -1.16f, 1.4f, 7.9f);
				InstantiateBulletRotateMAX (0, -1.16f, -4f, -6.92f);
				InstantiateBulletRotateMAX (0, -1.16f, -7.5f, -2.73f);
				InstantiateBulletRotateMAX (0, -1.16f, -7.5f, 2.73f);
				InstantiateBulletRotateMAX (0, -1.16f, -4f, 6.92f);
			}

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 9:
			//Stype Boss lv16

//			InstantiateBullet (0, -1.16f,);
//			InstantiateBullet (-0.64f, -0.3f);
//			InstantiateBullet (0.64f, -0.3f,);

			InstantiateBulletRotateMAX (0.64f, -0.3f,-4f, -6.92f);
			InstantiateBulletRotateMAX (0.64f, -0.3f,-2.6f, -7.5f);
			InstantiateBulletRotateMAX (0.64f, -0.3f,-1.4f, -7.9f);
			InstantiateBulletRotateMAX (0.64f, -0.3f,0, -8f);
			InstantiateBulletRotateMAX (0.64f, -0.3f,1.4f, -7.9f);
			InstantiateBulletRotateMAX (0.64f, -0.3f,2.6f, -7.5f);
			InstantiateBulletRotateMAX (0.64f, -0.3f,4f, -6.92f);

			InstantiateBulletRotateMAX (-0.64f, -0.3f,-4f, -6.92f);
			InstantiateBulletRotateMAX (-0.64f, -0.3f,-2.6f, -7.5f);
			InstantiateBulletRotateMAX (-0.64f, -0.3f,-1.4f, -7.9f);
			InstantiateBulletRotateMAX (-0.64f, -0.3f,0, -8f);
			InstantiateBulletRotateMAX (-0.64f, -0.3f,1.4f, -7.9f);
			InstantiateBulletRotateMAX (-0.64f, -0.3f,2.6f, -7.5f);
			InstantiateBulletRotateMAX (-0.64f, -0.3f,4f, -6.92f);

			InstantiateBulletRotateMAX (0, -1.16f,(GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y+1.16f)*2);

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 10:
			//Stype 2 Boss Level 16
			InstantiateBulletRotateMAX (0, -1.16f,(GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y+1.16f)*2);

			InstantiateBulletRotateMAX (-0.64f, -0.3f,(GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x+0.64f)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y+0.3f)*2);

			InstantiateBulletRotateMAX (0.64f, -0.3f,(GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x-0.64f)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y+0.3f)*2);

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 11:
			//Stype Boss lv20

			InstantiateBulletRotateMAX (0,-1.7f,-4f, -6.92f);
			InstantiateBulletRotateMAX (0,-1.7f,-2.6f, -7.5f);
			InstantiateBulletRotateMAX (0,-1.7f,-1.4f, -7.9f);
			InstantiateBulletRotateMAX (0,-1.7f,0, -8f);
			InstantiateBulletRotateMAX (0,-1.7f,1.4f, -7.9f);
			InstantiateBulletRotateMAX (0,-1.7f,2.6f, -7.5f);
			InstantiateBulletRotateMAX (0,-1.7f,4f, -6.92f);

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 12:
			//Stype Boss lv20

			InstantiateBulletRotateMAX (0, -1.7f,(GameObject.Find("Player_ingame").transform.position.x- Boss.transform.position.x)*2,
				(GameObject.Find("Player_ingame").transform.position.y- Boss.transform.position.y+1.7f)*2);

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 13:
			//Stype Boss lv20

			InstantiateBulletRotateMAXSPEED (speedBullet +countBullet, 0,-1.7f,-4f, -6.92f);
			InstantiateBulletRotateMAXSPEED (speedBullet +countBullet,0,-1.7f,-2.6f, -7.5f);
			InstantiateBulletRotateMAXSPEED (speedBullet +countBullet,0,-1.7f,-1.4f, -7.9f);
			InstantiateBulletRotateMAXSPEED (speedBullet +countBullet,0,-1.7f,0, -8f);
			InstantiateBulletRotateMAXSPEED (speedBullet +countBullet,0,-1.7f,1.4f, -7.9f);
			InstantiateBulletRotateMAXSPEED (speedBullet +countBullet,0,-1.7f,2.6f, -7.5f);
			InstantiateBulletRotateMAXSPEED (speedBullet +countBullet,0,-1.7f,4f, -6.92f);

			countBullet++;

			if (countBullet >= totalBullet) {
				bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
				countBullet = 0;
			}
			break;
		case 14:

			//Stype Boss lv 20

			StartCoroutine (Wait(0,-1.7f,-7.9f, -1.4f));
			countBullet++;

			break;
		}
	}

	/// <summary>
	/// Sinh ra 1 dan ban thang xuong duoi, bat dau tu toa do boss + (x,y)
	/// </summary>
	void InstantiateBullet(float x,float y)
	{
		startPosition = new Vector3 (Boss.transform.position.x + x,Boss.transform.position.y + y, 0);
		endPosition = new Vector3 (Boss.transform.position.x + x,Boss.transform.position.y - 10.5f, 0);

		GameObject newBullet = bulletPrefab.Spawn(startPosition);
		newBullet.GetComponent<BulletEnemy> ().startPosition = startPosition;
		newBullet.GetComponent<BulletEnemy> ().targetPosition = endPosition;

		Vector3 newDirection = (endPosition - startPosition);
		float i = newDirection.x;
		float j = newDirection.y;
		float rotationAngle = Mathf.Atan2 (j, i) * 180 / Mathf.PI - 90f;
		newBullet.transform.rotation = Quaternion.AngleAxis (rotationAngle, Vector3.forward);
	}

	/// <summary>
	/// Sinh ra dan nhung ko thang , can rotate
	/// </summary>

	void InstantiateBulletRotate(float x,float y)
	{
		startPosition = new Vector3 (Boss.transform.position.x,Boss.transform.position.y , 0);
		endPosition = new Vector3 (Boss.transform.position.x + x,Boss.transform.position.y + y, 0);

		GameObject newBullet = bulletPrefab.Spawn(startPosition);
		newBullet.GetComponent<BulletEnemy> ().speed = speedBullet;
		newBullet.GetComponent<BulletEnemy> ().startPosition = startPosition;
		newBullet.GetComponent<BulletEnemy> ().targetPosition = endPosition;

		Vector3 newDirection = (endPosition - startPosition);
		float i = newDirection.x;
		float j = newDirection.y;
		float rotationAngle = Mathf.Atan2 (j, i) * 180 / Mathf.PI - 90f;
		newBullet.transform.rotation = Quaternion.AngleAxis (rotationAngle, Vector3.forward);
	}

	/// <summary>
	/// Sinh ra dan ko thang va ko bat dau tu tam boss, dich + (a,b)
	/// </summary>

	void InstantiateBulletRotateMAX(float x,float y,float a, float b)
	{
		startPosition = new Vector3 (Boss.transform.position.x + x,Boss.transform.position.y + y , 0);
		endPosition = new Vector3 (Boss.transform.position.x + x + a,Boss.transform.position.y + y + b, 0);

		GameObject newBullet = bulletPrefab.Spawn(startPosition);
		newBullet.GetComponent<BulletEnemy> ().speed = speedBullet;
		newBullet.GetComponent<BulletEnemy> ().startPosition = startPosition;
		newBullet.GetComponent<BulletEnemy> ().targetPosition = endPosition;

		Vector3 newDirection = (endPosition - startPosition);
		float i = newDirection.x;
		float j = newDirection.y;
		float rotationAngle = Mathf.Atan2 (j, i) * 180 / Mathf.PI - 90f;
		newBullet.transform.rotation = Quaternion.AngleAxis (rotationAngle, Vector3.forward);
	}

	void InstantiateBulletRotateMAXSPEED(float z,float x,float y,float a, float b)
	{
		startPosition = new Vector3 (Boss.transform.position.x + x,Boss.transform.position.y + y , 0);
		endPosition = new Vector3 (Boss.transform.position.x + x + a,Boss.transform.position.y + y + b, 0);

		GameObject newBullet = bulletPrefab.Spawn(startPosition);
		newBullet.GetComponent<BulletEnemy> ().speed = z;
		newBullet.GetComponent<BulletEnemy> ().startPosition = startPosition;
		newBullet.GetComponent<BulletEnemy> ().targetPosition = endPosition;

		Vector3 newDirection = (endPosition - startPosition);
		float i = newDirection.x;
		float j = newDirection.y;
		float rotationAngle = Mathf.Atan2 (j, i) * 180 / Mathf.PI - 90f;
		newBullet.transform.rotation = Quaternion.AngleAxis (rotationAngle, Vector3.forward);
	}

	IEnumerator Wait(float a,float b,float x,float y)
	{
//		Debug.Log ("dfawefw");
		yield return new WaitForSeconds (0.07f);
		InstantiateBulletRotateMAX (a,b,x, y);
		if (x == -7.9f && y == -1.4f) StartCoroutine (Wait(a,b,-7.5f,-2.6f));
		else if (x == -7.5f && y == -2.6f) StartCoroutine (Wait(a,b,-6.9f, -4f));
		else if (x == -6.9f && y == -4f) StartCoroutine (Wait(a,b,-6.13f, -5.15f));
		else if (x == -6.13f && y == -5.15f) StartCoroutine (Wait(a,b,-5.15f, -6.13f));
		else if (x == -5.15f && y == -6.13f) StartCoroutine (Wait(a,b,-4f, -6.92f));
		else if (x == -4f && y == -6.92f) StartCoroutine (Wait(a,b,-2.6f, -7.5f));
		else if (x == -2.6f && y == -7.5f) StartCoroutine (Wait(a,b,-1.4f, -7.9f));
		else if (x == -1.4f && y == -7.9f) StartCoroutine (Wait(a,b,0, -8f));
		else if (x == 0 && y == -8f) StartCoroutine (Wait(a,b,1.4f, -7.9f));
		else if (x == 1.4f && y == -7.9f) StartCoroutine (Wait(a,b,2.6f, -7.5f));
		else if (x == 2.6f && y == -7.5f) StartCoroutine (Wait(a,b,4f, -6.92f));
		else if (x == 4f && y == -6.92f) StartCoroutine (Wait(a,b,5.15f, -6.13f));
		else if (x == 5.15f && y == -6.13f) StartCoroutine (Wait(a,b,6.13f, -5.15f));
		else if (x == 6.13f && y == -5.15f) StartCoroutine (Wait(a,b,6.9f, -4f));
		else if (x == 6.9f && y == -4f) StartCoroutine (Wait(a,b,7.5f, -2.6f));
		else if (x == 7.5f && y == -2.6f) StartCoroutine (Wait(a,b,7.9f, -1.4f));
		else if (x == 7.9f && y == -1.4f) StartCoroutine (Wait(a,b,8f, 0f));
		else if (x == 8f && y == 0f) StartCoroutine (Wait(a,b,7.9f, 1.4f));
		else if (x == 7.9f && y == 1.4f) StartCoroutine (Wait(a,b,7.5f, 2.6f));
		else if (x == 7.5f && y == 2.6f) StartCoroutine (Wait(a,b,6.9f, 4f));
		else if (x == 6.9f && y == 4f) StartCoroutine (Wait(a,b,6.13f, 5.15f));
		else if (x == 6.13f && y == 5.15f) StartCoroutine (Wait(a,b,5.15f, 6.13f));
		else if (x == 5.15f && y == 6.13f) StartCoroutine (Wait(a,b,4f, 6.92f));
		if (x == 4f && y == 6.92f)
		{
			bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
			countBullet = 0;
		}
	}

	IEnumerator Wait2(float x,float y)
	{
		yield return new WaitForSeconds (0.07f);
		InstantiateBulletRotate (x, y);
		if (x == -7.9f && y == -1.4f) StartCoroutine (Wait2(-7.5f,-2.6f));
		else if (x == -7.5f && y == -2.6f) StartCoroutine (Wait2(-6.9f, -4f));
		else if (x == -6.9f && y == -4f) StartCoroutine (Wait2(-6.13f, -5.15f));
		else if (x == -6.13f && y == -5.15f) StartCoroutine (Wait2(-5.15f, -6.13f));
		else if (x == -5.15f && y == -6.13f) StartCoroutine (Wait2(-4f, -6.92f));
		else if (x == -4f && y == -6.92f) StartCoroutine (Wait2(-2.6f, -7.5f));
		else if (x == -2.6f && y == -7.5f) StartCoroutine (Wait2(-1.4f, -7.9f));
		else if (x == -1.4f && y == -7.9f) StartCoroutine (Wait2(0, -8f));
		else if (x == 0 && y == -8f) StartCoroutine (Wait2(1.4f, -7.9f));
		else if (x == 1.4f && y == -7.9f) StartCoroutine (Wait2(2.6f, -7.5f));
		else if (x == 2.6f && y == -7.5f) StartCoroutine (Wait2(4f, -6.92f));
		else if (x == 4f && y == -6.92f) StartCoroutine (Wait2(5.15f, -6.13f));
		else if (x == 5.15f && y == -6.13f) StartCoroutine (Wait2(6.13f, -5.15f));
		else if (x == 6.13f && y == -5.15f) StartCoroutine (Wait2(6.9f, -4f));
		else if (x == 6.9f && y == -4f) StartCoroutine (Wait2(7.5f, -2.6f));
		else if (x == 7.5f && y == -2.6f) StartCoroutine (Wait2(7.9f, -1.4f));

		else if (x == 7.9f && y == -1.4f) StartCoroutine (Wait2(7.51f, -2.61f));
		else if (x == 7.51f && y == -2.61f) StartCoroutine (Wait2(6.91f, -4.01f));
		else if (x == 6.91f && y == -4.01f) StartCoroutine (Wait2(6.131f, -5.151f));
		else if (x == 6.131f && y == -5.151f) StartCoroutine (Wait2(5.151f, -6.131f));
		else if (x == 5.151f && y == -6.131f) StartCoroutine (Wait2(4.01f, -6.921f));
		else if (x == 4.01f && y == -6.921f) StartCoroutine (Wait2(2.61f, -7.51f));
		else if (x == 2.61f && y == -7.51f) StartCoroutine (Wait2(1.41f, -7.91f));
		else if (x == 1.41f && y == -7.91f) StartCoroutine (Wait2(0.01f, -8.01f));
		else if (x == 0.01f && y == -8.01f) StartCoroutine (Wait2(-1.41f, -7.91f));
		else if (x == -1.41f && y == -7.91f) StartCoroutine (Wait2(-2.61f, -7.51f));
		else if (x == -2.61f && y == -7.51f) StartCoroutine (Wait2(-4.01f, -6.921f));
		else if (x == -4.01f && y == -6.921f) StartCoroutine (Wait2(-5.151f, -6.131f));
		else if (x == -5.151f && y == -6.131f) StartCoroutine (Wait2(-6.131f, -5.151f));
		else if (x == -6.131f && y == -5.151f) StartCoroutine (Wait2(-6.91f, -4.01f));
		else if (x == -6.91f && y == -4.01f) StartCoroutine (Wait2(-7.51f,-2.61f));

		if (x == -7.51f && y == -2.61f)
		{
			bulletBossControl.GetComponent<BulletBossControl> ().spawnedAll = true;
			countBullet = 0;
		}
	}
}
