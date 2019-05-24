using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using DG.Tweening;

public class FilmSelector : MonoBehaviour {

public GameObject[] RollPrefab;
public Transform RollStartPosition;
public Text FilmSelectorText, CatchTimeText;
public Sprite[] Film_Selector;
public bool onclick;
public bool OnDown;
public berburu Hunting;
public OnLocation ChangeHantu;
private Text CommonRollText, RareRollText, LegendaryRollText;
public float CatchTime, MaxTime;
public GameObject FilmList,closefilm,GhostScanner, CommonRoll, RareRoll, LegendaryRoll, PopUpTimesUp, RollSelector;
public Image CatchBar;
public bool Catch=false;
	// Use this for initialization
	void Start () {
		
// PlayerPrefs.SetString("PLAY_TUTORIAL","FALSE") ;          
		 CatchBar.fillAmount=0;
		 GhostScanner.GetComponent<BoxCollider>().enabled=false;
		 var CR=CommonRoll.transform.Find("Text").GetComponent<Text>();
		 var RR=RareRoll.transform.Find("Text").GetComponent<Text>();
		 var LR=LegendaryRoll.transform.Find("Text").GetComponent<Text>();
		 CommonRollText = CR;
		 RareRollText = RR;
		 LegendaryRollText = LR;
		 CommonRollText.text = PlayerPrefs.GetString(Link.COMMON);
     RareRollText.text = PlayerPrefs.GetString(Link.RARE);
     LegendaryRollText.text = PlayerPrefs.GetString(Link.LEGENDARY);
		 if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE")
		 {
			 SceneManagerHelper.LoadTutorial("berburuhantu");
		 }
	}
	
	// Update is called once per frame
	void Update () {
		if(Catch)
		{
		  	if (PlayerPrefs.GetString("PLAY_TUTORIAL") == "TRUE")
      {

			}
			else
			{
				CatchTime -= Time.deltaTime;
			}	
		 
		 CatchBar.fillAmount = CatchTime / MaxTime;
         CatchTimeText.text = "Time Left: " + Mathf.Round(CatchTime);
		 RollSelector.GetComponent<Button>().interactable=false;
		    if(CatchTime < 0)
         	{
		     PopUpTimesUp.transform.Find("Text").GetComponent<Text>().text = "Time is up \n your roll burned.";
			 PopUpTimesUp.SetActive(true);
			 Catch=false;
			 Hunting.angka=0;
			 CatchTimeText.text="Choose Roll";
         	}
		}
		else
		{	
			Catch=false;
			Hunting.angka=0;
			RollSelector.GetComponent<Button>().interactable=true;
			CatchTimeText.text="Choose Roll";
			GhostScanner.GetComponent<BoxCollider>().enabled=false;
			CatchBar.fillAmount=0;
		}
		
	}

	// public void angkadummy()
	// {
	// 	Hunting.angka = 6;
	// }
	public void Select(){
		//  GetComponent<Animator>().SetTrigger("Selected");
		Switch();
	}
	public void Deselect(){
		// GetComponent<Animator>().SetTrigger("Deselect");
		Switch();
	}

	public void AnimateRoll(int whichroll)
	{
			if (PlayerPrefs.GetString("PLAY_TUTORIAL") == "TRUE")            
		{
			GameObject[] roll = new GameObject[3];
			for(int i=0; i<3;i++)
			{
					roll[i] = Instantiate(RollPrefab[i],RollStartPosition.position, Quaternion.identity);
					roll[i].transform.parent = RollStartPosition;
					roll[i].transform.DOLocalRotate(new Vector3(0,0,0),.1f);
					roll[i].transform.localScale = new Vector3(0,0,0);			
			}
		
		
			roll[0].transform.DOLocalJump(new Vector3(450,25,0),120,1,.5f);
			roll[0].transform.DOScale(new Vector3(1,1,1),.5f).OnComplete(delegate(){
				Destroy(roll[0]);
				roll[1].transform.DOLocalJump(new Vector3(450,25,0),120,1,.5f);
			roll[1].transform.DOScale(new Vector3(1,1,1),.5f).OnComplete(delegate(){
				Destroy(roll[1]);
					roll[2].transform.DOLocalJump(new Vector3(450,25,0),120,1,.5f);
			roll[2].transform.DOScale(new Vector3(1,1,1),.5f).OnComplete(delegate(){
				Destroy(roll[2]);

			});
				});
					});

		}
		else
		{		
			GameObject roll = Instantiate(RollPrefab[whichroll],RollStartPosition.position, Quaternion.identity);
			roll.transform.parent = RollStartPosition;
			roll.transform.localScale = new Vector3(0,0,0);			
			roll.transform.DOLocalJump(new Vector3(450,25,0),120,1,.5f);
			roll.transform.DOScale(new Vector3(1,1,1),.5f).OnComplete(delegate(){
				Destroy(roll);
			});
		}
	}

