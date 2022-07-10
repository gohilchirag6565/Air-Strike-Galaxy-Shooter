using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public static Music THIS;
	[HideInInspector]
	public AudioSource musicAudioSource;
	// Use this for initialization
	public AudioClip[] music;


    void Awake()
    {
        if (THIS == null)
        {
            THIS = this;
            musicAudioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Music");
        }
        else if (THIS != this)
        {
            Destroy(gameObject);
        }
    }
    
}
