using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class expbar : MonoBehaviour {
	public float currentEXP,targetEXP;
	public GameObject Before;
	public Image displaybar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Before.activeInHierarchy == false) {
			currentEXP = 0;
			targetEXP = 0;
		}
		displaybar.fillAmount = currentEXP / targetEXP;
	}
}