		public void Switch()
	{			
		if(onclick==false)
		{
			onclick=true;
			OnDown = !OnDown;
			if(OnDown)
			{
				closefilm.SetActive(true);
				FilmList.transform.DOLocalMoveY(0f,.5f).OnComplete(delegate(){
					onclick=false;
				});
				// GetComponent<Animator>().ResetTrigger("Selected");
				// GetComponent<Animator>().ResetTrigger("Deselect");
				// GetComponent<Animator>().SetTrigger("Selected");
			}
			else
			{
					FilmList.transform.DOLocalMoveY(-250f,.5f).OnComplete(delegate(){
						closefilm.SetActive(false);
						onclick=false;
					});
				// GetComponent<Animator>().ResetTrigger("Selected");
				// GetComponent<Animator>().ResetTrigger("Deselect");
				// GetComponent<Animator>().SetTrigger("Deselect");
			}
		}
		
	}
	public void Roller(int whichScanner)
	{
		// ChangeHantu.Start();
		 if(whichScanner==0)
		 {
			 	ChangeHantu.Start();
			 	if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.COMMON)) >= 1) 
				{
					CatchTime = MaxTime = 15;
					Catch=true;
					CatchBar.fillAmount=1;
					CatchTimeText.text = CatchTime.ToString();
					Hunting.TimeShiftIncrease = 1;
					RollSelector.GetComponent<Button>().image.sprite = Film_Selector[whichScanner];
			 		GhostScanner.GetComponent<BoxCollider>().enabled=true;
					
				} 
				else 
				{
					//statusAktif.SetActive (true);
				}
			Deselect();
			
		 }
		 else if(whichScanner==1)
		 {
			 	ChangeHantu.Start();
			 	if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.RARE)) >= 1) 
				{
					CatchTime = MaxTime = 20;
					Catch=true;
					CatchBar.fillAmount=1;
					CatchTimeText.text= CatchTime.ToString();
					Hunting.TimeShiftIncrease = 1.5f;
					RollSelector.GetComponent<Button>().image.sprite = Film_Selector[whichScanner];
					GhostScanner.GetComponent<BoxCollider>().enabled=true;
				} 
				else 
				{
					//statusAktif.SetActive (true);
				}
			 Deselect();
		 }
		  else if(whichScanner==2)
		 {
			 	ChangeHantu.Start();
			 	if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.LEGENDARY)) >= 1) 
				{
					CatchTime = MaxTime = 30;
					Catch=true;
					CatchBar.fillAmount=1;
					CatchTimeText.text= CatchTime.ToString();
					Hunting.TimeShiftIncrease = 2f;
					RollSelector.GetComponent<Button>().image.sprite = Film_Selector[whichScanner];
					GhostScanner.GetComponent<BoxCollider>().enabled=true;
				} 
				else 
				{
					//statusAktif.SetActive (true);
				}
			 Deselect();
		 }
		 else if (whichScanner==3)
		 {
			 	if (PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE") 
				{
					ChangeHantu.Start();
					CatchTime = MaxTime = 30;
					Catch=true;
					CatchBar.fillAmount=1;
					CatchTimeText.text= CatchTime.ToString();
					Hunting.TimeShiftIncrease = 1;
				//	RollSelector.GetComponent<Button>().image.sprite = Film_Selector[whichScanner];
					GhostScanner.GetComponent<BoxCollider>().enabled=true;
				} 
				else 
				{
					//statusAktif.SetActive (true);
				}
				Deselect();
		 }

				else 
		 {
			 if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE")
			 {
				 print("Masuk sini");
					ChangeHantu.Start();
					CatchTime = MaxTime = 30;
					Catch=true;
					CatchBar.fillAmount=1;
					CatchTimeText.text= CatchTime.ToString();
					Hunting.TimeShiftIncrease = 2;
					GhostScanner.GetComponent<BoxCollider>().enabled=true;	
			 }		
			 
		 }
		 
		 PlayerPrefs.SetInt("Rarity",whichScanner);
		 
	}
	 public void Scanner(int whichScanner)
	 {
		 StartCoroutine(UseRoll(whichScanner));		
	 }

	 private IEnumerator sendSummon(string file, int jenis,GameObject model)
	{
		string url = Link.url + "send_summon";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("FILE", file);
		form.AddField ("JENIS", jenis);

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
            PlayerPrefs.SetString("SummonStats", "Summoned");
			//testsummonings
			model.SetActive(true);
			model.GetComponent<Animation> ().PlayQueued ("select", QueueMode.PlayNow);
			model.GetComponent<Animation> ().PlayQueued ("idle");
		//	p.Play ();
		//	StartCoroutine(Waitforsec());
			var jsonString = JSON.Parse (www.text);
			Debug.Log(jsonString ["data"] ["id"] );
		//	StartCoroutine(sendEXP(jsonString ["data"] ["id"] ,0));
			Debug.Log (www.text);
			file = file.Replace ("_Fire", "");
			file = file.Replace ("_Water", "");
			file = file.Replace ("_Wind", "");
			file = file.Replace ("_fire", "");
			file = file.Replace ("_water", "");
			file = file.Replace ("_wind", "");
			Debug.Log (file);
			if (file == "Kunti ") {
				file = "Kuntilanak";
			}
			if (file == "Babingepet ") {
				file = "Babi Ngepet";
			}
			if (file == "Hantutanpakepala ") {
				file = "Hantu tanpa kepala";
			}
			if (file == "SusterNgesot ") {
				file = "Suster Ngesot";
			}
			if (file == "nagabesukih ") {
				file = "Naga Besukih";
			}
			if (file == "Nyiroro ") {
				file = "Ratu Pantai";
			}
			if (file == "SundelBolong") {
				file = "Sundel Bolong";
			}
			if (file == "Kolorijo ") {
				file = "Kolor Ijo";
			}
		//	info.text = file;

	//		StartCoroutine (updateData (jenis));

           // yield return new WaitForSeconds(.5f);
        //   Summonings.GetComponent<Button> ().enabled = true;

        } else {
		//failed
		}

	}

	 private IEnumerator UseRoll(int whicRoll)
	{
		string url = Link.url + "UseRoll";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("RARITY", whicRoll);
	
		WWW www = new WWW(url,form);
		yield return www;
	
		if (www.error == null) 
		{
        	var jsonString = JSON.Parse (www.text);
			if(int.Parse(jsonString["code"])==1)
			{
				Roller(whicRoll);
				updateData(www.text);
			}
			else
			{
				//failed
			}
			

        } 

		else 
		{
		//failed
		}
		Debug.Log(www.text);
	}


	private void updateData(string update)
	{
            var jsonString = JSON.Parse(update);
            Debug.Log(jsonString);
            PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "1")
            {

                PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
                PlayerPrefs.SetString(Link.GOLD, jsonString["data"]["coin"]);
                PlayerPrefs.SetString("Crystal", jsonString["data"]["crystal"]);
                PlayerPrefs.SetString(Link.COMMON, jsonString["data"]["common"]);
                PlayerPrefs.SetString(Link.RARE, jsonString["data"]["rare"]);
                PlayerPrefs.SetString(Link.LEGENDARY, jsonString["data"]["legendary"]);


               // Gold.text = PlayerPrefs.GetString(Link.GOLD);
                 CommonRollText.text = jsonString["data"]["common"];
        		 RareRollText.text = jsonString["data"]["rare"];
         		 LegendaryRollText.text = jsonString["data"]["legendary"];         
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
              //  validationerror.SetActive(true);
            }
	}

	public void OnClickAfter (int jenis) {
		if(jenis==0)
		{
			if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.COMMON)) >= 1) 
			{
				CommonRoll.GetComponent<Button>().interactable=true;
			} 
			else 
			{
				CommonRoll.GetComponent<Button>().interactable=false;
			}
		}
		else if(jenis==1)
		{
			if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.RARE)) >= 1) 
			{
				RareRoll.GetComponent<Button>().interactable=true;
			} 
			else 
			{
				RareRoll.GetComponent<Button>().interactable=false;
			}

		}
		else
		{
			if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.LEGENDARY)) >= 1) 
			{
				LegendaryRoll.GetComponent<Button>().interactable=true;
			} 
			else 
			{
				LegendaryRoll.GetComponent<Button>().interactable=false;
			}

		}
	
	}
}
