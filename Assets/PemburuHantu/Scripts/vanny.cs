using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
using System.IO;
public class vanny : MonoBehaviour {
	//public Texture[] TxrSkin;
	public GameObject[] Mesh;
	//public GameObject WardrobePrefab;
	public int choosen;
	private SkinnedMeshRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<SkinnedMeshRenderer> ();
		if(SceneManagerHelper.HasKey("Skin"))
		{
			StartCoroutine(JosieLoadTextureKey());
		}
		else
		{
			//renderer.material.mainTexture = TxrSkin [0];
		}
		
		if (Application.loadedLevelName == "wardrobe") 
		{
			StartCoroutine (idling ());
			//StartCoroutine(LoadTextures());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName=="wardrobe"){
			if (GetComponent<Animation> ().isPlaying == false) {
				StartCoroutine (idling ());
			}
		}
	}
	
	private IEnumerator JosieLoadTexture()
	{
		string ID = PlayerPrefs.GetInt ("Skin").ToString();
		string Url = "http://139.59.100.192/PH/storage/Image/Josie/Texture/"+ID+".png";
		string path = Application.persistentDataPath + "/Josie/Texture/";
		if (File.Exists(path + ID + ".png"))
		{
			print("cached");
			byte[] byteArray = File.ReadAllBytes(path + ID + ".png");
			Texture2D texture = new Texture2D(1,1);
			texture.LoadImage(byteArray);
			texture.filterMode = FilterMode.Point;
			renderer.material.mainTexture = texture;
		}
		else
		{
		WWWForm form = new WWWForm();
		WWW www = new WWW (Url);

		yield return www;

		if (www.error == null) 
		{
			

			Debug.Log (Url);
			var rect = new Rect (0, 0, www.texture.width, www.texture.height);

			if (www.texture.height != 8) 
			{
				Debug.Log (www.texture.height);
				Texture2D loadedtexture = www.texture;
				loadedtexture.filterMode = FilterMode.Point;
				renderer.material.mainTexture = loadedtexture;
				byte[] bytes = loadedtexture.EncodeToPNG();
				
				if(File.Exists(path))
				{
					File.WriteAllBytes(path + ID+".png",bytes);
				}
				else
				{
					Directory.CreateDirectory(path);
					File.WriteAllBytes(path + ID+".png",bytes);
				}
				
            } 
			else 
			{
				//anotherpopup.SetActive (true);
			}

			Debug.Log ("Succes");
		} else {
			Debug.Log ("Faill");
		}
		}
    //    popup.SetActive(false);
    }

	private IEnumerator JosieLoadTextureKey()
	{
		string ID = PlayerPrefs.GetInt ("Skin").ToString();
		string Url = "http://139.59.100.192/PH/storage/Image/Josie/Texture/"+ID+".png";
		//string path = Application.persistentDataPath + "/Josie/Texture/";
		if (SceneManagerHelper.HasKey("Texture"+ID))
		{
			print("cached");
			byte[] byteArray = System.Convert.FromBase64String(PlayerPrefs.GetString("Texture"+ID));
			Texture2D texture = new Texture2D(1,1);
			texture.LoadImage(byteArray);
			texture.filterMode = FilterMode.Point;
			renderer.material.mainTexture = texture;
		}
		else
		{
		WWWForm form = new WWWForm();
		WWW www = new WWW (Url);

		yield return www;

		if (www.error == null) 
		{
			

			Debug.Log (Url);
			var rect = new Rect (0, 0, www.texture.width, www.texture.height);

			if (www.texture.height != 8) 
			{
				Debug.Log (www.texture.height);
				Texture2D loadedtexture = www.texture;
				loadedtexture.filterMode = FilterMode.Point;
				renderer.material.mainTexture = loadedtexture;
				byte[] bytes = loadedtexture.EncodeToPNG();
				string a = Convert.ToBase64String(bytes);
				SceneManagerHelper.SaveKey("Texture",ID, a);
				
				
				
            } 
			else 
			{
				//anotherpopup.SetActive (true);
			}

			Debug.Log ("Succes");
		} else {
			Debug.Log ("Faill");
		}
		}
    //    popup.SetActive(false);
    }

	public void applycustom(){
		PlayerPrefs.SetInt ("Skin", choosen);
		//GetComponent<SkinnedMeshRenderer> ().material.mainTexture = TxrSkin [choosen];

	}
	
	IEnumerator idling(){
		GetComponent<Animation> ().PlayQueued ("idle", QueueMode.PlayNow);
		GetComponent<Animation> ().PlayQueued ("idle", QueueMode.PlayNow);
		GetComponent<Animation> ().PlayQueued ("liat", QueueMode.CompleteOthers);
		yield return null;
	}
}
