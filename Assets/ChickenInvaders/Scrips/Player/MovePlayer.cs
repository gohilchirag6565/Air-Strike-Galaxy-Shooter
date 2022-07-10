using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour {

	// Use this for initialization
	private GameManagerBehavior gameManager;
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}
	
	// Update is called once per frame


	void OnMouseDrag ()
	{
		if (!gameManager.gameOver && Input.touchCount >0) {
			gameObject.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position).x,
				Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position).y,
				-2.0f);
		}

		if (!gameManager.gameOver ) {
			gameObject.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x,
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y,
				-2.0f);
		}
	}
}
