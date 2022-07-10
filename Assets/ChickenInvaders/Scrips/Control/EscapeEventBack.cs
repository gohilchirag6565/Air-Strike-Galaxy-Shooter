using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class EscapeEventBack : MonoBehaviour
{
	/// <summary>
	/// The name of the scene to be loaded.
	/// </summary>
	public string sceneName;

	public GameObject Map_GameObject,Panel;

	/// <summary>
	/// Whether to leave the application on escape click.
	/// </summary>
	public bool leaveTheApplication;

	/// <summary>
	/// The async operation instance.
	/// </summary>
	private AsyncOperation async;

	void OnEnable()
	{
		Map_GameObject.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			OnClick ();
		}
	}

	/// <summary>
	/// On Escape click event.
	/// </summary>
	public void OnClick ()
	{
		Time.timeScale = 1;
		if (leaveTheApplication) {
			///					quang cao + dialog
			//					GameObject.Find ("ExitConfirmDialog").GetComponent<ConfirmDialog> ().Show ();
//			Time.timeScale = 1;
			Panel.SetActive(false);
			Map_GameObject.SetActive (true);
		} 
			if (!string.IsNullOrEmpty (sceneName)) {
				StartCoroutine ("LoadSceneAsync");
			}
	}

	/// <summary>
	/// Loads the scene Async.
	/// </summary>
	IEnumerator LoadSceneAsync ()
	{
		if (!string.IsNullOrEmpty (sceneName)) {
			async = SceneManager.LoadSceneAsync (sceneName);
			while (!async.isDone) {
				yield return 0;
				Time.timeScale=1;
			}
		}
		//		Application.loadedLevelName;
	}
}
