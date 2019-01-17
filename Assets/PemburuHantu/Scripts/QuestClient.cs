using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleJSON;
public class QuestClient : MonoBehaviour {
    public Game Game;
    bool CicilMission1 = false;
    bool CicilMission2 = false;
    bool CicilMission3 = false;
    bool MSSummon, MSSolo, MSCatch;
    int currentSummonQuest, currentSoloQuest, currentCatchQuest;
  
	// Use this for initialization
	void Start () {
        //MSSummon = int.TryParse(PlayerPrefs.GetString(Link.SUMMONQUESTSTATS), out currentSummonQuest);
        //MSSolo = int.TryParse(PlayerPrefs.GetString(Link.SOLOQUESTSTATS), out currentSoloQuest);
        //MSCatch = int.TryParse(PlayerPrefs.GetString(Link.CATCHQUESTSTATS), out currentCatchQuest);
        //if (!MSSummon) {
        //    currentSummonQuest = 999;
        //}
        //if (!MSSolo)
        //{
        //    currentSoloQuest = 999;
        //}
        //if (!MSCatch)
        //{
        //    currentCatchQuest = 999;
        //}
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Game 1")
        {
            if (PlayerPrefs.GetString("SoloMissionStats") == "TRUE")
        {
            //if (currentSoloQuest != 999)
            //{
                
                    if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
                    {
                        if (PlayerPrefs.GetInt("win") == 1)
                        {
                            if (CicilMission1 == false)
                            {
                                //PlayerPrefs.SetString(Link.SOLOQUESTSTATS, (currentSoloQuest + 1).ToString());
                                StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("SoloMissionQD")));
                                CicilMission1 = true;
                            }

                        }

                    }
                //}
            }
        }
        if (SceneManager.GetActiveScene().name == "Summon")
        {
            if (PlayerPrefs.GetString("SummonMissionStats") == "TRUE")
        {

            //if (currentSummonQuest != 999)
            //{
            var summonstring = PlayerPrefs.GetString("SummonStats");
              

                if (summonstring == "Summoned")
                {
                    if (CicilMission2 == false)
                    {
                        // PlayerPrefs.SetString(Link.SUMMONQUESTSTATS, (currentSummonQuest + 1).ToString());
                        StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("SummonMissionQD")));
                        CicilMission2 = true;
                    }

                }
                else {
                    CicilMission2 = false;
                }
                    //}
                
            }
        }
        if (SceneManager.GetActiveScene().name == "Game 1")
        {
            if (PlayerPrefs.GetString("CatchMissionStats") == "TRUE")
        {
            //if (currentCatchQuest != 999)
            //{
              
                    if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
                    {
                        if (PlayerPrefs.GetString("berburu") == "ya")
                        {
                            if (PlayerPrefs.GetInt("win") == 1)
                            {
                                if (CicilMission3 == false)
                                {
                                    //PlayerPrefs.SetString(Link.CATCHQUESTSTATS, (currentCatchQuest + 1).ToString());
                                    StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("CatchMissionQD")));
                                    CicilMission3 = true;
                                }
                            }

                        }

                    }
                //}
            }
        }

    }

    IEnumerator SendLatestObjective(string Objective)
    {
        string url = Link.url + "Commission";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerPrefs.GetString(Link.ID));
        form.AddField("QuestID", Objective);
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            int kode = int.Parse(jsonString["code"]);
            if (kode == 1)
            {
               
                //PlayerPrefs.SetString(Link.Stage, jsonString["data"]["Stage"]);
                //PlayerPrefs.SetString(Link.Replay, "TRUE");
                Debug.Log(www.text);
            }
            else
            {
                Debug.Log("BackSound Jangkrink");
            }

        }
        Debug.Log(www.text);
    }
}
