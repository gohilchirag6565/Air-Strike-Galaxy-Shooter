using UnityEngine;
using System.Collections;

public class DesTroyParticle : MonoBehaviour {
	private ParticleSystem p;
	public GameObject[] particle;
	public Vector3[] place;

	void Awake () {
		p = gameObject.GetComponent<ParticleSystem> ();
		p.Play ();
	}

	void Update () {
		if (p.isStopped == true) {
			if (particle.Length > 0) {
				for (int i = 0; i < particle.Length; i++)
					particle [i].Spawn (place[i]);
			}
			gameObject.Recycle();
		}
	}
	IEnumerator Destroy()
	{
		gameObject.Recycle();
		yield return null;
	}

}
