using UnityEngine;
using System.Collections;

public class StopHitBullet : MonoBehaviour {
	Animator ani ;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void stop_animation()
	{
		ani.SetBool ("Hit",false);
	}
}
