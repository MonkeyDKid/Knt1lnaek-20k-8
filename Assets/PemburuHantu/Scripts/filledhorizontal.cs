using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class filledhorizontal : MonoBehaviour {
	public float maxhealth, currenthealth;
    public float damage;
    public float defend;
    public Sprite HealthKuning, HealthHijau, HealthMerah;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var kuning = GetComponent<Image> ();
		float curhealthfl = currenthealth;
		//		percentage.text=(curhealthfl/maxhealth)*100+" %";
		kuning.fillAmount=(curhealthfl/maxhealth);
        if (kuning.fillAmount <= 0.4f)
        {
            kuning.sprite = HealthKuning;
            if (kuning.fillAmount <= 0.15f)
            {
                kuning.sprite = HealthMerah;

            }
        }
        else {
            kuning.sprite = HealthHijau;
        }
        //		if (kuning.fillAmount <= 0.4f) {
        //			kuning.sprite = HealthKuning;
        //			if  (kuning.fillAmount <= 0.15f) {
        //				kuning.sprite = HealthMerah;
        //
        //			} 
        //		}
        if (currenthealth > maxhealth) {
			currenthealth = maxhealth;
		}
		if (currenthealth < 0) {
			currenthealth = 0;
		}
	
	}
}
