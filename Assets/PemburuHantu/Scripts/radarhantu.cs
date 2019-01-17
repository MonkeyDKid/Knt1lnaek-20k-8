using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radarhantu : MonoBehaviour {

	public GameObject radar;
	public Slider slidetest;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		radar.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, -slidetest.value * 180));
		
	}
}
