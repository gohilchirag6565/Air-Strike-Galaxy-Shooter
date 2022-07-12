using UnityEngine;
using System.Collections;

public class GunShotStype3 : MonoBehaviour {
	public float fireRate;
	public float lastShotTime;
	public GameObject[] bulletPrefab;
	public GameObject Player;
	private GameManagerBehavior gameManager;
	Vector3 startPosition,endPosition;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}

	void Update () {
		if (Time.time - lastShotTime > fireRate && !gameManager.gameOver) {
			Shoot();
			lastShotTime = Time.time;
		}
	}

	void OnEnable()
	{
		if (Time.timeScale != 0) {
			GameObject.FindObjectOfType<FXSound> ().Sound_GunStype3 ();
		}
	}

	void Shoot() {
//		value = 4;
		switch (Player.GetComponent<Player>().valuegun) {
		case 1:
			InstantiateBullet (0,0.6f,0);
			break;
		case 2:
			InstantiateBullet (0,0.6f,1);
			break;
		case 3:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,0);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,0);
			//
			InstantiateBullet (0,0.6f,0);
			break;
		case 4:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,0);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,0);
			//
			InstantiateBullet (0,0.6f,1);
			break;
		case 5:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,0);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,0);
			//
			InstantiateBullet (0,0.6f,2);
			break;
		case 6:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,1);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,1);
			//
			InstantiateBullet (0,0.6f,1);
			break;
		case 7:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,1);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,1);
			//
			InstantiateBullet (0,0.6f,2);
			break;
		case 8:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,1);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,1);
			//
			InstantiateBullet (0,0.6f,3);
			break;
		case 9:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,2);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,2);
			//
			InstantiateBullet (0,0.6f,2);
			break;
		case 10:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,2);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,2);
			//
			InstantiateBullet (0,0.6f,3);
			break;
		case 11:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,3);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,3);
			//
			InstantiateBullet (0,0.6f,2);
			break;
		case 12:
			InstantiateBulletRotate (1.2f,0.6f,0.27f,3);
			InstantiateBulletRotate (-1.2f,0.6f,-0.27f,3);
			//
			InstantiateBullet (0,0.6f,3);
			break;
		}
	}
	void InstantiateBullet(float x,float y,int bullet)
	{
		startPosition = new Vector3 (Player.transform.position.x ,Player.transform.position.y + y, 0);
		endPosition = new Vector3 (Player.transform.position.x + x,Player.transform.position.y + 10.5f, 0);

		GameObject newBullet = bulletPrefab[bullet].Spawn(startPosition);
		newBullet.GetComponent<BulletBehavior> ().startPosition = startPosition;
		newBullet.GetComponent<BulletBehavior> ().targetPosition = endPosition;
	}

	void InstantiateBulletRotate(float x,float y, float z, int bullet)
	{
		startPosition = new Vector3 (Player.transform.position.x + z,Player.transform.position.y + y, 0);
		endPosition = new Vector3 (Player.transform.position.x + x,Player.transform.position.y + 10.5f, 0);

		GameObject newBullet = bulletPrefab[bullet].Spawn(startPosition);
		newBullet.GetComponent<BulletBehavior> ().startPosition = startPosition;
		newBullet.GetComponent<BulletBehavior> ().targetPosition = endPosition;

		Vector3 newDirection = (endPosition - startPosition);
		float i = newDirection.x;
		float j = newDirection.y;
		float rotationAngle = Mathf.Atan2 (j, i) * 180 / Mathf.PI - 90f;
		newBullet.transform.rotation = Quaternion.AngleAxis (rotationAngle, Vector3.forward);
	}
}
