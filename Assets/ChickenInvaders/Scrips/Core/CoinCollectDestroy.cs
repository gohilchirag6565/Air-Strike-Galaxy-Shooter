using UnityEngine;
using System.Collections;

public class CoinCollectDestroy : MonoBehaviour {

	IEnumerator Destroy()
	{
		gameObject.Recycle();
		yield return null;
	}
}
