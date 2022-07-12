using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class EscapeEvent : MonoBehaviour
{
		/// <summary>
		/// The name of the scene to be loaded.
		/// </summary>
		public string sceneName;

		public GameObject dialog_load;

		/// <summary>
		/// Whether to leave the application on escape click.
		/// </summary>
		public bool leaveTheApplication;

		/// <summary>
		/// The async operation instance.
		/// </summary>
		private AsyncOperation async;

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape)) {
						OnClick ();
		
				}
		}

		void OnEnable()
		{
		}
		
		/// <summary>
		/// On Escape click event.
		/// </summary>
		public void OnClick ()
		{

				if (leaveTheApplication) {
					dialog_load.SetActive(true);
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
