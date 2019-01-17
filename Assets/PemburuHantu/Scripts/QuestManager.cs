using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;

public class QuestManager : MonoBehaviour {
	public GameObject DQItem,AchieveItem,RedeemSucceed,TransactionFailed,TransactionFailed2,TransactionFailed3,Home;
	public Transform DQViewer,AchieveViewer;
    public Text GoldText, CrystalText, EnergyText;
	ConfigurationBuilder builder;
	// Use this for initialization
	void Start () {
        CrystalText.text = Home.GetComponent<UserLogin>().SoulStone.text;
        GoldText.text = Home.GetComponent<UserLogin>().Coin.text;
       StartCoroutine (DQItemList());
        //		var module = StandardPurchasingModule.Instance ();
        //		builder = ConfigurationBuilder.Instance (module);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator DQItemList()
    {
        string url = Link.url + "DQuest";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerPrefs.GetString(Link.ID));
        //form.AddField ("SHOP_JENIS", "SPECIAL");
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            Debug.Log(www.text);
            var jsonString = JSON.Parse(www.text);
            //PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["ID_SHOP_SPECIAL"]);
            if (int.Parse(jsonString["code"]) == 1)
            {

                GameObject[] entry;
                entry = new GameObject[int.Parse(jsonString["count"])];

                for (int x = DQViewer.childCount - 1; x >= 0; x--)
                {
                    Destroy(DQViewer.GetChild(x).gameObject);
                }
                for (int x = 0; x < int.Parse(jsonString["count"]); x++)
                {
                    entry[x] = Instantiate(DQItem);
                    entry[x].GetComponent<questItem>().QM = this.GetComponent<QuestManager>();
                    entry[x].GetComponent<questItem>().QuestID = jsonString["data"][x]["ID"];
                    entry[x].GetComponent<questItem>().Type = jsonString["data"][x]["Type"];
                    entry[x].GetComponent<questItem>().Mission.text = jsonString["data"][x]["Title"] + " " + jsonString["data"][x]["Quest_Times"] + " Times";
                    int lol = 0;
                    var number = int.TryParse(jsonString["data"][x]["Quest_Done"], out lol);
                   
                    if (number)
                    {
                      
                        if (lol == 1)
                        {
                            entry[x].GetComponent<questItem>().Stats.text = "Finished";
                            string String = jsonString["data"][x]["Type"];
                            if (String == "Summon")
                            {
                                PlayerPrefs.SetString("SummonMissionStats", "FALSE");
                              
                            }
                            if (String == "SingleMode")
                            {
                                PlayerPrefs.SetString("SoloMissionStats", "FALSE");
                              
                            }
                            if (String == "Catch")
                            {
                                PlayerPrefs.SetString("CatchMissionStats", "FALSE");
                              
                            }
                        }
                        else
                        {
                            string String = jsonString["data"][x]["Type"];
                            entry[x].GetComponent<questItem>().Stats.text = "Ongoing";
                            if (String == "Summon")
                            {
                                PlayerPrefs.SetString("SummonMissionStats", "TRUE");
                                PlayerPrefs.SetString("SummonMissionQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "SingleMode")
                            {
                                PlayerPrefs.SetString("SoloMissionStats", "TRUE");
                                PlayerPrefs.SetString("SoloMissionQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "Catch")
                            {
                                PlayerPrefs.SetString("CatchMissionStats", "TRUE");
                                PlayerPrefs.SetString("CatchMissionQD", jsonString["data"][x]["ID"]);
                            }
                        }
                   //     Debug.Log(PlayerPrefs.GetString("SoloMissionQD"));
                    }
                    else
                    {

                        entry[x].GetComponent<questItem>().Stats.text = "Ongoing";
                    }
                    int lal = 0;
                    var namba = int.TryParse(jsonString["data"][x]["Quest_Redeem"], out lal);
                    if (namba)
                    {
                        if (lal == 1)
                        {
                            entry[x].GetComponent<questItem>().Redeemstats = "1";
                        }
                        else
                        {
                            entry[x].GetComponent<questItem>().Redeemstats = "0";
                        }


                    }
                    else
                    {

                        entry[x].GetComponent<questItem>().Redeemstats = "0";
                    }

                    entry[x].GetComponent<questItem>().RT = jsonString["data"][x]["Quest_RT"];
                    entry[x].GetComponent<questItem>().RQ = jsonString["data"][x]["Quest_RQ"];

                    PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["data"][x]["ItemType"]);
                    entry[x].transform.SetParent(DQViewer, false);

                }
            }
            else {
                TransactionFailed.SetActive(true);
                Debug.Log("NoMission");
            }
        }
        else {
            Debug.Log(www.text);
            Debug.Log("NoMission");

        }
    }
	private IEnumerator AchievementList ()
	{
        string url = Link.url + "Achievement";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerPrefs.GetString(Link.ID));
        //form.AddField ("SHOP_JENIS", "SPECIAL");
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            Debug.Log(www.text);
            var jsonString = JSON.Parse(www.text);
            //PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["ID_SHOP_SPECIAL"]);
            if (int.Parse(jsonString["code"]) == 1)
            {

                GameObject[] entry;
                entry = new GameObject[int.Parse(jsonString["count"])];

                for (int x = AchieveViewer.childCount - 1; x >= 0; x--)
                {
                    Destroy(AchieveViewer.GetChild(x).gameObject);
                }
                for (int x = 0; x < int.Parse(jsonString["count"]); x++)
                {
                    entry[x] = Instantiate(AchieveItem);
                    entry[x].GetComponent<achieveItem>().QM = this.GetComponent<QuestManager>();
                    entry[x].GetComponent<achieveItem>().QuestID = jsonString["data"][x]["ID"];
                    entry[x].GetComponent<achieveItem>().Type = jsonString["data"][x]["Type"];
                    entry[x].GetComponent<achieveItem>().Mission.text = jsonString["data"][x]["Title"];
                    int lol = 0;
                    var number = int.TryParse(jsonString["data"][x]["Achievement_Done"], out lol);
                    if (number)
                    {
                        if (lol == 1)
                        {
                            entry[x].GetComponent<achieveItem>().Stats.text = "Finished";
                            string String = jsonString["data"][x]["Type"];
                           
                            if (String == "Tutorial")
                            {
                                PlayerPrefs.SetString("TutorialMission", "FALSE");
                               
                            }
                            if (String == "Catch")
                            {
                                PlayerPrefs.SetString(String, "FALSE");
                             
                            }
                            if (String == "B_Arena")
                            {
                                PlayerPrefs.SetString(String, "FALSE");
                             
                            }
                            if (String == "AR_Arena")
                            {
                                PlayerPrefs.SetString(String, "FALSE");
                             
                            }
                            if (String == "B_Crystal")
                            {
                                PlayerPrefs.SetString(String, "FALSE");
                              
                            }
                            if (String == "EXP_Share")
                            {
                                PlayerPrefs.SetString(String, "FALSE");
                               
                            }
                        }
                        else
                        {
                            string String = jsonString["data"][x]["Type"];
                            entry[x].GetComponent<achieveItem>().Stats.text = "Ongoing";
                            if (String == "Tutorial")
                            {
                                PlayerPrefs.SetString("TutorialMission", "TRUE");
                                PlayerPrefs.SetString("TMQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "Catch")
                            {
                                PlayerPrefs.SetString(String, "TRUE");
                                PlayerPrefs.SetString("CQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "B_Arena")
                            {
                                PlayerPrefs.SetString(String, "TRUE");
                                PlayerPrefs.SetString("BAQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "AR_Arena")
                            {
                                PlayerPrefs.SetString(String, "TRUE");
                                PlayerPrefs.SetString("ARAQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "B_Crystal")
                            {
                                PlayerPrefs.SetString(String, "TRUE");
                                PlayerPrefs.SetString("BCQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "EXP_Share")
                            {
                                PlayerPrefs.SetString(String, "TRUE");
                                PlayerPrefs.SetString("EXPSQD", jsonString["data"][x]["ID"]);
                            }
                        }
                        //     Debug.Log(PlayerPrefs.GetString("SoloMissionQD"));
                    }
                    else
                    {

                        entry[x].GetComponent<achieveItem>().Stats.text = "Ongoing";
                    }
                    int lal = 0;
                    var namba = int.TryParse(jsonString["data"][x]["Achievement_Redeem"], out lal);
                    if (namba)
                    {
                        if (lal == 1)
                        {
                            entry[x].GetComponent<achieveItem>().Redeemstats = "1";
                        }
                        else
                        {
                            entry[x].GetComponent<achieveItem>().Redeemstats = "0";
                        }


                    }
                    else
                    {

                        entry[x].GetComponent<achieveItem>().Redeemstats = "0";
                    }

                    entry[x].GetComponent<achieveItem>().RT = jsonString["data"][x]["Achievement_RT"];
                    entry[x].GetComponent<achieveItem>().RQ = jsonString["data"][x]["Achievement_RQ"];

                    //PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["data"][x]["ItemType"]);
                    entry[x].transform.SetParent(AchieveViewer, false);

                }
            }
            else {
                Debug.Log("GAGAL");
            }
        }
        else {
            Debug.Log(www.text);
            Debug.Log("NoMission");

        }

    }
	
	public void AchievementListCek(){
		StartCoroutine (AchievementList ());
	}
	public void DQItemListCek(){
		StartCoroutine (DQItemList ());
	}

   public IEnumerator RedeemReward(string QuestID, string Obj, string reward)
    {
        string url = Link.url + "RedeemReward";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerPrefs.GetString(Link.ID));
        form.AddField("QuestID", QuestID);
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            int kode = int.Parse(jsonString["code"]);
            if (kode == 1)
            {
                PlayerPrefs.SetString(Link.GOLD, jsonString["data"]["coin"]);
                Home.GetComponent<UserLogin>().Coin.text = jsonString["data"]["coin"];
                Home.GetComponent<UserLogin>().CoinShop.text = jsonString["data"]["coin"];
                GoldText.text= jsonString["data"]["coin"];
                if (Obj == "Summon")
                {
                    PlayerPrefs.SetString("SummonMissionStats", "FALSE");
                }
                if (Obj == "Catch")
                {
                    PlayerPrefs.SetString("CatchMissionStats", "FALSE");
                }
                else {
                    PlayerPrefs.SetString("SoloMissionStats", "FALSE");
                }
                RedeemSucceed.transform.Find("Image").transform.Find("Text").GetComponent<Text>().text = " Reward Redeemed \nyou got " + reward;
                RedeemSucceed.SetActive(true);
                StartCoroutine(DQItemList());
            }
            else
            {
                Debug.Log("BackSound Jangkrink");
            }

        }
        Debug.Log(www.text);
    }

    public IEnumerator RedeemReward2(string QuestID, string Obj, string reward)
    {
        string url = Link.url + "RedeemReward2";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerPrefs.GetString(Link.ID));
        form.AddField("AchievementID", QuestID);
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            int kode = int.Parse(jsonString["code"]);
            if (kode == 1)
            {
                PlayerPrefs.SetString("Crystal", jsonString["data"]["crystal"]);
                Home.GetComponent<UserLogin>().SoulStone.text = jsonString["data"]["crystal"];
                CrystalText.text= jsonString["data"]["crystal"];
                PlayerPrefs.SetString(Obj+QuestID, "FALSE");
                RedeemSucceed.transform.Find("Image").transform.Find("Text").GetComponent<Text>().text =" Reward Redeemed \nyou got " + reward;
                RedeemSucceed.SetActive(true);
                StartCoroutine(AchievementList());
            }
            else
            {
                Debug.Log("BackSound Jangkrink");
            }

        }
        Debug.Log(www.text);
    }
}
