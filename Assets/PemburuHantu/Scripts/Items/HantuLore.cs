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
     public string Name, Lore;
            
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
            XmlNode addr = name.NextSibling;
            XmlNode phone = addr.NextSibling;
			DaftarHantu.Name=(name.InnerXml);
			DaftarHantu.Lore=(addr.InnerXml);
			Hantu.Add(DaftarHantu);
			
        }
    }
	public void GetHantuLore(string Name)
	{
		//uiText.text = Hantu.Contains(Name)
		var ghost = Hantu.Where(x => x.Name == Name).SingleOrDefault();
		uiText.text = ghost.Lore;
	}

	
}
