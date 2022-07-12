using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour
{
	public bool moveSpecial = false;
	public GameObject EF_TakeItem;
	float timeDelay=0.2f;
	GameObject endCoinPositon;
	void OnEnable(){
		endCoinPositon = GameObject.FindGameObjectWithTag ("Finish");
		transform.GetChild (0).gameObject.SetActive(false);
		if (moveSpecial) {
			gameObject.GetComponentInChildren<CircleCollider2D> ().enabled = false;
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
			StartCoroutine (MoveCoin ());
		} else {
			gameObject.GetComponentInChildren<CircleCollider2D> ().enabled = true;
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if ( other.tag=="Player") {
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
			DestroyCoinPool ();
			StartCoroutine (MoveCoin ());
			EF_TakeItem.Spawn (other.transform.position);
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.coinPickup[Random.Range(0,2)]);
		}

	}

	public IEnumerator MoveCoin ()
	{
		float startTime = 0;
		while (startTime < 1f) {
			startTime += Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, endCoinPositon.transform.position, startTime / 1f);
			yield return new WaitForFixedUpdate ();
		}

		moveSpecial = false;
		gameObject.SetActive (false);

	}
	void DestroyCoinPool()
	{
		
		StartCoroutine(DisableCoin(this.gameObject,timeDelay));
	}
	IEnumerator DisableCoin(GameObject obj,float timeDelay){
		GameManagerBehavior.CoinsEarn++;
		yield return new WaitForSeconds (timeDelay);
		gameObject.Recycle();
	}



}
