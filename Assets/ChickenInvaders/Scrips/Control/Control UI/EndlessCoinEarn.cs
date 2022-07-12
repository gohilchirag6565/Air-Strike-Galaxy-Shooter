using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndlessCoinEarn : MonoBehaviour 
{
	public Text CoinsEarnText;
	public int coinint;

	// Use this for initialization
	void OnEnable()
	{
		coinint=(int)(GameManagerBehavior.CoinsEarn/10);
		CoinsEarnText.text = "" + (int)(GameManagerBehavior.CoinsEarn/10);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
