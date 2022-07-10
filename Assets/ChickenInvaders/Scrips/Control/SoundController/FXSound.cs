using UnityEngine;
using System.Collections;

public class FXSound : MonoBehaviour {
	public static FXSound THIS;
	[HideInInspector]
	public AudioSource fxSound;
	public AudioSource SoundGun;
	public AudioClip none;
	public AudioClip ButtonClick;
	public AudioClip BonusTime;
	public AudioClip PlayerWin;
	public AudioClip PlayerDie1;
	public AudioClip PlayerDie2;
	public AudioClip FinishCountCoins;
	public AudioClip PlayerGetItem;
	public AudioClip PlayerGun1;
	public AudioClip PlayerGun2;
	public AudioClip PlayerGun3;
	public AudioClip StoneDestruction;
	public AudioClip ChickenFly;
	public AudioClip[] ChickenDie;
	public AudioClip[] PlayerDie;
	public AudioClip[] coinPickup;
	public AudioClip[] BossDie;
	public AudioClip[] RandomCoins;
	public AudioClip SpinningSound;
	public AudioClip SpinningLose;
	public AudioClip DisActiveBtn;
	public AudioClip Camera;
	public AudioClip Gift1;
	public AudioClip Gift2;
	public AudioClip GiftSuccess;
    // Use this for initialization

    void Awake()
    {
        if (THIS == null)
        {
            THIS = this;
            fxSound = GetComponent<AudioSource>();
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Sound");
            DontDestroyOnLoad(gameObject);            
        }
        else if (THIS != this)
        {
            Destroy(gameObject);
        }
    }

	public void Sound_GunStype1()
	{
		SoundGun.clip =PlayerGun1;
		SoundGun.Play ();
		SoundGun.loop =true;
	}
	public void Sound_GunStype2()
	{
		SoundGun.clip =PlayerGun2;
		SoundGun.Play ();
		SoundGun.loop =true;
	}
	public void Sound_GunStype3()
	{
		SoundGun.clip =PlayerGun3;
		SoundGun.Play ();
		SoundGun.loop =true;
	}
	public void SoundGunStop()
	{
		SoundGun.Stop ();
	}
	public void Sound_Timecount()
	{
		SoundGun.clip = FinishCountCoins;
		SoundGun.Play ();
	}
	public void PlayerWinMethod()
	{
		SoundGun.PlayOneShot(PlayerWin);
	}
}
