using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

	public string animasi_maju;
	public string animasi_balik;
	public string element;
	public string TypeS;
	public void PlayMaju () {
		GetComponent<Animator> ().Play (animasi_maju);
	}

	public void PlayBalik () {
		GetComponent<Animator> ().Play (animasi_balik);
	}

}
