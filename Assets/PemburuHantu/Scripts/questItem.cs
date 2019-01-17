using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class questItem : MonoBehaviour
{
    public Text Mission, Stats, RQText;
    public string RT, RQ, QuestID,Redeemstats,Type,RQRT;
    public Button redeem;
    public GameObject disable;
    public QuestManager QM;
    private void Start()
    {
        RQText.text = RQ;
        RQRT = RQ + " " + RT;
        if (Stats.text == "Finished")
        {
            if (int.Parse(Redeemstats) == 0)
            {
                redeem.interactable = true;
                redeem.gameObject.transform.Find("Text").GetComponent<Text>().color = new Color(233f / 255f, 208f / 255f, 43f / 255f);
            }
            else {
                redeem.gameObject.transform.Find("Text").GetComponent<Text>().color= new Color(81f / 255f, 16f / 255f, 0);
                redeem.interactable = false;
                disable.gameObject.SetActive(true);
            }
           
        }
        else
        {
            redeem.gameObject.transform.Find("Text").GetComponent<Text>().color = new Color(81f / 255f, 16f / 255f, 0);
            redeem.interactable = false;
        }



    }
    public void RedeemReward() {
        StartCoroutine(QM.RedeemReward(this.QuestID,this.Type,this.RQRT));
        Debug.Log(this.QuestID + this.Type);
    }
   
}
