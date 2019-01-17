using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

	private bool isInfromasiServerPlay = false;

	[Header("Diperlukan Untuk Login")]
	public string device_id = "";
	public InputField email;
	public InputField password;

	[Header("Lainnya")]
	public GameObject informasiServer;

	void Start () {
		#if !UNITY_EDITOR
		AndroidJavaClass up = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject> ("currentActivity");
		AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject> ("getContentResolver");  
		AndroidJavaClass secure = new AndroidJavaClass ("android.provider.Settings$Secure");
		device_id = secure.CallStatic<string> ("getString", contentResolver, "android_id");
		#endif

		#if UNITY_EDITOR
		device_id = "200";
		#endif
	}


	public IEnumerator  AnimasiInformasiServer (string info) {
		isInfromasiServerPlay = true;
		informasiServer.SetActive (true);
		informasiServer.GetComponentInChildren<Text> ().text = info;
		informasiServer.GetComponent<Animator> ().Play ("informasiServer");
		yield return new WaitForSeconds (2);
		informasiServer.SetActive (false);
		isInfromasiServerPlay = false;
		informasiServer.GetComponentInChildren<Text> ().text = "";
		StopCoroutine (AnimasiInformasiServer(""));


		if (info == "Register Complete") {
			SceneManagerHelper.LoadScene ("Home");
		}
	}



}
