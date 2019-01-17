using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class filled : MonoBehaviour {
	Image kuning;
	public Sprite HealthKuning,HealthHijau,HealthMerah;
//	public InputField input;
//	public Text percentage;
	public float maxhealth, currenthealth;
	public float damage;
	public float defend;
	// Use this for initialization
	void Start () {
		kuning = GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		//currenthealth = maxhealth;
		float curhealthfl = currenthealth;
//		percentage.text=(curhealthfl/maxhealth)*100+" %";
		kuning.fillAmount=(curhealthfl/maxhealth);
		if (kuning.fillAmount <= 0.4f) {
			kuning.sprite = HealthKuning;
			if  (kuning.fillAmount <= 0.15f) {
				kuning.sprite = HealthMerah;

			} 
		}
		 else {
			kuning.sprite = HealthHijau;
		}
		if (currenthealth > maxhealth) {
			currenthealth = maxhealth;
		}
		if (currenthealth < 0) {
			currenthealth = 0;
		}
	}
	public void cheatHP(){
		#if UNITY_EDITOR
		currenthealth = 10;
		#endif
	}
}
