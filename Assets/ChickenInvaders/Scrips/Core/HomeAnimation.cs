using UnityEngine;
using System.Collections;

public class HomeAnimation : MonoBehaviour {

	public Animator HomeAnimator;
	// Use this for initialization
	void Start () {
		if (HomeAnimator == null) {
			HomeAnimator = GetComponent<Animator> ();
		}
	}
	public void Show()
	{
		if (HomeAnimator == null)
		{
			return;
		}
		HomeAnimator.SetTrigger ("Running");	

	}
	public void Hide ()
	{
		HomeAnimator.SetBool ("Running", false);	
	}
}
