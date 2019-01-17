using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour {

	//[HideInInspector]
	public GameObject[] SelectLevel;
	public int number;
	public Button LeftButton, RightButton;

	public void NextSetActiveGameObject(int Operation)
	{	
			
		if(Operation==0)
		{
			number++;
		}
		else
		{
			number--;
		}
	
		for(int i=0; i<SelectLevel.Length; i++)
		{
			if(number==i)
			{
				print("Here");
				SelectLevel[i].SetActive(true);
			}
			else
			{
				print("Here2");
				SelectLevel[i].SetActive(false);
			}
			var counterRight = number+1;			
			if(counterRight==SelectLevel.Length)
			{
				RightButton.interactable = false;
			}
			else
			{
				RightButton.interactable = true;
			}
			if(number==0)
			{
				LeftButton.interactable = false;
			}
			else
			{
				LeftButton.interactable = true;
			}
		}
	}
	public void BackSetActiveGameObject()
	{

	}
}
