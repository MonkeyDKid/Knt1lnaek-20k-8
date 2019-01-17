using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour {

	public GameObject map;
	//public GameObject spawn;
	public double lat=0;
	public double lon =0;
	public double lastlat =0,lastlon=0;
	public GameObject latText;
	public GameObject lonText;

	// Use this for initialization
	void Start () {
		Input.location.Start (); // enable the mobile device GPS
		if (Input.location.isEnabledByUser) { // if mobile device GPS is enabled
			lat = Input.location.lastData.latitude; //get GPS Data
			lon = Input.location.lastData.longitude;
			map.GetComponent<GoogleMap> ().centerLocation.latitude = lat;
			map.GetComponent<GoogleMap> ().centerLocation.longitude = lon;
		}

	}


	// Update is called once per frame
	void Update () {
		//      <---------Mobile Device Code----------->
		if (Input.location.isEnabledByUser) {
			lat = Input.location.lastData.latitude;
			lon = Input.location.lastData.longitude;
			if (lastlat != lat || lastlon != lon) {
				map.GetComponent<GoogleMap> ().centerLocation.latitude = lat;
				map.GetComponent<GoogleMap> ().centerLocation.longitude = lon;
				latText.GetComponent<Text> ().text = "Lat" + lat.ToString ();
				lonText.GetComponent<Text> ().text = "Lon" + lon.ToString ();
				//spawn.GetComponent<Spawn> ().updateMonstersPosition (lon, lat);
				//Add above after you complete spawn part
				map.GetComponent<GoogleMap> ().Refresh ();
				map.GetComponent<GoogleMap>().Mark();

			}
			lastlat = lat;
			lastlon = lon;
		}
		//      <---------Mobile Device Code----------->

		//      <---------PC Test Code----------->
		        if (lastlat != lat || lastlon != lon) {
		        map.GetComponent<GoogleMap> ().centerLocation.latitude = lat;
		        map.GetComponent<GoogleMap> ().centerLocation.longitude = lon;
		        latText.GetComponent<Text> ().text = "Lat" + lat.ToString ();
		        lonText.GetComponent<Text> ().text = "Lon" + lon.ToString ();
		        //    spawn.GetComponent<Spawn> ().updateMonstersPosition (lon, lat);
		
		        map.GetComponent<GoogleMap> ().Refresh ();
				map.GetComponent<GoogleMap>().Mark();
		        }
		                    lastlat = lat;
		                    lastlon = lon;
		//      <---------PC Test Code----------->

	}

	public double getLon(){
		return lon;
	}
	public double getLat(){
		return lat;
	}

}
