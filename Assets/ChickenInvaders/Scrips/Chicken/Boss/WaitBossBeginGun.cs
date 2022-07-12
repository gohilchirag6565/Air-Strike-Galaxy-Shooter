using UnityEngine;
using System.Collections;

public class WaitBossBeginGun : MonoBehaviour {
	public GameObject shotBoss;

	// Use this for initialization
	void Start () {
		
		StartCoroutine (Wait());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (4f);
		shotBoss.SetActive (true);
	}
}
