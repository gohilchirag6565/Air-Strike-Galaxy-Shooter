using UnityEngine;
using System.Collections;
public enum GameState
{
	HomeScene,
	AdventureScene,
	EndlessScene,
	BeforeStart,
	SettingPopup,
}
public class TrackingSceneController : MonoBehaviour {
	public static TrackingSceneController THIS;
	public static TrackingSceneController Instance
	{
		get{ 
			return THIS;
		}
	}
	public GameState gameState;
	void Awake()
	{
		if (THIS == null) {
			THIS = this;
			DontDestroyOnLoad (gameObject);
		} else if (THIS != this) {
			Destroy (gameObject);
		}
		gameState = GameState.HomeScene;
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
