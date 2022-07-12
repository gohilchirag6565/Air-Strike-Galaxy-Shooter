using UnityEngine;
using System.Collections;

public class GunShotStype1 : MonoBehaviour {
	public float fireRate;
	public float lastShotTime;
	public GameObject bulletPrefab;
	public GameObject Player;
	private GameManagerBehavior gameManager;
	Vector3 startPosition,endPosition;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}

	void Update () {
		if (Time.time - lastShotTime > fireRate && !gameManager.gameOver ) {
			Shoot();
			lastShotTime = Time.time;
		}
	}

	void OnEnable()
	{
		if(Time.timeScale!=0)
		{
			GameObject.FindObjectOfType<FXSound> ().Sound_GunStype1();
		}

	}

	void Shoot() {
//		value = 11;
		switch (Player.GetComponent<Player>().valuegun) {
		case 1:
			InstantiateBullet (0,0.6f);
			break;
		case 2:
			InstantiateBullet (0.08f,0.6f);
			InstantiateBullet (-0.08f,0.6f);
			break;
		case 3:
			InstantiateBullet (0.15f,0.5f);
			InstantiateBullet (-0.15f,0.5f);
			//
			InstantiateBullet (0,0.6f);
			break;
		case 4:
			//
			InstantiateBulletRotate (1.1f,0.6f,0);
			InstantiateBulletRotate (-1.1f,0.6f,0);
			//
			InstantiateBullet (0,0.6f);
			break;
		case 5:
			//
			InstantiateBulletRotate (1.8f,0.6f,0);
			InstantiateBulletRotate (-1.8f,0.6f,0);
			//
			InstantiateBulletRotate (0.6f,0.6f,0);
			InstantiateBulletRotate (-0.6f,0.6f,0);
			break;
		case 6:
			InstantiateBulletRotate (2.4f,0.6f,0);
			InstantiateBulletRotate (-2.4f,0.6f,0);
			//
			InstantiateBulletRotate (1.2f,0.6f,0);
			InstantiateBulletRotate (-1.2f,0.6f,0);
			//
			InstantiateBullet (0, 0.6f);
			break;
		case 7:
			InstantiateBulletRotate (2.4f,0.6f,0);
			InstantiateBulletRotate (-2.4f,0.6f,0);
			//
			InstantiateBulletRotate (1.2f,0.6f,0);
			InstantiateBulletRotate (-1.2f,0.6f,0);
			//
			InstantiateBullet (0.1f,0.6f);
			InstantiateBullet (-0.1f,0.6f);
			break;
		case 8:
			InstantiateBulletRotate (2.4f,0.6f,0);
			InstantiateBulletRotate (-2.4f,0.6f,0);
			//
			InstantiateBulletRotate (1.2f,0.6f,0);
			InstantiateBulletRotate (-1.2f,0.6f,0);
			//
			InstantiateBullet (0.15f,0.6f);
			InstantiateBullet (-0.15f,0.6f);
			//
			InstantiateBullet (0,0.6f);
			break;
		case 9:
			InstantiateBulletRotate (2.4f,0.6f,0);
			InstantiateBulletRotate (-2.4f,0.6f,0);
			//
			InstantiateBulletRotate (1.283f,0.6f,0.083f);
			InstantiateBulletRotate (1.117f,0.6f,-0.083f);
			//
			InstantiateBulletRotate (-1.283f,0.6f,-0.083f);
			InstantiateBulletRotate (-1.117f,0.6f,0.083f);
			//
			InstantiateBullet (0.08f,0.6f);
			InstantiateBullet (-0.08f,0.6f);
			break;
		case 10:
			InstantiateBulletRotate (2.486f,0.6f,0.086f);
			InstantiateBulletRotate (2.314f,0.6f,-0.086f);
			//
			InstantiateBulletRotate (-2.486f,0.6f,-0.086f);
			InstantiateBulletRotate (-2.314f,0.6f,0.086f);
			//
			InstantiateBulletRotate (1.283f,0.6f,0.083f);
			InstantiateBulletRotate (1.117f,0.6f,-0.083f);
			//
			InstantiateBulletRotate (-1.283f,0.6f,-0.083f);
			InstantiateBulletRotate (-1.117f,0.6f,0.083f);
			//
			InstantiateBullet (0.08f,0.6f);
			InstantiateBullet (-0.08f,0.6f);
			break;
		case 11:
			InstantiateBulletRotate (3.086f,0.6f,0.086f);
			InstantiateBulletRotate (2.914f,0.6f,-0.086f);
			//
			InstantiateBulletRotate (-3.086f,0.6f,-0.086f);
			InstantiateBulletRotate (-2.914f,0.6f,0.086f);
			//
			InstantiateBulletRotate (1.882f,0.6f,0.082f);
			InstantiateBulletRotate (1.718f,0.6f,-0.082f);
			//
			InstantiateBulletRotate (-1.882f,0.6f,-0.082f);
			InstantiateBulletRotate (-1.718f,0.6f,0.082f);
			//
			InstantiateBulletRotate (0.68f,0.6f,0.08f);
			InstantiateBulletRotate (0.52f,0.6f,-0.08f);
			//
			InstantiateBulletRotate (-0.68f,0.6f,-0.08f);
			InstantiateBulletRotate (-0.52f,0.6f,0.08f);
			break;
		case 12:
			InstantiateBulletRotate (3.689f,0.6f,0.089f);
			InstantiateBulletRotate (3.511f,0.6f,-0.089f);
			//
			InstantiateBulletRotate (-3.689f,0.6f,-0.089f);
			InstantiateBulletRotate (-3.511f,0.6f,0.089f);
			//
			InstantiateBulletRotate (2.486f,0.6f,0.086f);
			InstantiateBulletRotate (2.314f,0.6f,-0.086f);
			//
			InstantiateBulletRotate (-2.486f,0.6f,-0.086f);
			InstantiateBulletRotate (-2.314f,0.6f,0.086f);
			//
			InstantiateBulletRotate (1.283f,0.6f,0.083f);
			InstantiateBulletRotate (1.117f,0.6f,-0.083f);
			//
			InstantiateBulletRotate (-1.283f,0.6f,-0.083f);
			InstantiateBulletRotate (-1.117f,0.6f,0.083f);
			//
			InstantiateBullet (0.08f,0.6f);
			InstantiateBullet (-0.08f,0.6f);
			break;
		}
	}
	void InstantiateBullet(float x,float y)
	{
		startPosition = new Vector3 (Player.transform.position.x + x,Player.transform.position.y + y+0.1f, 0);
		endPosition = new Vector3 (Player.transform.position.x + x,Player.transform.position.y + 10.5f, 0);

		GameObject newBullet = bulletPrefab.Spawn(startPosition);
		newBullet.GetComponent<BulletBehavior> ().startPosition = startPosition;
		newBullet.GetComponent<BulletBehavior> ().targetPosition = endPosition;
	}

	void InstantiateBulletRotate(float x,float y, float z)
	{
		startPosition = new Vector3 (Player.transform.position.x +z,Player.transform.position.y + y+0.1f, 0);
		endPosition = new Vector3 (Player.transform.position.x + x,Player.transform.position.y + 10.5f, 0);

		GameObject newBullet = bulletPrefab.Spawn(startPosition);
		newBullet.GetComponent<BulletBehavior> ().startPosition = startPosition;
		newBullet.GetComponent<BulletBehavior> ().targetPosition = endPosition;

		Vector3 newDirection = (endPosition - startPosition);
		float i = newDirection.x;
		float j = newDirection.y;
		float rotationAngle = Mathf.Atan2 (j, i) * 180 / Mathf.PI - 90f;
		newBullet.transform.rotation = Quaternion.AngleAxis (rotationAngle, Vector3.forward);
	}
}
