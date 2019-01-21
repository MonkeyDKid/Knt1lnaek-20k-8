using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class CraftingManager : MonoBehaviour {
float myFloat;
public GameObject[] SeqObject;
	// Use this for initialization
	void Start () {

		//StartSequence();

	}
	
public void StartSequence()
{
	
	for (int i=0; i<3;i++)
	{
		SeqObject[i].transform.DOLocalMoveY(-215f,1).OnComplete(ABC);
	}
	SeqObject[3].transform.DOLocalMoveY(4.5f,1);
	
}
public void ABC()
{
		
		SeqObject[4].transform.DOScale(new Vector3(1.5f,1.5f,1),1).OnComplete(()=>{
			SeqObject[10].GetComponent<Image>().DOFillAmount(1,7).SetEase(Ease.InCubic);
			SeqObject[8].transform.DOScale(new Vector3(.4f,.4f,1),1);
			SeqObject[5].SetActive(true);
			SeqObject[6].GetComponent<SpriteRenderer>().DOFade(0,2);
		});
}
public void ShowItem()
{
	SeqObject[9].transform.DOScale(new Vector3(4f,4f,4f),0);
	SeqObject[11].SetActive(true);
	SeqObject[8].GetComponent<SpriteRenderer>().DOFade(0,0);
	SeqObject[7].GetComponent<SpriteRenderer>().DOFade(1,0f);
}

}
