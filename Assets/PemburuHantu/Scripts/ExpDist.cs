using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class ExpDist : MonoBehaviour {


	public Text BankXpHeader;
    public GameObject validationerror;

	void Start () {
		StartCoroutine (updateData());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private IEnumerator updateData()
	{
        //string url = Link.url + "login";
        //WWWForm form = new WWWForm ();
        //form.AddField (Link.DEVICE_ID, PlayerPrefs.GetString (Link.DEVICE_ID));
        //form.AddField (Link.EMAIL, PlayerPrefs.GetString (Link.EMAIL));
        //form.AddField (Link.PASSWORD, PlayerPrefs.GetString (Link.PASSWORD));
        //WWW www = new WWW (url, form);
        //yield return www;
        //if (www.error == null) {
        //	Debug.Log ("UPDATE SUCCESS");
        //	var jsonString = JSON.Parse (www.text);

        string url = Link.url + "getDataUser";
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
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "0")
            {
                BankXpHeader.text = jsonString["data"]["xpm"];
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                //validationerror.SetActive(true);
            }

        } 
	
	}

}
