using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitLoading());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator WaitLoading()
	{
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene (PlayerPrefs.GetInt("ScenesIDLoad"));
//		Debug.Log(SceneManager.GetActiveScene().name);
//		SceneManager.GetActiveScene().buildIndex
	}
}
