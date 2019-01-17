using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TT : MonoBehaviour {
	public bool onclick;
	public bool OnDown;
	Animator trigger;
	Button switchy ;
	// Use this for initialization
	void Start () {
		trigger = GetComponent<Animator>();
		switchy = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	 if (trigger.GetCurrentAnimatorStateInfo(0).IsName("id1"))
 	{
    // Avoid any reload.
	print("shit happen");
	onclick=false;
 	}
 
  else if (trigger.GetCurrentAnimatorStateInfo(0).IsName("id"))
 {
    // Avoid any reload.
	onclick=false;
 }
 else
 {
	onclick=true; 	
 }
 if(onclick==false)
 {
	 switchy.interactable=true;
 }
 else
 {
	  switchy.interactable=false;
 }
	}
	public void Switch()
	{	
		onclick=true;
		OnDown = !OnDown;
			if(OnDown)
			{
				trigger.ResetTrigger("Down");
				trigger.ResetTrigger("Up");
				trigger.SetTrigger("Down");
			}
			else
			{
				trigger.ResetTrigger("Down");
				trigger.ResetTrigger("Up");
				trigger.SetTrigger("Up");
			}
		
		
	}
}
