using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using System.Linq;

 [System.Serializable]
 public struct Hantu
 {
     public string Name,File,Element,Attack,Defense,HP,Type,Lore;
            
 }
 [System.Serializable]
public class HantuLore : MonoBehaviour {

 public TextAsset xmlRawFile;
 public Text uiText;
 Hantu DaftarHantu;

[SerializeField]
  public List<Hantu> Hantu = new List<Hantu>();
	// Use this for initialization
	void Start () {
 		string data = xmlRawFile.text;
        parseXmlFile (data);
	}

void parseXmlFile(string xmlData)
    {
		DaftarHantu = new Hantu();
        XmlDocument xmlDoc = new XmlDocument ();
        xmlDoc.Load ( new StringReader(xmlData));
		
        string xmlPathPattern = "//Hantu/hantu";
        XmlNodeList myNodeList = xmlDoc.SelectNodes (xmlPathPattern);
		
		foreach(XmlNode node in myNodeList)
        {
			
            XmlNode name = node.FirstChild;
			XmlNode file = name.NextSibling;
            XmlNode element = file.NextSibling;
			XmlNode attack = element.NextSibling;
			XmlNode defense = attack.NextSibling;
			XmlNode hp = defense.NextSibling;
            XmlNode type = hp.NextSibling;
			XmlNode lore = type.NextSibling;
			DaftarHantu.Name=(name.InnerXml);
			DaftarHantu.File=(file.InnerXml);
			DaftarHantu.Element=(element.InnerXml);
			DaftarHantu.Attack=(attack.InnerXml);
			DaftarHantu.Defense=(defense.InnerXml);
			DaftarHantu.HP=(hp.InnerXml);
			DaftarHantu.Type=(type.InnerXml);
			DaftarHantu.Lore=(lore.InnerXml);
			Hantu.Add(DaftarHantu);
			
        }
    }
	public void GetHantuLore(string Name)
	{
		//uiText.text = Hantu.Contains(Name)
		var ghost = Hantu.Where(x => x.Name == Name).SingleOrDefault();
		uiText.text = ghost.Lore;
	}

	public Hantu GetData(int number)
	{
		//uiText.text = Hantu.Contains(Name)
		var ghost = Hantu[number];
		return ghost;
	}

	
}
