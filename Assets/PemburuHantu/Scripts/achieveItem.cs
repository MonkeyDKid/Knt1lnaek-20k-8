using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class achieveItem : MonoBehaviour
{
    public Text Mission, Stats, RQText, RedeemText;
    public string RT, RQ, QuestID,Redeemstats,Type,RQRT;
    public Button redeem;
    public GameObject disable;
    public QuestManager QM;
    private void Start()
    {
        RQRT = RQ + " " + RT;
        RQText.text = RQ;
        if (Stats.text == "Finished")
        {
            if (int.Parse(Redeemstats) == 0)
            {
                RedeemText.color = new Color(233f/255f, 208f / 255f, 43f / 255f);
                redeem.interactable = true;
               
            }
            else {
                RedeemText.color = new Color(81f / 255f, 16f / 255f, 0);
                redeem.interactable = false;
                disable.SetActive(true);
            }
           
        }
        else
        {
            RedeemText.color = new Color(81f / 255f, 16f / 255f, 0);
            redeem.interactable = false;
        }



    }
    public void RedeemReward() {
        StartCoroutine(QM.RedeemReward2(this.QuestID,this.Type, this.RQRT));
        Debug.Log(this.QuestID + this.Type);
    }
   
}
