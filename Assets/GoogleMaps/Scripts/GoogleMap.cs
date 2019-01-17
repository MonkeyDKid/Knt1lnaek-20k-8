using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;
public class GoogleMap : MonoBehaviour
{
	public enum MapType
	{
		RoadMap,
		Satellite,
		Terrain,
		Hybrid
	}
	public RawImage mapUI;
	public bool loadOnStart = true;
	public bool autoLocateCenter = true;
	public GoogleMapLocation centerLocation;
	public int zoom = 13;
	public string qs = "";
	public string abc ;
	public MapType mapType;
	public int size = 512;
	public bool doubleResolution = false;
	public GoogleMapMarker[] markers;
	public GoogleMapPath[] paths;
	
	void Start() {
		StartCoroutine(GetMarkers());
		//if(loadOnStart) Refresh();	
	}
	
	public void Refresh() {
		if(autoLocateCenter && (markers.Length == 0 && paths.Length == 0)) {
		//	Debug.LogError("Auto Center will only work if paths or markers are used.");	
		}
		StartCoroutine(_Refresh());
	}

	public void Mark(){
		StartCoroutine(GetMarkers());}
	IEnumerator GetMarkers(){
		string url = "http://139.59.100.192/PH/" + "all";
		WWWForm form = new WWWForm ();
		form.AddField ("ID", PlayerPrefs.GetString ("ID"));
		WWW www = new WWW (url, form);
		yield return www;
	//	Debug.Log (www.text);
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
						abc+="|"+jsonString["data"][x]["latitude"]+","+jsonString["data"][x]["longitude"];
					}

					yield return new WaitForSeconds (.1f);
					//GetComponent<GoogleMap> ().markers [0].locations = monsterLL;
					//GetComponent<GoogleMap> ().Refresh ();
				//GetComponent<GoogleMap> ().Refresh ();
				GetComponent<GoogleMap> ().qs += "|icon:https://i.imgur.com/ObPho7v.png"+abc;
			//	yield return new WaitForSeconds (1f);
				StartCoroutine (requesting ());				

			}
		}
	}

	IEnumerator _Refresh ()
	{ 
		var url = "http://maps.googleapis.com/maps/api/staticmap";
		//DebugConsole.Log ("GoogleMapRefresh");
		if (!autoLocateCenter) {
			if (centerLocation.address != "")
				qs += "center=" + WWW.UnEscapeURL (centerLocation.address);
			else {
				qs += "center=" + WWW.UnEscapeURL (string.Format ("{0},{1}", centerLocation.latitude, centerLocation.longitude));
			}
		
			qs += "&zoom=" + zoom.ToString ();
		}
		qs += "&size=" + WWW.UnEscapeURL (string.Format ("{0}x{0}", size));
		qs += "&scale=" + (doubleResolution ? "2" : "1");
		qs += "&maptype=" + mapType.ToString ().ToLower ();
		var usingSensor = false;
#if UNITY_IPHONE
		usingSensor = Input.location.isEnabledByUser && Input.location.status == LocationServiceStatus.Running;
#endif
		qs += "&sensor=" + (usingSensor ? "true" : "false");
		
		foreach (var i in markers) {
			qs += "&markers=" + string.Format ("size:{0}|color:{1}|label:{2}", i.size.ToString ().ToLower (), i.color, i.label);
			foreach (var loc in i.locations) {
				if (loc.address != "")
					qs += "|" + WWW.UnEscapeURL (loc.address);
				else
					qs += "|" + WWW.UnEscapeURL (string.Format ("{0},{1}", loc.latitude, loc.longitude));
			}
		}
		
		foreach (var i in paths) {
			qs += "&path=" + string.Format ("weight:{0}|color:{1}", i.weight, i.color);
			if(i.fill) qs += "|fillcolor:" + i.fillColor;
			foreach (var loc in i.locations) {
				if (loc.address != "")
					qs += "|" + WWW.UnEscapeURL (loc.address);
				else
					qs += "|" + WWW.UnEscapeURL (string.Format ("{0},{1}", loc.latitude, loc.longitude));
			}
		}
		
		yield return null;
//		var req = new WWW (url + "?" + qs);
//		yield return req;
//		GetComponent<MeshRenderer>().material.mainTexture = req.texture;
//		Debug.Log (qs);


	}
	
	IEnumerator requesting(){
		StartCoroutine (_Refresh());
		var url = "http://maps.googleapis.com/maps/api/staticmap";
		var req = new WWW (url + "?" + qs);
		yield return req;
		mapUI.GetComponent<RawImage> ().texture = req.texture;
		GetComponent<MeshRenderer>().material.mainTexture = req.texture;
		Debug.Log (url+"?"+qs);
		qs = "";
	}
}


public enum GoogleMapColor
{
	black,
	brown,
	green,
	purple,
	yellow,
	blue,
	gray,
	orange,
	red,
	white
}

[Serializable]
public class GoogleMapLocation
{
	public string address;
	public double latitude;
	public double longitude;
}

[Serializable]
public class GoogleMapMarker
{
	public enum GoogleMapMarkerSize
	{
		Tiny,
		Small,
		Mid
	}
	public GoogleMapMarkerSize size;
	public GoogleMapColor color;
	public string label;
	public GoogleMapLocation[] locations;
	
}

[Serializable]
public class GoogleMapPath
{
	public int weight = 5;
	public GoogleMapColor color;
	public bool fill = false;
	public GoogleMapColor fillColor;
	public GoogleMapLocation[] locations;	
}