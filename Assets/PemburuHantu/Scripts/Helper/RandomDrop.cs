using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour {

public int[] ItemRate;
public string[] ItemName;
public string[] ItemType;
public string[] ItemQuantity;
public int weightTotal;

 
   
 
    void Awake () {
        ItemRate = new int[3]; //number of things
        ItemName = new string[3];
        //weighting of each thing, high number means more occurrance
        for(int i = 0; i<3;i++)
        {
            ItemName[i] = PlayerPrefs.GetString("RewardItemName"+i.ToString());
            ItemType[i] = PlayerPrefs.GetString("RewardItemName"+i.ToString());
            ItemQuantity[i] = PlayerPrefs.GetString("RewardItemName"+i.ToString());
            ItemRate[i] = int.Parse(PlayerPrefs.GetString("RewardItemRate"+i.ToString()));
        }
        
        
        weightTotal = 0;
        foreach ( int w in ItemRate ) {
            weightTotal += w;
        }
    }
 
	public void getresult()
	{
		var result = RandomWeighted ();
		print(result);
	}
 
    int RandomWeighted () {
        int result = 0, total = 0;
        int randVal = Random.Range( 0, weightTotal );
        for ( result = 0; result < ItemRate.Length; result++ ) {
            total += ItemRate[result];
            if ( total > randVal ) break;
        }
		
        return result;
    }
}
