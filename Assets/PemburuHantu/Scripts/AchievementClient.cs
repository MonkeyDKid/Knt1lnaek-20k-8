using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleJSON;
public class AchievementClient : MonoBehaviour {
    public Game Game;
    bool CicilMission1 = false;
    bool CicilMission2 = false;
    bool CicilMission3 = false;
    bool CicilMission4 = false;
    bool CicilMission5 = false;
    bool CicilMission6 = false;
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

    //    PlayerPrefs.SetString("TutorialMission", "TRUE");
    //    PlayerPrefs.SetString("TMQD", jsonString["data"][x]["ID"]);
    //}
    //                        if (String == "Catch")
    //                        {
    //                            PlayerPrefs.SetString("SoloMissionStats", "TRUE");
    //                            PlayerPrefs.SetString("SoloMissionQD", jsonString["data"][x]["ID"]);
    //                        }
    //                        if (String == "B_Arena")
    //                        {
    //                            PlayerPrefs.SetString(String, "TRUE");
    //                            PlayerPrefs.SetString("BAQD", jsonString["data"][x]["ID"]);
    //                        }
    //                        if (String == "AR_Arena")
    //                        {
    //                            PlayerPrefs.SetString(String, "TRUE");
    //                            PlayerPrefs.SetString("ARAQD", jsonString["data"][x]["ID"]);
    //                        }
    //                        if (String == "B_Crystal")
                            //{
                            //    PlayerPrefs.SetString(String, "TRUE");
                            //    PlayerPrefs.SetString("BCQD", jsonString["data"][x]["ID"]);
                            //}
                            //if (String == "EXP_Share")
                            //{
                            //    PlayerPrefs.SetString(String, "TRUE");
                            //    PlayerPrefs.SetString("EXPSQD", jsonString["data"][x]["ID"]);




        if (PlayerPrefs.GetString("TutorialMission") == "TRUE")
        {
            //if (currentSoloQuest != 999)
            //{
                if (SceneManager.GetActiveScene().name == "Home")
                {
                      if (CicilMission1== false)
                            {
                                //PlayerPrefs.SetString(Link.SOLOQUESTSTATS, (currentSoloQuest + 1).ToString());
                                StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("TMQD")));
                                CicilMission1= true;
                            }

                       

                  
            }
        }
        if (PlayerPrefs.GetString("B_Arena") == "TRUE")
        {

            //if (currentSummonQuest != 999)
            //{
                if (SceneManager.GetActiveScene().name == "Game 1")
                {
               if (PlayerPrefs.GetString(Link.JENIS) != "SINGLE")
                    {
                      if (PlayerPrefs.GetInt("win") == 1)
                            {
                    if (CicilMission2== false)
                    {
                        // PlayerPrefs.SetString(Link.SUMMONQUESTSTATS, (currentSummonQuest + 1).ToString());
                        StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("BAQD")));
                        CicilMission2= true;
                    }
    
    }
    }
    }
                
               
                    //}
                
            
        }

        if (PlayerPrefs.GetString("AR_Arena") == "TRUE")
        {

          
            if (SceneManager.GetActiveScene().name == "Game 1")
            {
                if (PlayerPrefs.GetString(Link.JENIS) != "SINGLE")
                {
                    if (PlayerPrefs.GetString(Link.SEARCH_BATTLE) == "JOUSTING")
                    {
                        if (PlayerPrefs.GetInt("win") == 1)
                        {
                            if (CicilMission3== false)
                            {
                                StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("ARAQD")));
                                CicilMission3= true;
                            }

                        }
                    }
                }
            }


            //}


        }

        if (PlayerPrefs.GetString("B_Crystal") == "TRUE")
        {

            //if (currentSummonQuest != 999)
            //{
            if (SceneManager.GetActiveScene().name == "Home")
            {
                if (PlayerPrefs.GetString("BOUGHTCRYSTAL") == "TRUE")
                {
                   
                        if (CicilMission4== false)
                        {
                            // PlayerPrefs.SetString(Link.SUMMONQUESTSTATS, (currentSummonQuest + 1).ToString());
                            StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("BCQD")));
                            CicilMission4= true;
                        }

                    
                }
            }
        }


        if (PlayerPrefs.GetString("EXP_Share") == "TRUE")
        {

            //if (currentSummonQuest != 999)
            //{
            if (SceneManager.GetActiveScene().name == "Practice")
            {
                if (PlayerPrefs.GetString("Trained") == "TRUE")
                {

                    if (CicilMission5== false)
                    {
                        // PlayerPrefs.SetString(Link.SUMMONQUESTSTATS, (currentSummonQuest + 1).ToString());
                        StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("EXPSQD")));
                        CicilMission5= true;
                    }


                }
            }
        }



        if (PlayerPrefs.GetString("Catch") == "TRUE")
        {
            //if (currentCatchQuest != 999)
            //{
                if (SceneManager.GetActiveScene().name == "Game 1")
                {
                    if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
                    {
                        if (PlayerPrefs.GetString("berburu") == "ya")
                        {
                            if (PlayerPrefs.GetInt("win") == 1)
                            {
                                if (CicilMission6== false)
                                {
                                    StartCoroutine(SendLatestObjective(PlayerPrefs.GetString("CQD")));
                                    CicilMission6= true;
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
        string url = Link.url + "Commission2";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerPrefs.GetString(Link.ID));
        form.AddField("AchievementID", Objective);
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
            //    Debug.Log(www.text);
            }
            else
            {
                Debug.Log("BackSound Jangkrink");
            }

        }
     //   Debug.Log(www.text);
    }
}
