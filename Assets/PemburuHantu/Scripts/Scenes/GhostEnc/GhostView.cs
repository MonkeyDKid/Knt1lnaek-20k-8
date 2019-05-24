using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class GhostView : MonoBehaviour {

 public Button[] GhostdexButton;

 public HantuLore HantuInfo;
public string[] split;
public Text[] InfoText;
public GameObject[] Element;
public Sprite[] ElementPlat;
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
    void Activate(string ghost)
    {
        print("Ghost" + ghost);
        switch (ghost)
        {
            case "A1":
                GhostdexButton[0].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[0].GetComponent<GhostViewButton>().ghostnumber = 0;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Pocong_Fire");
                break;
            case "A2":
                 GhostdexButton[1].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[1].GetComponent<GhostViewButton>().ghostnumber = 1;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[1].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Pocong_water");
                break;
            case "A3":
                 GhostdexButton[2].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[2].GetComponent<GhostViewButton>().ghostnumber = 2;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[2].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Pocong_wind");
                break;
            
            case "B1":
                GhostdexButton[3].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[3].GetComponent<GhostViewButton>().ghostnumber = 3;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[3].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jelangkung_Fire");
                break;
            case "B2":
                GhostdexButton[4].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[4].GetComponent<GhostViewButton>().ghostnumber = 4;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[4].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jelangkung_water");
                break;
            case "B3":
                 GhostdexButton[5].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[5].GetComponent<GhostViewButton>().ghostnumber = 5;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[5].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jelangkung_wind");
                break;
            case "C1":
                GhostdexButton[6].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[6].GetComponent<GhostViewButton>().ghostnumber = 6;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[6].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Babingepet_Fire");
                break;
            case "C2":
                 GhostdexButton[7].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[7].GetComponent<GhostViewButton>().ghostnumber = 7;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[7].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Babingepet_water");
                break;
            case "C3":
                GhostdexButton[8].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[8].GetComponent<GhostViewButton>().ghostnumber = 8;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[8].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Babingepet_wind");
                break;
            
            case "D1":
                 GhostdexButton[9].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[9].GetComponent<GhostViewButton>().ghostnumber = 9;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[9].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Tuyul_Fire");
                break;
            case "D2":
                 GhostdexButton[10].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[10].GetComponent<GhostViewButton>().ghostnumber = 10;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[10].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Tuyul_water");
                break;
            case "D3":
                GhostdexButton[11].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[11].GetComponent<GhostViewButton>().ghostnumber = 11;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[11].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Tuyul_wind");
                break;
            
            case "E1":
                GhostdexButton[12].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[12].GetComponent<GhostViewButton>().ghostnumber = 12;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[12].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Hantutanpakepala_Fire");
                break;
            case "E2":
                GhostdexButton[13].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[13].GetComponent<GhostViewButton>().ghostnumber = 13;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[13].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Hantutanpakepala_water");
                break;
            case "E3":
                GhostdexButton[14].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[14].GetComponent<GhostViewButton>().ghostnumber = 14;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text 14= "Pocong";
                GhostdexButton[14].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Hantutanpakepala_wind");
                break;
            case "F1":
                GhostdexButton[15].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[15].GetComponent<GhostViewButton>().ghostnumber = 15;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[15].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "mukarata_Fire");
                break;
             case "F2":
                GhostdexButton[16].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[16].GetComponent<GhostViewButton>().ghostnumber = 16;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[16].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "mukarata_water");
                break;
             case "F3":
                 GhostdexButton[17].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[17].GetComponent<GhostViewButton>().ghostnumber = 17;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[17].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "mukarata_wind");
                break;
            case "G1":
                 GhostdexButton[18].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[18].GetComponent<GhostViewButton>().ghostnumber = 18;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[18].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "kolorijo_Fire");
                break;
            case "G2":
                GhostdexButton[19].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[19].GetComponent<GhostViewButton>().ghostnumber = 19;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[19].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "kolorijo_water");
                break;
            case "G3":
                GhostdexButton[20].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[20].GetComponent<GhostViewButton>().ghostnumber = 20;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[20].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "kolorijo_wind");
                break;
            case "H1":
                GhostdexButton[21].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[21].GetComponent<GhostViewButton>().ghostnumber = 21;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[21].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "jin_Fire");
                break;
            case "H2":
                GhostdexButton[2].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[22].GetComponent<GhostViewButton>().ghostnumber = 22;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[22].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "jin_water");
                break;
            case "H3":
                GhostdexButton[23].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[23].GetComponent<GhostViewButton>().ghostnumber = 23;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[23].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "jin_wind");
                break;
            case "I1":
                GhostdexButton[24].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[24].GetComponent<GhostViewButton>().ghostnumber = 24;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[24].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Lembuswana_Fire");
                break;
             case "I2":
                GhostdexButton[25].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[25].GetComponent<GhostViewButton>().ghostnumber = 25;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[25].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Lembuswana_water");
                break;
             case "I3":
                GhostdexButton[26].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[26].GetComponent<GhostViewButton>().ghostnumber = 26;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[26].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Lembuswana_wind");
                break;
            case "J1":
                 GhostdexButton[27].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[27].GetComponent<GhostViewButton>().ghostnumber = 27;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[27].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Leak_Fire");
                break;
            case "J2":
                 GhostdexButton[28].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[28].GetComponent<GhostViewButton>().ghostnumber = 28;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[28].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Leak_water");
                break;
            case "J3":
                 GhostdexButton[29].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[29].GetComponent<GhostViewButton>().ghostnumber = 29;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[29].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Leak_wind");
                break;
            case "K1":
                 GhostdexButton[30].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[30].GetComponent<GhostViewButton>().ghostnumber = 30;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[30].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Sundelbolong_Fire");
                break;
            case "K2":
                GhostdexButton[31].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[31].GetComponent<GhostViewButton>().ghostnumber = 31;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[31].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Sundelbolong_water");
                break;
            case "K3":
                 GhostdexButton[32].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[32].GetComponent<GhostViewButton>().ghostnumber = 32;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[32].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Sundelbolong_wind");
                break;
            case "L1":
                 GhostdexButton[33].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[33].GetComponent<GhostViewButton>().ghostnumber = 33;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[33].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Susterngesot_Fire");
                break;
            case "L2":
                GhostdexButton[34].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[34].GetComponent<GhostViewButton>().ghostnumber = 34;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[34].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Susterngesot_water");
                break;
            case "L3":
                 GhostdexButton[35].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[35].GetComponent<GhostViewButton>().ghostnumber = 35;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[35].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Susterngesot_wind");
                break;
            case "M1":
                GhostdexButton[36].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[36].GetComponent<GhostViewButton>().ghostnumber = 36;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[36].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Kunti_Fire");
                break;
             case "M2":
                GhostdexButton[37].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[37].GetComponent<GhostViewButton>().ghostnumber = 37;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[37].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Kunti_water");
                break;
             case "M3":
                GhostdexButton[38].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[38].GetComponent<GhostViewButton>().ghostnumber = 38;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[38].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Kunti_wind");
                break;
            case "N1":
                GhostdexButton[39].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[39].GetComponent<GhostViewButton>().ghostnumber = 39;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[39].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Genderuwo_Fire");
                break;
             case "N2":
                 GhostdexButton[40].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[40].GetComponent<GhostViewButton>().ghostnumber = 40;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[40].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Genderuwo_water");
                break;
             case "N3":
                GhostdexButton[41].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[41].GetComponent<GhostViewButton>().ghostnumber = 41;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[41].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Genderuwo_wind");
                break;
            case "O1":
                GhostdexButton[42].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[42].GetComponent<GhostViewButton>().ghostnumber = 42;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[42].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Zombie_Fire");
                break;
            case "O2":
                GhostdexButton[43].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[43].GetComponent<GhostViewButton>().ghostnumber = 43;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[43].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Zombie_water");
                break;
            case "O3":
                 GhostdexButton[44].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[44].GetComponent<GhostViewButton>().ghostnumber = 44;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[44].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Zombie_wind");
                break;
            case "P1":
                GhostdexButton[45].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[45].GetComponent<GhostViewButton>().ghostnumber = 45;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().tex4t = "Pocong";
                GhostdexButton[45].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Nagabesukih_Fire");
                break;
            case "P2":
                GhostdexButton[46].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[46].GetComponent<GhostViewButton>().ghostnumber = 46;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[46].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_charLama/" + "Nagabesukih_water");
                break;
            case "P3":
                GhostdexButton[47].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[47].GetComponent<GhostViewButton>().ghostnumber = 47;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text47 = "Pocong";
                GhostdexButton[47].GetComponent<Image>().sprite =Resources.Load<Sprite> ("icon_charLama/" + "Nagabesukih_wind");
                break;
            case "Q1":
                GhostdexButton[48].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[48].GetComponent<GhostViewButton>().ghostnumber = 48;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[48].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jerangkong_Fire");
                break;
            case "Q2":
                GhostdexButton[49].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[49].GetComponent<GhostViewButton>().ghostnumber = 49;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[49].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jerangkong_water");
                break;
            case "Q3":
               GhostdexButton[50].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[50].GetComponent<GhostViewButton>().ghostnumber = 50;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().tex50t = "Pocong";
                GhostdexButton[50].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jerangkong_wind");
                break;
            case "R1":
                GhostdexButton[51].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[51].GetComponent<GhostViewButton>().ghostnumber = 51;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[51].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Palasik_Fire");
                break;
             case "R2":
               GhostdexButton[52].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[52].GetComponent<GhostViewButton>().ghostnumber = 52;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text52 = "Pocong";
                GhostdexButton[52].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Palasik_water");
                break;
             case "R3":
                GhostdexButton[53].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[53].GetComponent<GhostViewButton>().ghostnumber = 53;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[53].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Palasik_wind");
                break;
            case "S1":
               GhostdexButton[54].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[54].GetComponent<GhostViewButton>().ghostnumber = 54;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().tex54t = "Pocong";
                GhostdexButton[54].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jenglot_Fire");
                break;
            case "S2":
                GhostdexButton[55].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[55].GetComponent<GhostViewButton>().ghostnumber = 55;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[55].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jenglot_water");
                break;
            case "S3":
                GhostdexButton[56].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[56].GetComponent<GhostViewButton>().ghostnumber = 56;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[56].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Jenglot_wind");
                break;
            case "T1":
                GhostdexButton[57].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[57].GetComponent<GhostViewButton>().ghostnumber = 57;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[57].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Nyiroro_Fire");
                break;
            case "T2":
                 GhostdexButton[58].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[58].GetComponent<GhostViewButton>().ghostnumber = 58;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[58].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Nyiroro_water");
                break;
            case "T3":
                GhostdexButton[59].GetComponent<GhostViewButton>().opened = true;
                GhostdexButton[59].GetComponent<GhostViewButton>().ghostnumber = 59;
                // GhostdexButton[0].transform.Find("Name").GetComponent<Text>().text = "Pocong";
                GhostdexButton[59].GetComponent<Image>().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + "Nyiroro_wind");
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
            // Activate(characters[x]);
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
            string strA = jsonString["char"];
            split = new string[strA.Length/2 + (strA.Length%2 == 0 ? 0 : 1)];
            for (int i = 0; i < split.Length; i++)
            {
                split[ i ] = strA.Substring(i * 2, i * 2 + 2 > strA.Length ? 1 : 2);
            }
            //characters = SortString(jsonString["char"].ToString()).ToCharArray();
            for (int x = 0; x < split.Length; x++)
            {
            Activate(split[x]);
            }
            //Loading.SetActive(false);
        }
        else{
            string strA = PlayerPrefs.GetString("GhostDex");
            split = new string[strA.Length/2 + (strA.Length%2 == 0 ? 0 : 1)];
            for (int i = 0; i < split.Length; i++)
            {
                split[ i ] = strA.Substring(i * 2, i * 2 + 2 > strA.Length ? 1 : 2);
            }
            //characters = SortString(jsonString["char"].ToString()).ToCharArray();
            for (int x = 0; x < split.Length; x++)
            {
            Activate(split[x]);
            }
            //Loading.SetActive(false);
        }
    }
    private void hideelement()
    {
        for(int i=0;i<3;i++)
        {
            Element[i].SetActive(false);
        }
    }
    public void showGhost(int ghostnumber){
        hideelement();
        	foreach (Transform child in GhostTransform) {
			GameObject.Destroy(child.gameObject);
		}
        var ghostdata = HantuInfo.GetData(ghostnumber);
        var	model = Instantiate (Resources.Load ("PrefabsChar/" + (ghostdata.File)) as GameObject);
		model.transform.SetParent (GhostTransform);
		model.transform.localPosition = new Vector3(0,0,0);
        if(ghostdata.Element=="Fire")
        {
            Element[0].SetActive(true);
            Element[3].GetComponent<Image>().sprite = ElementPlat[0];
        }
        else if(ghostdata.Element=="Water")
        {
            Element[1].SetActive(true);
            Element[3].GetComponent<Image>().sprite = ElementPlat[1];
        }
        else
        {
            Element[2].SetActive(true);
            Element[3].GetComponent<Image>().sprite = ElementPlat[2];
        }
        InfoText[0].text = ghostdata.Name+" "+ ghostdata.Element;
        InfoText[1].text = "ATK: "+ghostdata.Attack;
        InfoText[2].text = "DEF: "+ghostdata.Defense;
        InfoText[3].text = "HP: "+ghostdata.HP;
        InfoText[4].text = ghostdata.Lore;
        InfoText[5].text = ghostdata.Type;
		// model.transform.localScale = GhostTransform.localScale;
		model.transform.localEulerAngles = new Vector3(0,150,0);;
		model.name = "ghost";
		model.GetComponent<Animation>().PlayQueued("select",QueueMode.PlayNow);
        model.GetComponent<Animation>().PlayQueued("idle",QueueMode.CompleteOthers);
		//model.transform.SetParent (GhostTransform.FindChild ("SummonPos"));
    }
}
public struct HantuSini{
    public string Name,Element,Attack,Defense,HP,Type,Lore;
}
