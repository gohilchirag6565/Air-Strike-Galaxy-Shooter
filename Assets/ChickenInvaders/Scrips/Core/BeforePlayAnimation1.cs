using UnityEngine;
using System.Collections;

public class BeforePlayAnimation1 : MonoBehaviour {

	public Animator BeforeStartAnimator;
	// Use this for initialization
	void Start () {
		if (BeforeStartAnimator == null) {
			BeforeStartAnimator = GetComponent<Animator> ();
		}
	}
	public void Show()
	{
		if (BeforeStartAnimator == null)
		{
			return;
		}
		BeforeStartAnimator.SetTrigger ("Running");	

	}
	public void Hide ()
	{
		BeforeStartAnimator.SetBool ("Running", false);	
	}
}
