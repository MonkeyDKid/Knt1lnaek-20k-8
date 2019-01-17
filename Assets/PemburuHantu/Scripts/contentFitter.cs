using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contentFitter : MonoBehaviour {
	public float wdelta, posx;
	public bool once;
	// Use this for initialization
	void Start () {
		StartCoroutine (fitsize ());
	}
	
	// Update is called once per frame
	void Update () {
		
		if (once == false) {
			StartCoroutine (fitsize ());
			}
		//GetComponent<RectTransform> ().transform.position = new Vector2 (posx,1f);
		//GetComponent<RectTransform> ().transform.position.x = posx;

	}
	IEnumerator fitsize(){
		wdelta = GetComponent<RectTransform> ().sizeDelta.x;
		posx = wdelta / 2;
		if (wdelta > 0) {
			GetComponent<RectTransform> ().localPosition = new Vector2 (posx, 21);

			yield return new WaitForSeconds (.1f);
			once = true;
		}
	}
	public void Activate(){
		once=false;
	}


}
