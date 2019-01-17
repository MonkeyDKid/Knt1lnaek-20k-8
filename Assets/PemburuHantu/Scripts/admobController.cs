using System;
using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
	using GoogleMobileAds.Api;
	using UnityEngine.SceneManagement;
	// Example script showing how to invoke the Google Mobile Ads Unity plugin.
	public class admobController : MonoBehaviour
	{
//		private BannerView bannerView;
//		private InterstitialAd interstitial;
//		private NativeExpressAdView nativeExpressAdView;
		private RewardBasedVideoAd rewardBasedVideo;
        public bool iklanaktif=false;
		public GameObject Iklan,berburu,PopUp,loading;
        public int iklanshowing1,iklanshowing2,iklanshowing3;
		private float deltaTime = 0.0f;
        public string PlayerID;
		private static string outputMessage = string.Empty;

		public static string OutputMessage
		{
			set { outputMessage = value; }
		}

		public void Start()
		{
        if (SceneManager.GetActiveScene().name == "Map")
        {
            iklanshowing1 = int.Parse(PlayerPrefs.GetString(Link.IENERGY));
            if (iklanshowing1 > 3)
            {

                iklanaktif = true;

            }
           

            }
        if (SceneManager.GetActiveScene().name == "berburuhantu")
        {
            iklanshowing2 = int.Parse(PlayerPrefs.GetString(Link.IBURU));
            if (iklanshowing2 > 2)
            {
				
                iklanaktif = true;

            }
          
            if (berburu.gameObject != null)
            {

            }

        }
        else {
			
            iklanshowing3 = int.Parse(PlayerPrefs.GetString(Link.IGOLD));
			
            if (iklanshowing3 > 2)
            {
                iklanaktif = true;
            }
          



        }
        PlayerID = PlayerPrefs.GetString(Link.ID);
        //  iklanshowing = PlayerPrefs.GetInt("iklanenergy");
		#if UNITY_ANDROID
        string appId = "ca-app-pub-5190655431355165~5675842014";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3940256099942544~1458002511";
		#else
		string appId = "unexpected_platform";
		#endif

			// Initialize the Google Mobile Ads SDK.
			MobileAds.Initialize(appId);

			// Get singleton reward based video ad reference.
			this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
    
      
            this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
       
			this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
			this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
			this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
			this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
			this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
			this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;
        if (SceneManager.GetActiveScene().name != "berburuhantu")
        {
            this.RequestRewardBasedVideo();
        }
      
			}

			public void Update()
			{
			// Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
			// value.
			this.deltaTime += (Time.deltaTime - this.deltaTime) * 0.1f;
        //	if (iklanshowing <= 3) {
        if (SceneManager.GetActiveScene().name == "berburuhantu")
        {
            if(rewardBasedVideo.IsLoaded() && iklanaktif == false)
            {
                this.rewardBasedVideo.Show();
                loading.SetActive(false);
                iklanaktif = true;
            }
                Iklan.SetActive(true);
           
        }
        else {
            if (rewardBasedVideo.IsLoaded() && iklanaktif == false)
            {
                Iklan.SetActive(true);
                iklanaktif = true;


            }
            else {
                //	Iklan.SetActive (false);
            }
        }
	//	}
			}
		public void showiklam(){
		//iklanshowing++;
        this.rewardBasedVideo.Show();
		//this.ShowRewardBasedVideo();
		}
//			

			// Returns an ad request with custom ad targeting.
			private AdRequest CreateAdRequest()
			{
			return new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)
			.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
			.AddKeyword("game")
			.SetGender(Gender.Male)
			.SetBirthday(new DateTime(1985, 1, 1))
			.TagForChildDirectedTreatment(false)
			.AddExtra("color_bg", "9B30FF")
			.Build();
			}

			
			public void RequestRewardBasedVideo()
			{
			#if UNITY_EDITOR
			string adUnitId = "unused";
#elif UNITY_ANDROID
			string adUnitId = "ca-app-pub-5190655431355165/8553356604";
#elif UNITY_IPHONE
			string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
			string adUnitId = "unexpected_platform";
#endif
        AdRequest requesting = new AdRequest.Builder().Build();

		this.rewardBasedVideo.LoadAd(CreateAdRequest(), adUnitId);
			}
    IEnumerator IklanChange()
    {

        WWWForm form = new WWWForm();
        //var expsingle = PlayerPrefs.GetInt ("MAPSEXP") * 3;
        //	Debug.Log (expsingle);
        string url = Link.url + "IklanChange";
        //WWWForm form = new WWWForm ();
        //formkirimreward.AddField ("JumlahXpTransfer", (expsingle));
        form.AddField("MY_ID", PlayerID);
        form.AddField("IBURU", iklanshowing2.ToString());
        form.AddField("IENERGY", iklanshowing1.ToString());
        form.AddField("IGOLD", iklanshowing3.ToString());

        //formkirimreward.AddField ("ITEM", equipmentreward[0]);
        WWW www = new WWW(url, form);
        yield return www;
        
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            if (int.Parse(jsonString["code"]) == 1)
            {
                PlayerPrefs.SetString(Link.IBURU, jsonString["data"]["iklan_buru"]);
            }
            if (int.Parse(jsonString["code"]) == 2)
            {
                PlayerPrefs.SetString(Link.IENERGY, jsonString["data"]["iklan_energy"]);
            }
            if (int.Parse(jsonString["code"]) == 3)
            {
                PlayerPrefs.SetString(Link.IGOLD, jsonString["data"]["iklan_gold"]);
            }
            yield return new WaitForSeconds(1);
            Iklan.SetActive(false);
            var jsonStringer = JSON.Parse(www.text);
           // PlayerPrefs.SetString("MaxE", jsonStringer["data"]["MaxEnergy"]);
           // monsterleveling();
            //berburuselesai

        }

        Debug.Log("sendreward");
        //	var jsonString = JSON.Parse (www.text);
        //PlayerPrefs.SetString ("BATU", jsonString ["data"]);



    }
    IEnumerator Reward()
    {

        WWWForm form = new WWWForm();
        //var expsingle = PlayerPrefs.GetInt ("MAPSEXP") * 3;
        //	Debug.Log (expsingle);
        string url = Link.url + "update_data_user";
        //WWWForm form = new WWWForm ();
        //formkirimreward.AddField ("JumlahXpTransfer", (expsingle));
        form.AddField("MY_ID", PlayerID);
        form.AddField("GOLD", 10);
        //formkirimreward.AddField ("ITEM", equipmentreward[0]);
        WWW www = new WWW(url, form);
        yield return www;

        if (www.error == null)
        {
            yield return new WaitForSeconds(1);
            Iklan.SetActive(false);
            var jsonStringer = JSON.Parse(www.text);
            PopUp.SetActive(true);
            // PlayerPrefs.SetString("MaxE", jsonStringer["data"]["MaxEnergy"]);
            // monsterleveling();
            //berburuselesai

        }

        Debug.Log("sendreward");
        //	var jsonString = JSON.Parse (www.text);
        //PlayerPrefs.SetString ("BATU", jsonString ["data"]);



    }

   
    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
			{
			MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
			}

			public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
			{
     
        MonoBehaviour.print(
			"HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
			}

			public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
			{
			MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
        Iklan.SetActive(false);
       // 
    }

			public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
			{
        Iklan.SetActive(false);
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
		StartCoroutine(IklanChange());
			}

			public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
			{
        Iklan.SetActive(false);
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
			}

			public void HandleRewardBasedVideoRewarded(object sender, Reward args)
			{
        Iklan.SetActive(false);
        Iklan.transform.Find("Text").GetComponent<Text>().text = "Dapet Reward";
        
       // StartCoroutine(IklanChange());
        if (SceneManager.GetActiveScene().name == "Map")
        {
          SceneManager.LoadScene("PilihCharacter");
        }
        if (SceneManager.GetActiveScene().name == "berburuhantu")
        {
            if (berburu.gameObject != null) {
                berburu.SetActive(false);
            }
           // SceneManager.LoadScene("berburuhantu");
            //  StartCoroutine(IklanChange());
        }
        else {
            StartCoroutine(Reward());

          //  StartCoroutine(IklanChange());

        }
			string type = args.Type;
			double amount = args.Amount;
			MonoBehaviour.print(
			"HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);
			}

			public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
			{
			MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
			}

    #endregion

   
}
