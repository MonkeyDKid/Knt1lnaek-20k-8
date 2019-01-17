using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class EventGet : MonoBehaviour {
	public GameObject EventParent,EventParentPrefab, Eventinformation, EventInformationPrefab,Loading;
	// Use this for initialization
	void Start () {
		StartCoroutine (GetDataUser ());
	}

    private IEnumerator GetDataUser()
    {
        string url = Link.url + "GetQuest";
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
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "1")
            {

				var angka = int.Parse(jsonString["NewsCount"]);
				GameObject[] entry;
				GameObject[] entry2;
				entry = new GameObject[angka];
				entry2 = new GameObject[angka];
				for (int x = 0; x < angka; x++)
				{
					entry[x] = Instantiate(EventParentPrefab);
					entry2[x] = Instantiate(EventInformationPrefab);
					byte[] b64_bytes = System.Convert.FromBase64String(jsonString["data"][x]["ImageURL"]);
					Texture2D tex = new Texture2D(1, 1);
					tex.LoadImage(b64_bytes);

					var rect = new Rect(0, 0, tex.width, tex.height);

					if (tex.height != 8)
					{
						entry[x].GetComponent<eventParentitem>().Image.overrideSprite = Sprite.Create(tex, rect, Vector2.zero, 128.0f);
						entry2[x].GetComponent<eventInformationitem>().Image.overrideSprite = Sprite.Create(tex, rect, Vector2.zero, 128.0f);
					}
					entry2[x].GetComponent<eventInformationitem>().Title.text = jsonString["data"][x]["Title"];
					entry2[x].GetComponent<eventInformationitem>().Description.text = jsonString["data"][x]["Description"];
					entry [x].GetComponent<eventParentitem> ().EventInformationGO = entry2 [x];
					//entry [x].GetComponent<eventParentitem> ().EI = Eventinformation;
					entry[x].transform.SetParent(EventParent.transform, false);
					entry2[x].transform.SetParent(Eventinformation.transform, false);

				
				}

				Loading.SetActive(false);
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
               // validationerror.SetActive(true);
				Loading.SetActive(false);
            }
        }
        else {
          //  validationerror.SetActive(true);
			Loading.SetActive(false);
            Debug.Log("GAGAL");
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
