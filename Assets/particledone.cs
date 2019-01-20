using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class particledone : MonoBehaviour {
public bool Done;
public CraftingManager CManager;
bool Once = false;
	// Use this for initialization
	
	void Update () {
		//print(GetComponent<ParticleSystem>().time);
		if(GetComponent<ParticleSystem>().time >= 0.1f)
		{
			if(Once == false)
			{
			Once = true;	
			CManager.ShowItem();		
			print("Done");
			}
		}
	}
}
