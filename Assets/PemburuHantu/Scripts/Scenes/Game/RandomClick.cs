using UnityEngine;
using System.Collections;

public class RandomClick : MonoBehaviour {


	public GameObject[] suit;


	public void RandomPilih () {
		int i = Random.Range (0,2);
		suit [i].GetComponent<ButtonInput> ().OnClick ();
	}

}
