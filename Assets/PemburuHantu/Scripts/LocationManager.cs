﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
public class LocationManager : MonoBehaviour {

	private UIBubblePopupManager UIBPM;
	public GameObject map;
	public Texture2D forMarker;
	//public GameObject spawn;
	public double lat=0;
	public double lon =0;
	public double lastlat =0,lastlon=0;
	public GameObject latText;
	public GameObject lonText;

	public Texture2D[] markerImagelist;

	// Use this for initialization
	void Start () {
		UIBPM = map.GetComponent<UIBubblePopupManager>();
		Input.location.Start (); // enable the mobile device GPS
		if (Input.location.isEnabledByUser) { // if mobile device GPS is enabled
			lat = Input.location.lastData.latitude; //get GPS Data
			lon = Input.location.lastData.longitude;
			map.GetComponent<OnlineMaps> ().SetPosition(lon,lat);
			
			//map.GetComponent<OnlineMaps> ().centerLocation.longitude = lon;
		}
		StartCoroutine(GetMarkers());
		StartCoroutine(GetMarkers5KM());


	}


	// Update is called once per frame
	void Update () {
		//      <---------Mobile Device Code----------->
		if (Input.location.isEnabledByUser) {
			lat = Input.location.lastData.latitude;
			lon = Input.location.lastData.longitude;
			if (lastlat != lat || lastlon != lon) {
				map.GetComponent<OnlineMaps> ().SetPosition(lon,lat);
				// map.GetComponent<OnlineMaps> ().centerLocation.longitude = lon;
				latText.GetComponent<Text> ().text = "Lat" + lat.ToString ();
				lonText.GetComponent<Text> ().text = "Lon" + lon.ToString ();
				//spawn.GetComponent<Spawn> ().updateMonstersPosition (lon, lat);
				//Add above after you complete spawn part
				// map.GetComponent<GoogleMap> ().Refresh ();
				// map.GetComponent<GoogleMap>().Mark();

			}
			lastlat = lat;
			lastlon = lon;
		}
		//      <---------Mobile Device Code----------->

		//      <---------PC Test Code----------->
		        if (lastlat != lat || lastlon != lon) {
		        map.GetComponent<OnlineMaps> ().SetPosition(lon,lat);
		        // map.GetComponent<GoogleMap> ().centerLocation.longitude = lon;
		        latText.GetComponent<Text> ().text = "Lat" + lat.ToString ();
		        lonText.GetComponent<Text> ().text = "Lon" + lon.ToString ();
		        //    spawn.GetComponent<Spawn> ().updateMonstersPosition (lon, lat);
		
		        // map.GetComponent<GoogleMap> ().Refresh ();
				// map.GetComponent<GoogleMap>().Mark();
		        }
		                    lastlat = lat;
		                    lastlon = lon;
		//      <---------PC Test Code----------->

	}

	IEnumerator GetMarkers(){
		string url = "http://139.59.100.192/PH/" + "all";
		WWWForm form = new WWWForm ();
		form.AddField ("ID", PlayerPrefs.GetString ("ID"));
		WWW www = new WWW (url, form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			int count = int.Parse (jsonString ["count"]);
			PlayerPrefs.SetString ("FOR_CONVERTING", jsonString ["code"]);
			if (PlayerPrefs.GetString ("FOR_CONVERTING") == "0") {
				//Array.Resize (ref GetComponent<GoogleMap> ().markers [0].locations ,count);

					//yield return new WaitForSeconds (1f);
					for (int x = 0; x < int.Parse (jsonString ["count"]); x++) {
						//GetComponent<GoogleMap> ().markers [0].locations [x].address = jsonString["data"][x]["namatempat"];
						//	GetComponent<GoogleMap> ().markers [0].locations [x].latitude = double.Parse(jsonString["data"][x]["latitude"]);
						//	GetComponent<GoogleMap> ().markers [0].locations [x].longitude = double.Parse(jsonString["data"][x]["longitude"]);
						// abc+="|"+jsonString["data"][x]["latitude"]+","+jsonString["data"][x]["longitude"];
						if(jsonString["data"][x]["longitude"]!=null)
						{
							double longitudef = double.Parse(jsonString["data"][x]["longitude"]);
							double latitudef  = double.Parse(jsonString["data"][x]["latitude"]);
							OnlineMapsMarker marker = OnlineMaps.instance.AddMarker(longitudef, latitudef);
							marker.texture = markerImagelist[3];
							marker.scale = .7f;
							
						}
						
					}

					yield return new WaitForSeconds (.1f);
					
				// StartCoroutine (requesting ());				

			}
		}
	}


IEnumerator GetMarkers5KM(){
		string url = "http://139.59.100.192/PH/" + "all5KM";
		WWWForm form = new WWWForm ();
		form.AddField ("PID", PlayerPrefs.GetString ("ID"));
		form.AddField ("latitude", lastlat.ToString());
		form.AddField ("longitude", lastlon.ToString());
		WWW www = new WWW (url, form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			int count = int.Parse (jsonString ["count"]);
			PlayerPrefs.SetString ("FOR_CONVERTING", jsonString ["code"]);
			if (PlayerPrefs.GetString ("FOR_CONVERTING") == "0") {
				//Array.Resize (ref GetComponent<GoogleMap> ().markers [0].locations ,count);

					//yield return new WaitForSeconds (1f);
					for (int x = 0; x < int.Parse (jsonString ["count"]); x++) {
						//GetComponent<GoogleMap> ().markers [0].locations [x].address = jsonString["data"][x]["namatempat"];
						//	GetComponent<GoogleMap> ().markers [0].locations [x].latitude = double.Parse(jsonString["data"][x]["latitude"]);
						//	GetComponent<GoogleMap> ().markers [0].locations [x].longitude = double.Parse(jsonString["data"][x]["longitude"]);
						// abc+="|"+jsonString["data"][x]["latitude"]+","+jsonString["data"][x]["longitude"];
						if(jsonString["data"][x]["lot"]!=null)
						{
						//	int codeTexture = int.Parse(jsonString["data"][x]["codetexture"]);
							double longitudef = double.Parse(jsonString["data"][x]["lot"]);
							double latitudef  = double.Parse(jsonString["data"][x]["lat"]);
							OnlineMapsMarker marker = OnlineMaps.instance.AddMarker(longitudef, latitudef);
							marker.label = jsonString["data"][x]["setGame"];
							marker.scale = .7f;
							marker.OnClick += UIBPM.OnMarkerClick;
							marker.id = double.Parse(jsonString["data"][x]["nodeid"]);
              				marker.texture = getmarkerTexture(CodeTexture(marker.label));
						}
						
					}

					yield return new WaitForSeconds (.1f);
					
				// StartCoroutine (requesting ());				

			}
		}
	}
	
	private int CodeTexture(string PrizeName)
	{
		int cupu = 0;
		switch (PrizeName)
		{
			case "Gem":
			cupu=6;
			break;
			case "Roll":
			cupu=8;
			break;
			case "CrystalMarker":
			cupu=8;
			break;
			case "GoldMarker":
			cupu=7;
			break;
			case "Hantu":
			cupu=1;
			break;
		}
		return cupu;
	}
	private Texture2D getmarkerTexture(int codeTexture)
	{ 
		return markerImagelist[codeTexture];
	}


	public double getLon(){
		return lon;
	}
	public double getLat(){
		return lat;
	}

}
