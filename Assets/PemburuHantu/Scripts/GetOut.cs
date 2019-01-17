using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;


public class GetOut : MonoBehaviour
{
    
    public GameObject ValidationError, vanny;
    private IEnumerator LoginOut()
    {
        string url = Link.url + "logout";
        WWWForm form = new WWWForm();
        form.AddField(Link.DEVICE_ID, PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField(Link.EMAIL, PlayerPrefs.GetString(Link.EMAIL));
        form.AddField(Link.PASSWORD, PlayerPrefs.GetString(Link.PASSWORD));

        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            LogoutKey();
            //PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
            //PlayerPrefs.DeleteKey("SummonTutor");
           SceneManagerHelper.LoadScene(Link.Register);
            //PlayerPrefs.DeleteKey("tutorhitung");
            //PlayerPrefs.DeleteKey(Link.LOGIN_BY);
        }
    }
    private void LogoutKey()
    {
        PlayerPrefs.DeleteKey(Link.ID);
        PlayerPrefs.DeleteKey(Link.LOGIN_BY);
        PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
        PlayerPrefs.DeleteKey(Link.STATUS_BATTLE);
        PlayerPrefs.DeleteKey(Link.EMAIL);
        PlayerPrefs.DeleteKey(Link.USER_NAME);
        PlayerPrefs.DeleteKey(Link.FULL_NAME);
        PlayerPrefs.DeleteKey(Link.AP);
        PlayerPrefs.DeleteKey(Link.AR);
        PlayerPrefs.DeleteKey(Link.PASSWORD);
        PlayerPrefs.DeleteKey(Link.DEVICE_ID);
        PlayerPrefs.DeleteKey(Link.PASSWORD);
        PlayerPrefs.DeleteKey(Link.Stage);
        PlayerPrefs.DeleteKey(Link.IBURU);
        PlayerPrefs.DeleteKey(Link.IGOLD);
        PlayerPrefs.DeleteKey(Link.IENERGY);
        PlayerPrefs.DeleteKey(Link.GOLD);
        PlayerPrefs.DeleteKey(Link.ENERGY);
        PlayerPrefs.DeleteKey(Link.COMMON);
        PlayerPrefs.DeleteKey(Link.RARE);
        PlayerPrefs.DeleteKey(Link.LEGENDARY);
        PlayerPrefs.DeleteKey(Link.COMMONGem);
        PlayerPrefs.DeleteKey(Link.RAREGem);
        PlayerPrefs.DeleteKey(Link.LEGENDARYGem);
        PlayerPrefs.DeleteKey(Link.FOR_CONVERTING);
        PlayerPrefs.DeleteKey(Link.LAT);
        PlayerPrefs.DeleteKey(Link.LOT);
        PlayerPrefs.DeleteKey("GMode");
        PlayerPrefs.DeleteKey("ItemID");
        PlayerPrefs.DeleteKey("PLAY_TUTORIAL");
        PlayerPrefs.DeleteKey("Tutorgame");
        PlayerPrefs.DeleteKey("HantuNaikGrade");
        for(int i=1; i<=5 ;i++)
        {
            PlayerPrefs.DeleteKey("hantukorban"+i+"ID");
        }
        PlayerPrefs.DeleteKey("nextlevel");
        PlayerPrefs.DeleteKey("SummonMissionStats");
        PlayerPrefs.DeleteKey("SummonMissionQD");
        PlayerPrefs.DeleteKey("SoloMissionStats");
        PlayerPrefs.DeleteKey("CatchMissionStats");
        PlayerPrefs.DeleteKey("SoloMissionQD");
        PlayerPrefs.DeleteKey("CatchMissionQD");
    }

    public void LogOut()
    {
        // PlayerPrefs.DeleteAll();
        StartCoroutine(LoginOut());
    }
    IEnumerator checkID()
    {
        string url = Link.url + "checkDID";
        WWWForm form = new WWWForm();
        form.AddField(Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            Debug.Log(www.text);
            PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                if (vanny != null) {
                    vanny.SetActive(false);
                    ValidationError.SetActive(true);
                }
                else
                {
                    ValidationError.SetActive(true);
                }
               
            }
            else
            {
                Debug.Log("Nothing Happen");
            }
        }
    }
}
