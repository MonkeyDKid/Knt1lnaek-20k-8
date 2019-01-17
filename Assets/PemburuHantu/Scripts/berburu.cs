using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class berburu : MonoBehaviour {
	public float angka;
	public bool goyang, joget, animation1, animation2;
	public float timer=3;
	public float TimeShiftIncrease=1;
	public float TimeShiftDecrease=1;
	public FilmSelector FS;
	public Image Penanda;
	public Animation a1,a2,a3,a4,a5,a6,a7,a8;
	// Use this for initialization
	void Start () {
		animation1 = false;
		animation2 = false;
		PlayerPrefs.SetInt ("Catched",0);
	}
	
	// Update is called once per frame
	void Update () {
		Penanda.fillAmount = angka / 6;
		if(PlayerPrefs.GetInt ("Catched")!=1)
		{

	
		if (goyang) {
			
			angka +=Time.deltaTime*TimeShiftIncrease;
			if (!animation1) {
				a1.PlayQueued ("1a", QueueMode.PlayNow);
				a2.PlayQueued ("2a", QueueMode.PlayNow);
				a3.PlayQueued ("3a", QueueMode.PlayNow);
				a4.PlayQueued ("4a", QueueMode.PlayNow);
				a5.PlayQueued ("5a", QueueMode.PlayNow);
				a6.PlayQueued ("6a", QueueMode.PlayNow);
				a7.PlayQueued ("7a", QueueMode.PlayNow);
				a8.PlayQueued ("8a", QueueMode.PlayNow);
				animation1 = true;
			}
		} 
		if(joget) {
			angka -=Time.deltaTime*TimeShiftDecrease;
			//timer -= Time.deltaTime;
			if (!animation2) {
				a1.PlayQueued ("1", QueueMode.PlayNow);
				a2.PlayQueued ("2", QueueMode.PlayNow);
				a3.PlayQueued ("3", QueueMode.PlayNow);
				a4.PlayQueued ("4", QueueMode.PlayNow);
				a5.PlayQueued ("5", QueueMode.PlayNow);
				a6.PlayQueued ("6", QueueMode.PlayNow);
				a7.PlayQueued ("7", QueueMode.PlayNow);
				a8.PlayQueued ("8", QueueMode.PlayNow);
				animation2 = true;
			}
		}
		if (timer <= 0) {
			angka --;
			timer = 3;
		}
		if (angka <= 0) {
			angka = 0;
		}
		if (angka >= 6) {
			angka = 6;
			PlayerPrefs.SetString ("berburu", "ya");
			PlayerPrefs.SetInt ("Catched",1);
			FS.Catch=false;
			goyang=false;
			joget=true;
			SceneManager.LoadScene("Summon", LoadSceneMode.Additive);
			angka=0;
			//SceneManagerHelper.LoadScene ("PilihCharacter 1");
			//random musuh masuk k pilihcharacter;
		  }
		}
			//

	}
	void OnTriggerEnter(Collider target){
		animation2 = false;
		Debug.Log (target.name);
		goyang = true;
		joget = false;

	}
	void OnTriggerExit(Collider target){
		animation1 = false;
		Debug.Log (target.name);
		goyang = false;
		joget = true;
	}

}


