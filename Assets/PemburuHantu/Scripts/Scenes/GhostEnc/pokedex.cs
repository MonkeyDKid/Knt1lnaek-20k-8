using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;
using System.Linq;

public class pokedex : MonoBehaviour
{
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
                GhostdexButton[0].transform.Find("NewStat").GetComponent<Text>().text = "Pocong";
                break;
            case 'B':
                GhostdexButton[1].interactable = true;
                GhostdexButton[1].transform.Find("NewStat").GetComponent<Text>().text = "Jelangkung";
                break;
            case 'C':
                GhostdexButton[2].interactable = true;
                GhostdexButton[2].transform.Find("NewStat").GetComponent<Text>().text = "Babi ngepet";
                break;
            case 'D':
                GhostdexButton[3].interactable = true;
                GhostdexButton[3].transform.Find("NewStat").GetComponent<Text>().text = "Tuyul";
                break;
            case 'E':
                GhostdexButton[4].interactable = true;
                GhostdexButton[4].transform.Find("NewStat").GetComponent<Text>().text = "Hantu tanpa kepala";
                break;
            case 'F':
                GhostdexButton[5].interactable = true;
                GhostdexButton[5].transform.Find("NewStat").GetComponent<Text>().text = "Muka rata";
                break;
            case 'G':
                GhostdexButton[6].interactable = true;
                GhostdexButton[6].transform.Find("NewStat").GetComponent<Text>().text = "Kolor ijo";
                break;
            case 'H':
                GhostdexButton[7].interactable = true;
                GhostdexButton[7].transform.Find("NewStat").GetComponent<Text>().text = "Jin";
                break;
            case 'I':
                GhostdexButton[8].interactable = true;
                GhostdexButton[8].transform.Find("NewStat").GetComponent<Text>().text = "Lembuswana";
                break;
            case 'J':
                GhostdexButton[9].interactable = true;
                GhostdexButton[9].transform.Find("NewStat").GetComponent<Text>().text = "Leak";
                break;
            case 'K':
                GhostdexButton[10].interactable = true;
                GhostdexButton[10].transform.Find("NewStat").GetComponent<Text>().text = "Sundel bolong";
                break;
            case 'L':
                GhostdexButton[11].interactable = true;
                GhostdexButton[11].transform.Find("NewStat").GetComponent<Text>().text = "Suster ngesot";
                break;
            case 'M':
                GhostdexButton[12].interactable = true;
                GhostdexButton[12].transform.Find("NewStat").GetComponent<Text>().text = "Kuntilanak";
                break;
            case 'N':
                GhostdexButton[13].interactable = true;
                GhostdexButton[13].transform.Find("NewStat").GetComponent<Text>().text = "Genderuwo";
                break;
            case 'O':
                GhostdexButton[14].interactable = true;
                GhostdexButton[14].transform.Find("NewStat").GetComponent<Text>().text = "Zombie";
                break;
            case 'P':
                GhostdexButton[15].interactable = true;
                GhostdexButton[15].transform.Find("NewStat").GetComponent<Text>().text = "Naga besukih";
                break;
            case 'Q':
                GhostdexButton[16].interactable = true;
                GhostdexButton[16].transform.Find("NewStat").GetComponent<Text>().text = "Jerangkong";
                break;
            case 'R':
                GhostdexButton[17].interactable = true;
                GhostdexButton[17].transform.Find("NewStat").GetComponent<Text>().text = "Palasik";
                break;
            case 'S':
                GhostdexButton[18].interactable = true;
                GhostdexButton[18].transform.Find("NewStat").GetComponent<Text>().text = "Jenglot";
                break;
            case 'T':
                GhostdexButton[19].interactable = true;
                GhostdexButton[19].transform.Find("NewStat").GetComponent<Text>().text = "Ratu Pantai";
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
            Loading.SetActive(false);
        }
        else{
            characters = SortString(PlayerPrefs.GetString("GhostDex")).ToCharArray();
            for (int x = 0; x < characters.Length; x++)
            {
            Activate(characters[x]);
            }
             Loading.SetActive(false);
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
		model.transform.localEulerAngles = new Vector3(0,0,0);;
		model.name = "ghost";
        model.GetComponent<Animation>().PlayQueued("idle",QueueMode.CompleteOthers);
		//model.transform.SetParent (GhostTransform.FindChild ("SummonPos"));
    }
}
