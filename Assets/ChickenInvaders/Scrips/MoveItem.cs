using UnityEngine;
using System.Collections;

public class MoveItem : MonoBehaviour {

	public Vector3 startPosition;
	public Vector3 targetPosition;

	private float distance;
	private float startTime;

	public float speed;

	public int valueItem;
	private GameManagerBehavior gameManager;
	public GameObject EF_TakeItem;
	// Use this for initialization
	void Start () {
		
		startTime = Time.time;
		distance = Vector3.Distance (startPosition, targetPosition);

	}
	
	// Update is called once per frame
	void Update () {
		
		float timeInterval = Time.time - startTime;
		gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);
		if (gameObject.transform.position.y < -6f)
			gameObject.Recycle ();

	}
	void OnTriggerEnter2D ( Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			EF_TakeItem.Spawn (other.transform.position);

			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerGetItem);
			switch (valueItem) {
			case 0:
				Player.instance.ChangeStypeGun (0);
				break;
			case 1:
				Player.instance.ChangeStypeGun (1);
				break;
			case 2:
				Player.instance.ChangeStypeGun (2);
				break;
			case 3:
				Player.instance.UplevelGun ();
				break;
			case 4:
				Player.instance.TakePowerBullet ();
				break;
			}
			gameObject.Recycle ();
		}
	}

}
