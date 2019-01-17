using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour {
public bool loadbusy;
public Text Energy, EnergyShop;
public Text Coin, CoinShop;
public Text CrystalShop;
public Text SoulStone, levelP, exptext;
public Text userName, settingusername, settingemail, settingWuser, settingWpas, settingUID;
public Image levelbar;
public GameObject[] Notif;
 private void Awake() 
{
	StartCoroutine(GetDataUser());
}
public void LoadScene(string scenename)
{
	SceneManagerHelper.LoadScene(scenename);
}
 public IEnumerator GetDataUser()
    {
        if(loadbusy==false)
        {
        loadbusy=true;
        string url = Link.url + "getDataUser";
        WWWForm form = new WWWForm();
        form.AddField(Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            Debug.Log(jsonString);
            PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "0")
            {
				PlayerPrefs.SetString ("GMode",jsonString["data"]["GMode"]) ;
                Coin.text = jsonString["data"]["coin"];
                CoinShop.text = jsonString["data"]["coin"];
                CrystalShop.text = jsonString["data"]["crystal"];
                SoulStone.text = jsonString["data"]["soulstone"];
                //levelP.text = "LV "+jsonString["data"]["PlayerLevel"];
                userName.text = jsonString["data"]["user_name"];
                settingusername.text = jsonString["data"]["user_name"];
                settingemail.text = jsonString["data"]["email"];
                settingWpas.text =  "Web Pass			: "+jsonString["Wpass"];
                settingWuser.text = "Web Username	: "+jsonString["Wuser"];
                settingUID.text =    "Id : "+jsonString["data"]["UniqueID"];
                PlayerPrefs.SetString("curexp", jsonString["data"]["xpp"]);
                PlayerPrefs.SetString("tarexp", jsonString["data"]["targetexplevel"]);
                PlayerPrefs.SetString(Link.AR, jsonString["data"]["ar"]);
                PlayerPrefs.SetString("PlayerLevel", jsonString["data"]["PlayerLevel"]);
                var energy = int.Parse(jsonString["data"]["energy"]) + int.Parse(jsonString["data"]["BonusEnergy"]);
                PlayerPrefs.SetString("BonusEnergy", jsonString["data"]["BonusEnergy"]);
                PlayerPrefs.SetString("EnergyCombo", energy.ToString());
				Energy.text = energy.ToString();
                EnergyShop.text = energy.ToString();
                PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
                PlayerPrefs.SetString(Link.GOLD, jsonString["data"]["coin"]);
                PlayerPrefs.SetString("Crystal", jsonString["data"]["crystal"]);
                PlayerPrefs.SetString(Link.SOUL_STONE, jsonString["data"]["soulstone"]);
                exptext.text = jsonString["data"]["xpp"] + "/" + jsonString["data"]["targetexplevel"];
                PlayerPrefs.SetString("MaxE", jsonString["data"]["MaxEnergy"]);
                PlayerPrefs.SetString(Link.IBURU, jsonString["data"]["iklan_buru"]);
                PlayerPrefs.SetString(Link.IGOLD, jsonString["data"]["iklan_gold"]);
                PlayerPrefs.SetString(Link.IENERGY, jsonString["data"]["iklan_energy"]);
                PlayerPrefs.SetString(Link.COMMON, jsonString["data"]["common"]);
                PlayerPrefs.SetString(Link.RARE, jsonString["data"]["rare"]);
                PlayerPrefs.SetString(Link.LEGENDARY, jsonString["data"]["legendary"]);
                PlayerPrefs.SetString(Link.NewsCount, jsonString["NotifNews"]);
                PlayerPrefs.SetString(Link.EventCount, jsonString["NotifInbox"]);
                NaECount(jsonString["NotifNews"],jsonString["NotifInbox"]);
                yield return new WaitForSeconds(.5f);
                datauser();
              
				GetComponent<lifeless> ().updatedata ();
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
               SceneManagerHelper._instance.HandleError(33);
            }
        }
        else {
			 SceneManagerHelper._instance.HandleError(404);
			//errorhandle.SetActive(true);
		//	errorhandle.transform.FindChild("Dialog").gameObject.SetActive(true);
            Debug.Log("GAGAL");
			print (www.text);
        }
        }
        else
        {
            yield return null;
        }

    }
	 private void datauser()
    {
		Energy.text = PlayerPrefs.GetString("EnergyCombo");
        EnergyShop.text = PlayerPrefs.GetString("EnergyCombo");
        Coin.text = PlayerPrefs.GetString(Link.GOLD);
        CoinShop.text = PlayerPrefs.GetString(Link.GOLD);
        CrystalShop.text = PlayerPrefs.GetString("Crystal");
        SoulStone.text = PlayerPrefs.GetString("Crystal");
        levelP.text = "LV " + PlayerPrefs.GetString("PlayerLevel");
        userName.text = PlayerPrefs.GetString(Link.USER_NAME);
        settingusername.text = PlayerPrefs.GetString(Link.USER_NAME);
        settingemail.text = PlayerPrefs.GetString(Link.EMAIL);
        if (float.Parse(PlayerPrefs.GetString("tarexp")) >= 999999)
        {
            levelbar.fillAmount = 1;
            exptext.text = "MAX";
        }
        else {
            levelbar.fillAmount = float.Parse(PlayerPrefs.GetString("curexp")) / float.Parse(PlayerPrefs.GetString("tarexp"));
        }
        loadbusy=false;
    }
	private void NaECount(string mynewscount, string myeventcount)
    {
        int pnews = int.Parse(mynewscount);
        int pevent = int.Parse(myeventcount);
        int snews = 0;
        int sevent = 0;
       
          if(pnews==snews&&pevent==sevent)
        {
            for(int i=0; i<3; i++)
            {
                 Notif[i].SetActive(false);
            }
           
        }
        else
        {
        if(pnews>snews)
        {
             Notif[0].SetActive(true);
             Notif[1].SetActive(true);
        }
         else
        {
             Notif[1].SetActive(false);
        }
        if(pevent>sevent)
        {
             Notif[0].SetActive(true);
             Notif[2].SetActive(true);
        }
        else
        {
             Notif[2].SetActive(false);
        }
        }
	}
        
}
