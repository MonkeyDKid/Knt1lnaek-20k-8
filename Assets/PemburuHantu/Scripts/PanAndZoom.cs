using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAndZoom : MonoBehaviour {
	Vector3 TouchStart;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			TouchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		if(Input.GetMouseButton(0))
		{
			Vector3 direction = TouchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Camera.main.transform.position += direction;
		}		
	}
}
