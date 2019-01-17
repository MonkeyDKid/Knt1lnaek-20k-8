using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class GhostView : MonoBehaviour {

 public Button[] GhostdexButton;

public Transform GhostTransform;
    public GameObject Loading;
  
    char[] characters;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CheckGhostDex());
    }

    static string SortString(string input)
    {
        char[] characters = input.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }
    void Activate(char ghost)
    {
        print("Ghost" + ghost);
        switch (ghost)
        {
            case 'A':
                GhostdexButton[0].interactable = true;
                GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Pocong_Fire");
                break;
            case 'B':
                GhostdexButton[1].interactable = true;
                GhostdexButton[1].transform.Find("Name").GetComponent<Text>().text = "Jelangkung";
                GhostdexButton[1].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Jelangkung_Fire");
                break;
            case 'C':
                GhostdexButton[2].interactable = true;
                GhostdexButton[2].transform.Find("Name").GetComponent<Text>().text = "Babi ngepet";
                GhostdexButton[2].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Babingepet_Fire");
                break;
            case 'D':
                GhostdexButton[3].interactable = true;
                GhostdexButton[3].transform.Find("Name").GetComponent<Text>().text = "Tuyul";
                GhostdexButton[3].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Tuyul_Fire");
                break;
            case 'E':
                GhostdexButton[4].interactable = true;
                GhostdexButton[4].transform.Find("Name").GetComponent<Text>().text = "Hantu tanpa kepala";
                GhostdexButton[4].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Hantutanpakepala_Fire");
                break;
            case 'F':
                GhostdexButton[5].interactable = true;
                GhostdexButton[5].transform.Find("Name").GetComponent<Text>().text = "Muka rata";
                GhostdexButton[5].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "mukarata_Fire");
                break;
            case 'G':
                GhostdexButton[6].interactable = true;
                GhostdexButton[6].transform.Find("Name").GetComponent<Text>().text = "Kolor ijo";
                GhostdexButton[6].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "kolorijo_Fire");
                break;
            case 'H':
                GhostdexButton[7].interactable = true;
                GhostdexButton[7].transform.Find("Name").GetComponent<Text>().text = "Jin";
                GhostdexButton[7].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "jin_Fire");
                break;
            case 'I':
                GhostdexButton[8].interactable = true;
                GhostdexButton[8].transform.Find("Name").GetComponent<Text>().text = "Lembuswana";
                GhostdexButton[8].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Lembuswana_Fire");
                break;
            case 'J':
                GhostdexButton[9].interactable = true;
                GhostdexButton[9].transform.Find("Name").GetComponent<Text>().text = "Leak";
                GhostdexButton[9].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Leak_Fire");
                break;
            case 'K':
                GhostdexButton[10].interactable = true;
                GhostdexButton[10].transform.Find("Name").GetComponent<Text>().text = "Sundel bolong";
                GhostdexButton[10].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Sundelbolong_Fire");
                break;
            case 'L':
                GhostdexButton[11].interactable = true;
                GhostdexButton[11].transform.Find("Name").GetComponent<Text>().text = "Suster ngesot";
                GhostdexButton[11].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Susterngesot_Fire");
                break;
            case 'M':
                GhostdexButton[12].interactable = true;
                GhostdexButton[12].transform.Find("Name").GetComponent<Text>().text = "Kuntilanak";
                GhostdexButton[12].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Kunti_Fire");
                break;
            case 'N':
                GhostdexButton[13].interactable = true;
                GhostdexButton[13].transform.Find("Name").GetComponent<Text>().text = "Genderuwo";
                GhostdexButton[13].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Genderuwo_Fire");
                break;
            case 'O':
                GhostdexButton[14].interactable = true;
                GhostdexButton[14].transform.Find("Name").GetComponent<Text>().text = "Zombie";
                GhostdexButton[14].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Zombie_Fire");
                break;
            case 'P':
                GhostdexButton[15].interactable = true;
                GhostdexButton[15].transform.Find("Name").GetComponent<Text>().text = "Naga besukih";
                GhostdexButton[15].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Nagabesukih_Fire");
                break;
            case 'Q':
                GhostdexButton[16].interactable = true;
                GhostdexButton[16].transform.Find("Name").GetComponent<Text>().text = "Jerangkong";
                GhostdexButton[16].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Jerangkong_Fire");
                break;
            case 'R':
                GhostdexButton[17].interactable = true;
                GhostdexButton[17].transform.Find("Name").GetComponent<Text>().text = "Palasik";
                GhostdexButton[17].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Palasik_Fire");
                break;
            case 'S':
                GhostdexButton[18].interactable = true;
                GhostdexButton[18].transform.Find("Name").GetComponent<Text>().text = "Jenglot";
                GhostdexButton[18].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Jenglot_Fire");
                break;
            case 'T':
                GhostdexButton[19].interactable = true;
                GhostdexButton[19].transform.Find("Name").GetComponent<Text>().text = "Ratu Pantai";
                GhostdexButton[19].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Nyiroro_Fire");
                break;
          
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OfflineCheckGhostDex() {
        var character = "ABCDEHJKS";
        characters = SortString(character).ToCharArray();

        for (int x = 0; x < characters.Length; x++)
        {
            Activate(characters[x]);
        }
    }
    IEnumerator CheckGhostDex()
    {
        string url = Link.url + "GhostDex";
        WWWForm form = new WWWForm();
        form.AddField(Link.ID, PlayerPrefs.GetString(Link.ID));
        WWW www = new WWW(url, form);
        yield return www;
        print(www.text);
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            PlayerPrefs.SetString("GhostDex",jsonString["char"].ToString());
            print(jsonString);
            characters = SortString(jsonString["char"].ToString()).ToCharArray();
            for (int x = 0; x < characters.Length; x++)
            {
            Activate(characters[x]);
            }
            //Loading.SetActive(false);
        }
        else{
            characters = SortString(PlayerPrefs.GetString("GhostDex")).ToCharArray();
            for (int x = 0; x < characters.Length; x++)
            {
            Activate(characters[x]);
            }
            //Loading.SetActive(false);
        }
    }
    public void showGhost(string ghost){
        	foreach (Transform child in GhostTransform) {
			GameObject.Destroy(child.gameObject);
		}
        var	model = Instantiate (Resources.Load ("PrefabsChar/" + ghost) as GameObject);
		model.transform.SetParent (GhostTransform);
		 model.transform.localPosition = new Vector3(0,0,0);
		// model.transform.localScale = GhostTransform.localScale;
		model.transform.localEulerAngles = new Vector3(0,150,0);;
		model.name = "ghost";
		model.GetComponent<Animation>().PlayQueued("select",QueueMode.PlayNow);
        model.GetComponent<Animation>().PlayQueued("idle",QueueMode.CompleteOthers);
		//model.transform.SetParent (GhostTransform.FindChild ("SummonPos"));
    }
}
