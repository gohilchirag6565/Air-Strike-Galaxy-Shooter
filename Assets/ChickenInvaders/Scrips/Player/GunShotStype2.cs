using UnityEngine;
using System.Collections;

public class GunShotStype2 : MonoBehaviour {
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
		if (Time.time - lastShotTime > fireRate && !gameManager.gameOver) {
			Shoot();
			lastShotTime = Time.time;
		}
	}

	void OnEnable()
	{
		if (Time.timeScale != 0) {
			GameObject.FindObjectOfType<FXSound> ().Sound_GunStype2 ();
		}
	}

	void Shoot() {
//		value = 12;
		switch (Player.GetComponent<Player>().valuegun) {
		case 1:
			fireRate = 0.1f;
			InstantiateBullet (0,0.6f);
			break;
		case 2:
			fireRate = 0.1f;
			InstantiateBullet (0.1f,0.6f);
			InstantiateBullet (-0.1f,0.6f);
			break;
		case 3:
			fireRate = 0.1f;
			InstantiateBullet (0.2f,0.5f);
			InstantiateBullet (-0.2f,0.5f);
			InstantiateBullet (0,0.6f);
			break;
		case 4:
			fireRate = 0.1f;
			//
			InstantiateBullet (0.24f,0.5f);
			InstantiateBullet (-0.24f,0.5f);
			//
			InstantiateBullet (0.08f,0.6f);
			InstantiateBullet (-0.08f,0.6f);
			break;
		case 5:
			fireRate = 0.1f;
			//
			InstantiateBullet (0.24f, 0.45f);
			InstantiateBullet (-0.24f, 0.45f);
			//
			InstantiateBullet (0.12f, 0.52f);
			InstantiateBullet (-0.12f, 0.52f);
			//
			InstantiateBullet (0, 0.6f);
			break;
		case 6:
			fireRate = 0.091f;
			//
			InstantiateBullet (0.24f, 0.45f);
			InstantiateBullet (-0.24f, 0.45f);
			//
			InstantiateBullet (0.12f, 0.52f);
			InstantiateBullet (-0.12f, 0.52f);
			//
			InstantiateBullet (0, 0.6f);
			break;
		case 7:
			fireRate = 0.083f;
			//
			InstantiateBullet (0.24f, 0.45f);
			InstantiateBullet (-0.24f, 0.45f);
			//
			InstantiateBullet (0.12f, 0.52f);
			InstantiateBullet (-0.12f, 0.52f);
			//
			InstantiateBullet (0, 0.6f);
			break;
		case 8:
			fireRate = 0.075f;
			//
			InstantiateBullet (0.24f, 0.45f);
			InstantiateBullet (-0.24f, 0.45f);
			//
			InstantiateBullet (0.12f, 0.52f);
			InstantiateBullet (-0.12f, 0.52f);
			//
			InstantiateBullet (0, 0.6f);
			break;
		case 9:
			fireRate = 0.067f;
			//
			InstantiateBullet (0.24f, 0.45f);
			InstantiateBullet (-0.24f, 0.45f);
			//
			InstantiateBullet (0.12f, 0.52f);
			InstantiateBullet (-0.12f, 0.52f);
			//
			InstantiateBullet (0, 0.6f);
			break;
		case 10:
			fireRate = 0.059f;
			//
			InstantiateBullet (0.24f, 0.45f);
			InstantiateBullet (-0.24f, 0.45f);
			//
			InstantiateBullet (0.12f, 0.52f);
			InstantiateBullet (-0.12f, 0.52f);
			//
			InstantiateBullet (0, 0.6f);
			break;
		case 11:
			fireRate = 0.051f;
			//
			InstantiateBullet (0.24f, 0.45f);
			InstantiateBullet (-0.24f, 0.45f);
			//
			InstantiateBullet (0.12f, 0.52f);
			InstantiateBullet (-0.12f, 0.52f);
			//
			InstantiateBullet (0, 0.6f);
			break;
		case 12:
			fireRate = 0.045f;
			//
			InstantiateBullet (0.24f, 0.45f);
			InstantiateBullet (-0.24f, 0.45f);
			//
			InstantiateBullet (0.12f, 0.52f);
			InstantiateBullet (-0.12f, 0.52f);
			//
			InstantiateBullet (0, 0.6f);
			break;
		}
	}
	void InstantiateBullet(float x,float y)
	{
		startPosition = new Vector3 (Player.transform.position.x + x,Player.transform.position.y + y, 0);
		endPosition = new Vector3 (Player.transform.position.x + x,Player.transform.position.y + 10.5f, 0);

		GameObject newBullet = bulletPrefab.Spawn(startPosition);
		newBullet.GetComponent<BulletBehavior> ().startPosition = startPosition;
		newBullet.GetComponent<BulletBehavior> ().targetPosition = endPosition;
	}
}
