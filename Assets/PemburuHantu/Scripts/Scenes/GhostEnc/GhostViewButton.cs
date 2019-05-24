using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GhostViewButton : MonoBehaviour {
	public GhostView GV;
	[HideInInspector]
	public bool opened = false;
	public int ghostnumber;
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(ShowGhost);
	}

	public void ShowGhost()
	{
		if(opened)
		{
			GV.showGhost(ghostnumber);
		}
	}
	
	
}
