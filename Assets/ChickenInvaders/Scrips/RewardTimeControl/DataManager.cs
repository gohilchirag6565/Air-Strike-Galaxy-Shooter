using UnityEngine;
using System;
using System.Collections;

public class DataManager : MonoBehaviour 
{

	public static DataManager Instance;

	public int FreeAdNumber
	{ 
		get { return _freeadnum; }
		private set { _freeadnum = value; }
	}
	public int intCheckForAds
	{ 
		get { return _checkforads; }
		private set { _checkforads = value; }
	}
	public int IntAds
	{ 
		get { return _intads; }
		private set { _intads = value; }
	}


	public static event Action<int> FreeAdNumberUpdated = delegate {};
	public static event Action<int> intCheckForAdsUpdated = delegate {};
	public static event Action<int> IntAdsUpdated = delegate {};


	[SerializeField]
	int initialFreeAdNumber = 10;

	[SerializeField]
	int initialcheckads = 0;

	[SerializeField]
	int initialintads = 0;

	[SerializeField]
	int _freeadnum=0;

	[SerializeField]
	int _checkforads=0;

	[SerializeField]
	int _intads=0;


	void Awake()
	{
		//Set all data new
//		PlayerPrefs.DeleteAll ();
		if (Instance)
		{
			DestroyImmediate(gameObject);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void Start()
	{
		Reset();
	}

	public void Reset()
	{
		// Initialize coins
		ResetFreeAds ();
	}
	//----------------------
	public void ResetFreeAds()
	{
		FreeAdNumber = PlayerPrefs.GetInt("FreeAdsNumber", initialFreeAdNumber);
		intCheckForAds = PlayerPrefs.GetInt("CheckForAds", initialcheckads);
		IntAds = PlayerPrefs.GetInt("IntAds", initialintads);

	}

	public void AddFreeAdNumber(int amount)
	{
		FreeAdNumber += amount;
		PlayerPrefs.SetInt("FreeAdsNumber", FreeAdNumber);
		FreeAdNumberUpdated(FreeAdNumber);
	}

	public void RemoveFreeAdNumber(int amount)
	{
		FreeAdNumber -= amount;
		PlayerPrefs.SetInt("FreeAdsNumber", FreeAdNumber);
		FreeAdNumberUpdated(FreeAdNumber);
	}

	//----------------------
	public void AddCheckForADS(int amount)
	{
		intCheckForAds += amount;
		PlayerPrefs.SetInt("CheckForAds", intCheckForAds);
		intCheckForAdsUpdated(intCheckForAds);
	}

	public void RemoveCheckForADS(int amount)
	{
		intCheckForAds -= amount;
		PlayerPrefs.SetInt("CheckForAds", intCheckForAds);
		intCheckForAdsUpdated(intCheckForAds);
	}

	//----------------------

	public void AddIntAds(int amount)
	{
		IntAds += amount;
		PlayerPrefs.SetInt("IntAds", IntAds);
		IntAdsUpdated(IntAds);
	}

	public void RemoveIntAds(int amount)
	{
		IntAds -= amount;
		PlayerPrefs.SetInt("IntAds", IntAds);
		IntAdsUpdated(IntAds);
	}

	//----------------------


}
