using UnityEngine;
using System.Collections;

public class MapMove : MonoBehaviour {
	public Vector3 startPotion;
	public Vector3 endPosition;

	public float speed;

	void Start () {

	}

	void Update () {

		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, endPosition, speed * Time.deltaTime);

		if (gameObject.transform.position.Equals (endPosition)) 
			gameObject.transform.position = startPotion;

	}	
			
}
