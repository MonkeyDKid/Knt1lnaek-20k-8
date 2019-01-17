using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

	public class MoveToClickPoint : MonoBehaviour {
		NavMeshAgent agent;
	public GameObject Kara,kursiGO,Envi,shop,soundbg, buttonObject;
	public AudioClip clip;
	public float cf;
	bool tass = false;
	bool mejas = false;
	bool kursis = false;
	bool kasurs = false;
	bool lemaris = false;
	bool lemariatass = false;
	bool lacis=false;
	public bool dkasur=false;
	public bool dkursi=false;
	public bool idleng=true;
	bool kasur1=false;
	bool kursi1=false;
	bool lemari1=false;
	bool lemariatas1 = false;
	bool laci1=false;
	bool tas1=false;
	bool click=false;
	bool loop_kursi=false;
	bool loop_kasur=false;
	public float timer=0;
	public float speedrotate=1;
	public float x,y,z,xlama,zlama;
	public	Transform gg,gg2;
			void Start() {

			agent = GetComponent<NavMeshAgent>();
		//Envi.GetComponent<Animation> ().wrapMode = WrapMode.Loop;
		//Envi.GetComponent<Animation> ().Play ();

		//agent.updateRotation = false;
		StartCoroutine( idling ());
	//	agent.destination = new Vector3 (.2f, -2.3f, 1.8f);
		}

		void Update() {
		

//		if (agent.isStopped) {
//			Kara.GetComponent<Animation> ().Play ("idle");
//		} 

//		else {

			
//		}
	
		if (tass == true && agent.remainingDistance == 0) {
			agent.transform.position=new Vector3(0,-0.6756654f,-1);
			agent.destination=new Vector3(0,-0.6756654f,-1);
			agent.updatePosition = false;
			agent.updateRotation = false;
			transform.position = new Vector3 (0, -0.6756662f, 0.53f);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			Kara.transform.localPosition = new Vector3 (0, -4.65f, 0);
			Kara.transform.localRotation = Quaternion.Euler (0, 180f, 0);
			Kara.GetComponent<Animation> ().PlayQueued ("shoptas", QueueMode.PlayNow);
			Envi.GetComponent<Animation> ().PlayQueued ("shoptas", QueueMode.PlayNow);
			StartCoroutine (tungguplay ());
		//	kursiGO.SetActive (false);
			tass = false;

		
		}
	
		if (mejas == true && agent.remainingDistance == 0) {
			agent.updatePosition = false;
			agent.updateRotation = false;
			transform.position = new Vector3 (0, -0.6756662f, 0.53f);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			Kara.transform.localPosition = new Vector3 (0, -4.65f, 0);
			Kara.transform.localRotation = Quaternion.Euler (0, 180f, 0);
		//	Kara.GetComponent<Animation> ().PlayQueued ("KM", QueueMode.PlayNow);
//			Kara.GetComponent<Animation> ().PlayQueued ("DML", QueueMode.CompleteOthers);
			mejas = false;
			agent.enabled = true;
		}
	
		if (kasurs == true && agent.remainingDistance == 0) {
			
			agent.updatePosition = false;
			agent.updateRotation = false;
			xlama = transform.position.x;
			zlama = transform.position.z;
			transform.position = new Vector3 (0, -0.6756662f, 0.53f);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			Kara.transform.localPosition = new Vector3 (0, -4.65f, 0);
			Kara.transform.localRotation = Quaternion.Euler (0, 180f, 0);
			Kara.GetComponent<Animation> ().PlayQueued ("BT",QueueMode.PlayNow);
			Envi.GetComponent<Animation> ().PlayQueued ("BT",QueueMode.PlayNow);
			Kara.GetComponent<Animation> ().PlayQueued ("TL", QueueMode.CompleteOthers);
			Envi.GetComponent<Animation> ().PlayQueued ("TL", QueueMode.CompleteOthers);
			kasurs = false;
			agent.enabled = true;
			dkasur = true;
			dkursi = false;
		}

		if (lemaris == true && agent.remainingDistance == 0) {
			agent.updatePosition = false;
			agent.updateRotation = false;
		
			transform.position = new Vector3 (0, -0.6756662f, 0.53f);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			Kara.transform.localPosition = new Vector3 (0, -4.65f, 0);
			Kara.transform.localRotation = Quaternion.Euler (0, 180f, 0);
			Kara.GetComponent<Animation> ().PlayQueued ("gantibaju", QueueMode.PlayNow);
			Envi.GetComponent<Animation> ().PlayQueued ("gantibaju", QueueMode.PlayNow);
			lemaris = false;
			agent.enabled = true;
			StartCoroutine (tunggustage ("wardrobe",1.5f));
		}
		if (lemariatass == true && agent.remainingDistance == 0) {
			agent.updatePosition = false;
			agent.updateRotation = false;

			transform.position = new Vector3 (0, -0.6756662f, 0.53f);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			Kara.transform.localPosition = new Vector3 (0, -4.65f, 0);
			Kara.transform.localRotation = Quaternion.Euler (0, 180f, 0);
			Kara.GetComponent<Animation> ().PlayQueued ("training", QueueMode.PlayNow);
			Envi.GetComponent<Animation> ().PlayQueued ("training", QueueMode.PlayNow);
			lemariatass = false;
			agent.enabled = true;
			StartCoroutine (tunggustage ("Practice",1.5f));
		}

		if (lacis == true && agent.remainingDistance == 0) {
			agent.updatePosition = false;
			agent.updateRotation = false;

			transform.position = new Vector3 (0, -0.6756662f, 0.53f);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			Kara.transform.localPosition = new Vector3 (0, -4.65f, 0);
			Kara.transform.localRotation = Quaternion.Euler (0, 180f, 0);
			Kara.GetComponent<Animation> ().PlayQueued ("storagelaci", QueueMode.PlayNow);
			Envi.GetComponent<Animation> ().PlayQueued ("storagelaci", QueueMode.PlayNow);
			lacis = false;
			agent.enabled = true;
			StartCoroutine (tunggustage ("Storage",.7f));
		}
		else 
		{
			//Debug.Log ("ayam");
		}
		if (kursis == true && agent.remainingDistance == 0) {
			agent.updatePosition = false;
			agent.updateRotation = false;
			xlama = transform.position.x;
			zlama = transform.position.z;
			transform.position = new Vector3 (0, -0.6756662f, 0.53f);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			Kara.transform.localPosition = new Vector3 (0, -4.65f, 0);
			Kara.transform.localRotation = Quaternion.Euler (0, 180f, 0);
			//Kara.GetComponent<Animation> ().CrossFade ("BD", cf);
			Kara.GetComponent<Animation> ().PlayQueued ("BD", QueueMode.PlayNow);
			Envi.GetComponent<Animation> ().PlayQueued ("BD", QueueMode.PlayNow);
			Kara.GetComponent<Animation> ().PlayQueued ("DL", QueueMode.CompleteOthers);
			Envi.GetComponent<Animation> ().PlayQueued ("DL", QueueMode.CompleteOthers);


			kursis = false;
			agent.enabled = true;
			dkursi = true;
			dkasur = false;
		} else {
		//	Debug.Log ("ayam");
		}
//		if (click == true && agent.remainingDistance == 0) {
//			Kara.GetComponent<Animation> ().PlayQueued ("idle", QueueMode.PlayNow);
//			Kara.GetComponent<Animation> ().PlayQueued ("idle", QueueMode.CompleteOthers);
//			Kara.GetComponent<Animation> ().PlayQueued ("liat", QueueMode.CompleteOthers);
//			if (Kara.GetComponent<Animation> ().isPlaying == false) {
//				
//			}
//		}
		if (kasur1) {
			kasurs = true;
			kursis = false;
			if (dkursi||dkursi) {
				StartCoroutine (perpindahan ());
			} else {
				agent.updatePosition = true;
				agent.updateRotation = true;
				//transform.position = new Vector3 (xlama, transform.position.y, zlama);
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (-1	, -2.3f, 1.2f);
			}
			kasur1 = false;
		}
		if (kursi1) {
			kasurs = false;
			kursis = true;
			if (dkasur||dkursi) {
						StartCoroutine (perpindahan ());
					} else {
				agent.updatePosition = true;
				agent.updateRotation = true;
						Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
						Kara.GetComponent<Animation> ().Play ("jalan");
						agent.destination = new Vector3 (0.6f, -2.3f, .7f);
					}
			kursi1 = false;
		}
		if (lemari1) {
			lemaris = true;
			if (dkasur||dkursi) {
				StartCoroutine (perpindahan ());
			} else {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (.45f, -2.3f, 1.3f);
			}
			lemari1 = false;
		}
		if (lemariatas1) {
			lemariatass = true;
			if (dkasur||dkursi) {
				StartCoroutine (perpindahan ());
			} else {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (0f, -2.3f, 1.3f);
			}
			lemariatas1 = false;
		}
		if (laci1) {
			lacis = true;
			if (dkasur || dkursi) {
				StartCoroutine (perpindahan ());
			} 
			else {
				

				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (-1f, -2.3f, 1.2f);

			}
			laci1 = false;
		}
		if (tas1) {
			tass = true;
			if (dkasur || dkursi) {
				StartCoroutine (perpindahan ());
			} else {

				transform.localRotation = Quaternion.Euler (0, -120, 0);
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (-1.5f, -2.3f, -1.5f);

			}
			tas1 = false;
		}
		if (idleng == true  ) {
//			//StartCoroutine(tengah ());
//			//agent.enabled = false;
		
//
			//idleng=true;


			if (timer == 0) 
			{
			StartCoroutine (idling ());
			}
			timer-=Time.deltaTime;
//			//agent.enabled = true;
		}
		if (Kara.GetComponent<Animation> ().isPlaying == false && dkasur == false &&  dkursi == false) {
			timer = 0;
		}
//		if (Input.GetKey (KeyCode.Return)) {
//			timer = 20;
////			timer -= Time.deltaTime;
//			tass = true;
//			if (dkursi) {
//				StartCoroutine (perpindahan ());
//			} else {
//				//agent.enabled = true;
//				//transform.position = new Vector3 (xlama, transform.position.y, zlama);
//
//				transform.localRotation = Quaternion.Euler (0, -120, 0);
//				agent.updatePosition = true;
//				agent.updateRotation = true;
//				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
//				Kara.GetComponent<Animation> ().Play ("jalan");
//				agent.destination = new Vector3 (x, y, z);
//			}
//
//		}
//		if (Input.GetKey (KeyCode.UpArrow)) {
//			Kara.GetComponent<Animation> ().Play ();
//		}
//		if (Input.GetMouseButtonDown (0)&& click==false) {
//			agent.updatePosition = true;
//			agent.updateRotation = true;
//			RaycastHit hit;
//			Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
//			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) {
//				agent.destination = hit.point;
//				Kara.GetComponent<Animation> ().Play ("jalan");
//
//				Debug.Log (hit.point);
//				click = true;
//			}
//		} 

//		if (Input.GetKey (KeyCode.Space)) {
//			
////			if (dkasur = true) {
////				
////			} 
////			else {
////				
////			}
//			kursis = true;
//			if (dkasur) {
//				StartCoroutine (perpindahan ());
//			} else {
//				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
//				Kara.GetComponent<Animation> ().Play ("jalan");
//			 	agent.destination = new Vector3 (0.6f, -2.3f, .7f);
//			}
//		}
		if (Kara.GetComponent<Animation> ().IsPlaying ("TL") == true||Kara.GetComponent<Animation> ().IsPlaying ("DL") == true) {
			//			if (Kara.GetComponent<Animation> ().Sample()) {
			buttonObject.SetActive(true);
			//
			//			}
		}
	}
	IEnumerator perpindahan(){
		if (dkasur == true) {
			agent.enabled = false;
			Kara.GetComponent<Animation> ().PlayQueued ("TB", QueueMode.PlayNow);
			Envi.GetComponent<Animation> ().PlayQueued ("TB", QueueMode.PlayNow);
			yield return new WaitForSeconds (4.5f);


			if (kursis==true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (-1.8f, transform.position.y, 1.3f);
				transform.rotation =  Quaternion.Euler (0, 90, 0);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (0.6f, -2.3f, .7f);

			}
			if (lemaris == true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (-1.8f, transform.position.y, 1.3f);
				transform.rotation =  Quaternion.Euler (0, 90, 0);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (.2f, -2.3f, 1.27f);
			}
			if (lemariatass == true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (-1.8f, transform.position.y, 1.3f);
				transform.rotation =  Quaternion.Euler (0, 90, 0);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (.2f, -2.3f, 1.27f);
			}
			if (lacis == true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (-1.8f, transform.position.y, 1.3f);
				transform.rotation =  Quaternion.Euler (0, 90, 0);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (-.9f, -2.3f, 1.2f);
			}
			if (tass == true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (-1.8f, transform.position.y, 1.3f);
				transform.rotation =  Quaternion.Euler (0, 90, 0);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (-2.25f, -2.3f, -1.76f);
			}
			dkasur = false;
		}
		if(dkursi==true){
			agent.enabled = false;
			Kara.GetComponent<Animation> ().PlayQueued ("DB", QueueMode.PlayNow);
			Envi.GetComponent<Animation> ().PlayQueued ("DB", QueueMode.PlayNow);
			yield return new WaitForSeconds (4f);


			if (kasurs==true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (2, transform.position.y,1.2f);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (-1f, -2.3f, 1.2f);
			}
			if (lemaris == true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (2, transform.position.y,1.2f);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (.2f, -2.3f, 1.27f);
			}
			if (lemariatass == true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (2, transform.position.y,1.2f);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (.2f, -2.3f, 1.27f);
			}
			if (lacis == true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (2, transform.position.y,1.2f);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (-.9f, -2.3f, 1.2f);
			}
			if (tass == true) {
				agent.updatePosition = true;
				agent.updateRotation = true;
				Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
				transform.position = new Vector3 (2, transform.position.y,1.2f);
				agent.enabled = true;
				Kara.GetComponent<Animation> ().Play ("jalan");
				agent.destination = new Vector3 (-2.25f, -2.3f, -1.76f);
			}
			dkursi = false;
		}
	}
	
	public void goodybag(){

//		Kara.GetComponent<Animation> ().Play ("jalan");
//		agent.destination = new Vector3 (-2f, -2.3f, -.9f);
		timer = 20;
		tas1 = true;
	}
	public void kursi(){

		timer = 25;
//		kursis = true;
//		if (dkasur) {
//			StartCoroutine (perpindahan ());
//		} else {
//			Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
//			Kara.GetComponent<Animation> ().Play ("jalan");
//			agent.destination = new Vector3 (0.6f, -2.3f, .7f);
//		}
		kursi1=true;
	}

	public void meja(){

		Kara.GetComponent<Animation> ().Play ("jalan");
		agent.destination = new Vector3 (1.5f, -2.3f, -0.7f);
		mejas = true;
	}
	public void lemari(){

		timer = 20;
//		Kara.GetComponent<Animation> ().Play ("jalan");
//		agent.destination = new Vector3 (.2f, -2.3f, 1.27f);
//		if (dkasur) {
//			StartCoroutine (perpindahan ());
//		} 
//		if (dkursi) {
//			StartCoroutine (perpindahan ());
//		}else {
//			agent.enabled = true;
//			Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
//			Kara.GetComponent<Animation> ().Play ("jalan");
//			agent.destination = new Vector3 (.2f, -2.3f, 1.27f);
//		}
		lemari1 = true;
	}
	public void lemariatas(){
		
		timer = 20;
		//		Kara.GetComponent<Animation> ().Play ("jalan");
		//		agent.destination = new Vector3 (.2f, -2.3f, 1.27f);
		//		if (dkasur) {
		//			StartCoroutine (perpindahan ());
		//		} 
		//		if (dkursi) {
		//			StartCoroutine (perpindahan ());
		//		}else {
		//			agent.enabled = true;
		//			Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
		//			Kara.GetComponent<Animation> ().Play ("jalan");
		//			agent.destination = new Vector3 (.2f, -2.3f, 1.27f);
		//		}
		lemariatas1 = true;
	}
	public void Kasur(){
		
		timer = 20;
		//			timer -= Time.deltaTime;
//		kasurs = true;
//		if (dkursi) {
//			StartCoroutine (perpindahan ());
//		} else {
//			agent.enabled = true;
//			//transform.position = new Vector3 (xlama, transform.position.y, zlama);
//			Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
//			Kara.GetComponent<Animation> ().Play ("jalan");
//			agent.destination = new Vector3 (-1f, -2.3f, 1.2f);
//		}
		kasur1=true;
	}
	public void Laci(){
		
		timer = 20;
		laci1 = true;
	}
	public void noAnimation(string stage)
	{ var time = .1f;
		StartCoroutine(tunggustage (stage, time));
	}
	public void noAnimation2()
	{ 
		StartCoroutine (tungguplay ());
	}

	IEnumerator kameramejain(){
		yield return new WaitForSeconds (2f);

		//Kara.SetActive( false);

	}
	IEnumerator kameramejaout(){
		//Kara.SetActive( true);
		yield return null;

	} 
	public void kemejain(){
		
		StartCoroutine (kameramejain ());
	}
	public void kemejaout(){
		
		StartCoroutine (kameramejaout ());
	}
	IEnumerator idling (){
		agent.transform.position = new Vector3(0,-0.6756654f,-1);
		agent.updatePosition=false;
		agent.updateRotation = false;
		transform.rotation = Quaternion.Euler (0, 0, 0);
		transform.position = new Vector3(0,-0.6756654f,-1);


		Kara.transform.localRotation = Quaternion.Euler (0, 180, 0);

		Kara.GetComponent<Animation> ().PlayQueued ("idle", QueueMode.PlayNow);
		Kara.GetComponent<Animation> ().PlayQueued ("idle", QueueMode.CompleteOthers);
		Kara.GetComponent<Animation> ().PlayQueued ("liat", QueueMode.CompleteOthers);

//		yield return new WaitForSeconds (9f);
//		agent.updatePosition = true;
//		agent.updateRotation = true;
//
//		Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
//		Kara.GetComponent<Animation> ().PlayQueued ("jalan", QueueMode.PlayNow);
//		agent.destination = new Vector3 (1.5f, -2.3f,-.15f);
//		kursi1 = true;
//		//yield return new WaitForSeconds (2f);
//	
////		Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
////		Kara.GetComponent<Animation> ().Play ("jalan");
////		agent.destination = new Vector3 (0.6f, -2.3f, .7f);
//
////		Kara.GetComponent<Animation> ().PlayQueued ("BD", QueueMode.PlayNow);
////		Envi.GetComponent<Animation> ().PlayQueued ("BD", QueueMode.PlayNow);
////		Kara.GetComponent<Animation> ().PlayQueued ("DB", QueueMode.CompleteOthers);
////		Envi.GetComponent<Animation> ().PlayQueued ("DB", QueueMode.CompleteOthers);
////
////		transform.rotation = Quaternion.Euler (0, 0, 0);
////		//mejas = true;
////		yield return new WaitForSeconds (10);
////		agent.updateRotation = false;
////		mejas = false;
////		agent.updateRotation = true;
////		transform.position = new Vector3 (1.5f, -2.3f, 0f);
////		Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
////		Kara.GetComponent<Animation> ().PlayQueued ("jalan", QueueMode.PlayNow);
////		agent.destination = new Vector3 (0, 0, -1f);
////
////		yield return new WaitForSeconds (1);
////		agent.updateRotation = false;
////		transform.rotation = Quaternion.Euler (0, 0, 0);
////		Kara.transform.localRotation = Quaternion.Euler (0, 180, 0);
////
////		agent.updateRotation = true;
////			Kara.GetComponent<Animation> ().PlayQueued ("idle", QueueMode.PlayNow);
////			Kara.GetComponent<Animation> ().PlayQueued ("idle", QueueMode.CompleteOthers);
////			Kara.GetComponent<Animation> ().PlayQueued ("liat", QueueMode.CompleteOthers);
////		//idleng = false;
//		yield return new WaitForSeconds (15f);
//		Kara.GetComponent<Animation> ().PlayQueued ("DB", QueueMode.PlayNow);
//		Envi.GetComponent<Animation> ().PlayQueued ("DB", QueueMode.PlayNow);
//		yield return new WaitForSeconds (4f);
//		agent.updateRotation = true;
//		agent.updatePosition = true;
//		Kara.GetComponent<Animation> ().PlayQueued ("jalan", QueueMode.PlayNow);
//	
//		Kara.transform.localRotation = Quaternion.Euler (0, 0, 0);
//		transform.position = new Vector3 (2,  transform.position.y,1.2f);
//		agent.destination = new Vector3 (0, 0, -1f);
//	//	Kara.transform.localRotation = Quaternion.Euler (0, 180f, 0);
		yield return null;
//		timer = 0;
		//idleng = true;
	}
	IEnumerator tengah(){
		
		yield return new WaitForSeconds (1);
		agent.destination = new Vector3(0, 0, 0);
		//idling ();
	}
	IEnumerator tunggustage(string stage, float time){
		yield return new WaitForSeconds (time);
	
		SceneManagerHelper.LoadScene (stage);

	}

	IEnumerator tungguplay(){
		yield return new WaitForSeconds (.5f);
		shop.SetActive (true);
		shop.GetComponent<Shop>().AStart();
		soundbg.GetComponent<AudioSource> ().clip = clip;
		soundbg.GetComponent<AudioSource> ().Play ();
		dkursi = false;
		dkasur = false;
	}
	}

