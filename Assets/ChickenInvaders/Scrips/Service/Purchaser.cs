using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class Purchaser : MonoBehaviour, IStoreListener
{
	public Text GoldText;
	public static Purchaser Instance;
	private static IStoreController m_StoreController;
	private static IExtensionProvider m_StoreExtensionProvider;

	public static string PRODUCT_5000_COINS = "galaxy_attack_5000coins";
	public static string PRODUCT_12000_COINS = "galaxy_attack_12000coins";
	public static string PRODUCT_30000_COINS = "galaxy_attack_30000coins";
	public static string PRODUCT_60000_COINS = "galaxy_attack_60000coins";
	public static string PRODUCT_130000_COINS = "galaxy_attack_130000coins";
	public static string PRODUCT_350000_COINS = "galaxy_attack_350000coins";

	void Start ()
	{		
		if (m_StoreController == null) {			
			InitializePurchasing ();
		}
		if (Instance == null) {
			Instance = this;
		}
	}

	void Update()
	{
		GoldText.text = ""+PlayerPrefs.GetInt ("GOLD");
	}

	public void InitializePurchasing ()
	{		
		if (IsInitialized ()) {			
			return;
		}
			

		var builder = ConfigurationBuilder.Instance (StandardPurchasingModule.Instance ());

		builder.AddProduct (PRODUCT_5000_COINS, ProductType.Consumable);
		builder.AddProduct (PRODUCT_12000_COINS, ProductType.Consumable);
		builder.AddProduct (PRODUCT_30000_COINS, ProductType.Consumable);
		builder.AddProduct (PRODUCT_60000_COINS, ProductType.Consumable);
		builder.AddProduct (PRODUCT_130000_COINS, ProductType.Consumable);
		builder.AddProduct (PRODUCT_350000_COINS, ProductType.Consumable);

//		builder.AddProduct (PRODUCT_BEGINNER_25200_COINS, ProductType.Consumable);
//		builder.AddProduct (PRODUCT_LIMITED_12000_COINS, ProductType.Consumable);
//		builder.AddProduct (PRODUCT_LIMITED_50000_COINS, ProductType.Consumable);
//		builder.AddProduct (PRODUCT_LIMITED_250000_COINS, ProductType.Consumable);

		UnityPurchasing.Initialize (this, builder);
	}


	private bool IsInitialized ()
	{		
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}

	public void Buy5000Coins ()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		BuyProductID (PRODUCT_5000_COINS);
	}

	public void Buy12000Coins ()
	{	
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		BuyProductID (PRODUCT_12000_COINS);
	}

	public void Buy30000Coins ()
	{	
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		BuyProductID (PRODUCT_30000_COINS);
	}

	public void Buy60000Coins ()
	{	
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		BuyProductID (PRODUCT_60000_COINS);
	}

	public void Buy130000Coins ()
	{	
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		BuyProductID (PRODUCT_130000_COINS);
	}
	public void Buy350000Coins ()
	{	
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		BuyProductID (PRODUCT_350000_COINS);
	}
		

	/// <summary>
	///  _Event_Event_Event_Event_Event_Event_Event_Event_Event
	/// </summary>
	void BuyProductID (string productId)
	{		
		if (IsInitialized ()) {						
			Product product = m_StoreController.products.WithID (productId);

			if (product != null && product.availableToPurchase) {
				Debug.Log (string.Format ("Purchasing product asychronously: '{0}'", product.definition.id));
				m_StoreController.InitiatePurchase (product);
			} else {				
				Debug.Log ("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		} else {
			Debug.Log ("BuyProductID FAIL. Not initialized.");
		}
	}

	public void RestorePurchases ()
	{		
		if (!IsInitialized ()) 
		{			
			Debug.Log ("RestorePurchases FAIL. Not initialized.");
//			SoundController.Sound.DisactiveButtonSound();
			return;
		}
			
		if (Application.platform == RuntimePlatform.IPhonePlayer
		    || Application.platform == RuntimePlatform.OSXPlayer) {			
			Debug.Log ("RestorePurchases started ...");

		/*	var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions> ();

			apple.RestoreTransactions ((result) => 
				{
//					SoundController.Sound.DisactiveButtonSound();
				Debug.Log ("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});*/
		} else {
//			SoundController.Sound.DisactiveButtonSound();
			Debug.Log ("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}
	//
	// --- IStoreListener
	//
	public void OnInitialized (IStoreController controller, IExtensionProvider extensions)
	{		
		Debug.Log ("OnInitialized: PASS");

		m_StoreController = controller;
		m_StoreExtensionProvider = extensions;
	}

	public void OnInitializeFailed (InitializationFailureReason error)
	{		
		Debug.Log ("OnInitializeFailed InitializationFailureReason:" + error);
	}

	public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs args)
	{
		
		// A consumable product has been purchased by this user.
		if (String.Equals (args.purchasedProduct.definition.id, PRODUCT_5000_COINS, StringComparison.Ordinal)) 
		{
			
			int coin = PlayerPrefs.GetInt ("GOLD") +5000;
			PlayerPrefs.SetInt ("GOLD", coin);
			PlayerPrefs.Save ();
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerGetItem);
		}
		if (String.Equals (args.purchasedProduct.definition.id, PRODUCT_12000_COINS, StringComparison.Ordinal))
		{
			int coin = PlayerPrefs.GetInt ("GOLD") +12000;
			PlayerPrefs.SetInt ("GOLD", coin);
			PlayerPrefs.Save ();
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerGetItem);
		}
		if (String.Equals (args.purchasedProduct.definition.id, PRODUCT_30000_COINS, StringComparison.Ordinal)) 
		{
	
			int coin = PlayerPrefs.GetInt ("GOLD") +30000;
			PlayerPrefs.SetInt ("GOLD", coin);
			PlayerPrefs.Save ();
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerGetItem);
		}
		if (String.Equals (args.purchasedProduct.definition.id, PRODUCT_60000_COINS, StringComparison.Ordinal))
		{
			int coin = PlayerPrefs.GetInt ("GOLD") +60000;
			PlayerPrefs.SetInt ("GOLD", coin);
			PlayerPrefs.Save ();
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerGetItem);
		}
		if (String.Equals (args.purchasedProduct.definition.id, PRODUCT_130000_COINS, StringComparison.Ordinal))
		{
			int coin = PlayerPrefs.GetInt ("GOLD") +130000;
			PlayerPrefs.SetInt ("GOLD", coin);
			PlayerPrefs.Save ();
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerGetItem);
		}
		if (String.Equals (args.purchasedProduct.definition.id, PRODUCT_350000_COINS, StringComparison.Ordinal))
		{
			int coin = PlayerPrefs.GetInt ("GOLD") +350000;
			PlayerPrefs.SetInt ("GOLD", coin);
			PlayerPrefs.Save ();
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.PlayerGetItem);
		}
		//------------


		return PurchaseProcessingResult.Complete;

	}

	public void OnPurchaseFailed (Product product, PurchaseFailureReason failureReason)
	{
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
		// this reason with the user to guide their troubleshooting actions.
		Debug.Log (string.Format ("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}
}
//}
