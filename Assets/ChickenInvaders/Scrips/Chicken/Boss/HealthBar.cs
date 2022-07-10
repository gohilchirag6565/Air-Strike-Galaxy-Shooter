using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public int maxHealth ;
	public int currentHealth ;
	private float originalScale;
	public static HealthBar instance;


	void Start () {
		instance = this;
		maxHealth = GameObject.FindGameObjectWithTag ("boss").GetComponent<MoveEnemy> ().Heath;
		currentHealth = maxHealth;

		originalScale = gameObject.transform.localScale.x;	
//		Debug.Log(originalScale+" "+maxHealth);
	}

	
	// Update is called once per frame
	void Update () {
		Vector3 tmpScale = gameObject.transform.localScale;
		tmpScale.x = (float)currentHealth / (float)maxHealth * originalScale;
		gameObject.transform.localScale = tmpScale;	

	}
}
