using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class FlowchartController : MonoBehaviour {
private static Flowchart FC;
	public GameObject GO;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteKey("PP6");
			FC = GetComponent<Flowchart> ();
	}
	
public static void StartBlock(string blockName)
{
	FC.StopAllBlocks();
	FC.ExecuteBlock(blockName);
}
	public static void StopBlock()
	{
		FC.StopAllBlocks ();
	}

	public void enableGO(string gameobjectName)
	{
		GO = GameObject.FindGameObjectWithTag (gameobjectName);

		if (GO != null) {
			switch (GO.name)
			{
			case "Home":
				GO.GetComponent<Home> ().FirstTimerGO.SetActive (true);				
				break;
			case "Summon":
				GO.GetComponent<Summon> ().firstTimerSummonScript.gameObject.SetActive (true);
				break;
			case "Map":
				GO.GetComponent<Map> ().firstTimerMAP.SetActive (true);
				break;
			case "Game":
				//GO.GetComponent<Game> ().firstTimerGame.SetActive (true);
				break;
			case "PilihCharacter":
				GO.GetComponent<PilihCharacter> ().firstTimerPilih.SetActive (true);
				break;
			}
		}
	}

	public void SetFirstTimer(int position)
	{
		GO.GetComponent<Game> ().firstTimerGame.SetActive (true);
		GO.GetComponent<Game> ().firstTimerGame.GetComponent<firstimerGame>().position = position;
	}

}
