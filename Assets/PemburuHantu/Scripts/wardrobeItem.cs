using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class wardrobeItem : MonoBehaviour {

public string Url, IconCode, ID;
public Image WardrobeImage; 
public Texture JosieCustume;
public int PurchaseAble, Bought;
public string textEncode;
public GameObject Sell;
public Button SelectButton;
public SkinnedMeshRenderer JosieSkinMesh;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(JosieIcon(IconCode));
		SelectButton.onClick.AddListener(LoadTexture);
	}

	private IEnumerator JosieIcon(string Url)
	{
		string path = Application.persistentDataPath + "/Josie/Icon/";
		if (File.Exists(path + ID + ".png"))
		{
			print("cached");
			byte[] byteArray = File.ReadAllBytes(path + ID + ".png");
			Texture2D texture = new Texture2D(1,1);
			texture.LoadImage(byteArray);
			texture.filterMode = FilterMode.Point;
			var rect = new Rect (0, 0, texture.width, texture.height);
			WardrobeImage.overrideSprite = Sprite.Create (texture, rect, Vector2.zero, 128.0f);
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
				WardrobeImage.overrideSprite = Sprite.Create (loadedtexture, rect, Vector2.zero, 128.0f);
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
			} 
			else {
			Debug.Log ("Faill");
			}
    //    popup.SetActive(false);
    }
	}

public void LoadTexture()
{	
	JosieSkinMesh.gameObject.GetComponent<vanny>().choosen = int.Parse(ID);
	StartCoroutine(JosieLoadTextureKey(Url));
}

private IEnumerator JosieLoadTextureKey(string URL)
	{
		//string ID = PlayerPrefs.GetInt ("Skin").ToString();
		//string Url = "http://139.59.100.192/PH/storage/Image/Josie/Texture/"+ID+".png";
		//string path = Application.persistentDataPath + "/Josie/Texture/";
		if (SceneManagerHelper.HasKey("Texture"+ID))
		{
			print("cached");
			byte[] byteArray = System.Convert.FromBase64String(PlayerPrefs.GetString("Texture"+ID));
			Texture2D texture = new Texture2D(1,1);
			texture.LoadImage(byteArray);
			texture.filterMode = FilterMode.Point;
			JosieSkinMesh.material.mainTexture = texture;
		}
		else
		{
		WWWForm form = new WWWForm();
		WWW www = new WWW (URL);

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
				JosieSkinMesh.material.mainTexture = loadedtexture;
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
private IEnumerator JosieLoadTexture(string Url)
	{
		string path = Application.persistentDataPath + "/Josie/Texture/";
		if (File.Exists(path + ID + ".png"))
		{
			print("cached");
			byte[] byteArray = File.ReadAllBytes(path + ID + ".png");
			Texture2D texture = new Texture2D(1,1);
			texture.LoadImage(byteArray);
			texture.filterMode = FilterMode.Point;
			JosieCustume = texture;
			JosieSkinMesh.material.mainTexture = texture;
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
				JosieCustume = loadedtexture;
				JosieSkinMesh.material.mainTexture = loadedtexture;
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

	
	// Update is called once per frame
	void Update () 
	{
		
	}
	private void WannaBuyCostume()
	{
		//buy Costume
		if(PurchaseAble==1)
		{

		}
		else
		{
			StartCoroutine(JosieLoadTexture(this.Url));
		}
	}
	private IEnumerator LoadJosieIcon(string URL)
	{
		WWWForm form = new WWWForm();
		WWW www = new WWW (URL);

		yield return www;

		if (www.error == null) 
		{
			Debug.Log (URL);
			string s = System.Convert.ToBase64String(www.texture.EncodeToPNG());
			byte[] b64_bytes = System.Convert.FromBase64String (s);
			Texture2D tex = new Texture2D (2, 2);
			tex.filterMode = FilterMode.Point;
			tex.LoadImage (b64_bytes);
			
			var rect = new Rect (0, 0, tex.width, tex.height);
			
			if (tex.height != 8) 
			{
				WardrobeImage.overrideSprite = Sprite.Create (tex, rect, Vector2.zero, 256.0f);
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
	
}
