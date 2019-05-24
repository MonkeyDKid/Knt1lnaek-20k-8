/*     INFINITY CODE 2013-2018      */
/*   http://www.infinity-code.com   */

using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using SimpleJSON;
using System.Collections;


    /// <summary>
    /// Example is how to use a combination of data from Google Places API on bubble popup.
    /// </summary>
    public class UIBubblePopupManager : MonoBehaviour
    {
        /// <summary>
        /// Root canvas
        /// </summary>
        public Canvas canvas;

        /// <summary>
        /// Bubble popup
        /// </summary>
        public GameObject bubble;
        public GameObject BattlePrefab;
        public GameObject Prefab;
        public GameObject[] PricePrefab;
        public OSMberburu OSM;
        public OnlineMapsLocationService OMLS;

        /// <summary>
        /// Title text
        /// </summary>
        public Text title;

        /// <summary>
        /// Address text
        /// </summary>
        public Text address;

        /// <summary>
        /// Photo RawImage
        /// </summary>
        public RawImage photo;

        public CData[] datas;

        /// <summary>
        /// Reference to active marker
        /// </summary>
        private OnlineMapsMarker targetMarker;

        /// <summary>
        /// This method is called when downloading photo texture.
        /// </summary>
        /// <param name="texture2D">Photo texture</param>
        private void OnDownloadPhotoComplete(OnlineMapsWWW www)
        {
            Texture2D texture = new Texture2D(1, 1);
            www.LoadImageIntoTexture(texture);

            // Set place texture to bubble popup
            photo.texture = texture;
        }

        /// <summary>
        /// This method is called by clicking on the map
        /// </summary>
        private void OnMapClick()
        {
            // Remove active marker reference
            targetMarker = null;
            BattlePrefab.transform.DOLocalMoveY(-325, .5f);
            // Hide the popup
            bubble.transform.DOLocalMoveY(-365,.5f).OnComplete(delegate(){
                bubble.SetActive(false);
            });
            
            
        }
        

        /// <summary>
        /// This method is called by clicking on the marker
        /// </summary>
        /// <param name="marker">The marker on which clicked</param>
        public void OnMarkerClick(OnlineMapsMarkerBase marker)
        {
            print("marker");
            // Set active marker reference
            targetMarker = marker as OnlineMapsMarker;
            // Get a result item from instance of the marker
            // CData data = marker.customData as CData;
            // if (data == null) return;

            // Show the popup
            StartCoroutine(Cek(targetMarker.id, marker));
            
            // Set title and address
            // title.text = data.title;
            // address.text = data.address;

            // Destroy the previous photo
            // if (photo.texture != null)
            // {
            //     OnlineMapsUtils.DestroyImmediate(photo.texture);
            //     photo.texture = null;
            // }

            // OnlineMapsWWW www = OnlineMapsUtils.GetWWW(data.photo_url);
         //   www.OnComplete += OnDownloadPhotoComplete;

            // Initial update position
            //UpdateBubblePosition();
        }

        private void dailysavelist(string namatempat, float lat, float lot)
        {
            PlayerPrefs.SetFloat(namatempat+"1", lat);
            PlayerPrefs.SetFloat(namatempat+"2", lot);
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        private void Start()
        {
            // Subscribe to events of the map 
            // OnlineMaps.instance.OnChangePosition += UpdateBubblePosition;
            // OnlineMaps.instance.OnChangeZoom += UpdateBubblePosition;
            OnlineMapsControlBase.instance.OnMapClick += OnMapClick;

            // if (datas != null)
            // {
            //     foreach (CData data in datas)
            //     {
            //         OnlineMapsMarker3D marker = OnlineMapsControlBase3D.instance.AddMarker3D(new Vector2((float)data.longitude, (float)data.latitude), Prefab);
            //         marker.customData = data;
            //         marker.OnClick += OnMarkerClick;
            //     }
            // }
            

            // Initial hide popup
            bubble.SetActive(false);
        }

        public Vector2 PopTargetOn()
        {
             Vector2 screenPosition = OnlineMapsControlBase.instance.GetScreenPosition(targetMarker.position);

            // // Add marker height
            screenPosition.y += targetMarker.height;

            // // Get a local position inside the canvas.
            Vector2 point;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, null, out point);

            // // Set local position of the popup
            // (bubble.transform as RectTransform).localPosition = point;
            return point;
        }

        /// <summary>
        /// Updates the popup position
        /// </summary>
        private void UpdateBubblePosition()
        {
            // If no marker is selected then exit.
            if (targetMarker == null) return;

            // Hide the popup if the marker is outside the map view
            if (!targetMarker.inMapView)
            {
                if (bubble.activeSelf) bubble.SetActive(false);
            }
            else if (!bubble.activeSelf) bubble.SetActive(true);
            
            

            // Convert the coordinates of the marker to the screen position.
            Vector2 screenPosition = OnlineMapsControlBase.instance.GetScreenPosition(targetMarker.position);

            // // Add marker height
            screenPosition.y += targetMarker.height;

            // // Get a local position inside the canvas.
            Vector2 point;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, null, out point);

            // // Set local position of the popup
            (bubble.transform as RectTransform).localPosition = point;
        }

        IEnumerator Cek(double nodeid, OnlineMapsMarkerBase label){
        float lat,lot;
        OMLS.GetLocation(out lot, out lat);
		string url = "http://139.59.100.192/PH/" + "cekpetaprize";
		WWWForm form = new WWWForm ();
		form.AddField ("ID", nodeid.ToString());
		form.AddField ("lat", lat.ToString());
		form.AddField ("lot", lot.ToString());
		form.AddField ("PID", PlayerPrefs.GetString ("ID"));
		WWW www = new WWW (url, form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			//int count = int.Parse (jsonString ["count"]);
			PlayerPrefs.SetString ("FOR_CONVERTING", jsonString ["code"]);
			if (PlayerPrefs.GetString ("FOR_CONVERTING") == "1") {				
                ShowPopUp(label, jsonString, nodeid.ToString());
				yield return new WaitForSeconds (.1f);
					
				// StartCoroutine (requesting ());				

			}
            else{
                print("failed");
            }
		}
	}

    private void ShowPopUp(OnlineMapsMarkerBase marker,JSONNode json, string nodeid)
    {
        string qnt = json ["data"]["quantity"];
         if(marker.label == "GoldMarker")
            {
                GameObject item = Instantiate(PricePrefab[0],new Vector3(0,0,0), Quaternion.identity);
                item.GetComponent<Text>().text = qnt;
                item.transform.parent = canvas.transform;
                (item.transform as RectTransform).localPosition = PopTargetOn();
                item.transform.DOScale(new Vector3(.7f,.7f,.7f),1).OnComplete(delegate(){
                Destroy(item);
                OnlineMaps.instance.RemoveMarker(marker as OnlineMapsMarker,true);
            });
                print ("CoinAnimation");
                print ("GetCoin");
            }
            else if(marker.label == "Roll")
            {
                 GameObject item = Instantiate(PricePrefab[3],new Vector3(0,0,0), Quaternion.identity);
                 item.GetComponent<Text>().text = qnt;
                item.transform.parent = canvas.transform;
                (item.transform as RectTransform).localPosition = PopTargetOn();
                item.transform.DOScale(new Vector3(.7f,.7f,.7f),1).OnComplete(delegate(){
                Destroy(item);});
                print ("RollAnimation");
                print ("GetRoll");
            }
            else if(marker.label == "CrystalMarker")
            {
                 GameObject item = Instantiate(PricePrefab[1],new Vector3(0,0,0), Quaternion.identity);
                 item.GetComponent<Text>().text = qnt;
                item.transform.parent = canvas.transform;
                (item.transform as RectTransform).localPosition = PopTargetOn();
                item.transform.DOScale(new Vector3(.7f,.7f,.7f),1).OnComplete(delegate(){
                Destroy(item);});
                print ("CrystalAnimation");
                print ("GetCrystal");
            }
            else if(marker.label == "Gem")
            {
                 GameObject item = Instantiate(PricePrefab[2],new Vector3(0,0,0), Quaternion.identity);
                 item.GetComponent<Text>().text = qnt;
                item.transform.parent = canvas.transform;
                (item.transform as RectTransform).localPosition = PopTargetOn();
                item.transform.DOScale(new Vector3(.7f,.7f,.7f),1).OnComplete(delegate(){
                Destroy(item);});
                print ("GemAnimation");
                print ("GetGem");
            }
             else if(marker.label == "Hantu")
            {  
                 string GhostMap1 = json ["data"]["hantu"]["Hantu1"]["name_file"];
                 string GhostMap2 = json ["data"]["hantu"]["Hantu2"]["name_file"];
                 string GhostMap3 = json ["data"]["hantu"]["Hantu3"]["name_file"];
                 print(GhostMap1);
                //  BattlePrefab.GetComponent<BattlePeta>().json = json;
                 BattlePrefab.GetComponent<BattlePeta>().Set(json);                 
                 BattlePrefab.GetComponent<BattlePeta>().NodeID = nodeid;                 
                 BattlePrefab.GetComponent<BattlePeta>().GhostImage[0].sprite = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap1);
                 BattlePrefab.GetComponent<BattlePeta>().GhostImage[1].sprite = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap2);
                 BattlePrefab.GetComponent<BattlePeta>().GhostImage[2].sprite = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap3);
                 
                 BattlePrefab.transform.DOLocalMoveY(-190, .5f);   
                print ("Hantu");
            }
            
            else
            {
            bubble.SetActive(true);
            bubble.transform.DOLocalMoveY(-265,.5f);
            }
    }

        [Serializable]
        public class CData
        {
            public string title;
            public string address;
            public string photo_url;
            public double longitude;
            public double latitude;
        }
    }
