using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tambahan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Replay(){
		SceneManager.LoadScene (1);

	}
	public void Home(){
		SceneManager.LoadScene (0);

	}
	public void Quit(){
		Application.Quit ();

	}
}
