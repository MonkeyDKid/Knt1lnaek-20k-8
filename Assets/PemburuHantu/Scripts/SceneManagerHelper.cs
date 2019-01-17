using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
	
	public class SceneManagerHelper : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] ErrorWindow;
		public static SceneManagerHelper _instance { get; private set; }

		private void Awake()
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}

		public void HandleError(int errorCode)
		{
			switch(errorCode)
			{
				case 33:
				ErrorWindow[1].SetActive(true);
				ErrorWindow[1].transform.DOPunchScale((new Vector3(1,1,1)),.15f,10);
				break;
				default:
				ErrorWindow[0].SetActive(true);
				ErrorWindow[0].transform.DOPunchScale((new Vector3(1,1,1)),.15f,10);
				break;
			}
		}

		public static void LoadScene(int sceneToLoad)
		{
			string path = SceneUtility.GetScenePathByBuildIndex(sceneToLoad);
			string sceneName = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);

			LoadScene(sceneName);
		}

			public static bool HasKey(string keyname)
		{
			if(PlayerPrefs.HasKey(keyname))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

			public static void SaveKey(string type, string name, string data)
		{
			PlayerPrefs.SetString(type+name, data);
		}
		public static void LoadScene(string sceneToLoad)
		{
			SceneManager.LoadScene(sceneToLoad);
			SoundBG.CheckBackgroundMusic(sceneToLoad);
		}

		public static void LoadTutorial(string sceneToLoad)
		{
			FlowchartController.StartBlock(sceneToLoad);
			//SoundBG.CheckBackgroundMusic(sceneToLoad);
		}
		public static void StopTutorial()
		{
			FlowchartController.StopBlock();
			//SoundBG.CheckBackgroundMusic(sceneToLoad);
		}
		
		public static void LoadMusic(string sceneToLoad)
		{
			SoundBG.CheckBackgroundMusic(sceneToLoad);
		}
		public static void LoadSoundFX(string sceneToLoad)
		{
			SoundBG.CheckBackgroundMusicPlayOnce(sceneToLoad);
		}

		public static void StopMusic()
		{
			SoundBG.StopBGMusic();
		}

		public static void CekSound(float value)
		{
			//SoundBG.myvolume(value);
		}
     

		private static int _stageIndex;
		public static void LoadScene(string sceneToLoad, int stageIndex)
		{
			_stageIndex = stageIndex;
			LoadScene(sceneToLoad);
		}

			public static void ShowAdditiveScene(string newSceneName)
		{
			_instance.StartCoroutine(DoShowAdditiveScene(newSceneName));
		}

		public static void UnloadAdditiveScene(string newSceneName)
		{
			_instance.StartCoroutine(DoUnloadAdditiveScene(newSceneName));
		}

		private static IEnumerator DoShowAdditiveScene(string newSceneName)
		{
			var asyncLoad = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);

			while (!asyncLoad.isDone)
			{
				yield return null;
			}		
		}


		private static IEnumerator DoUnloadAdditiveScene(string newSceneName)
		{
			var isSceneLoaded = SceneManager.GetSceneByName(newSceneName).isLoaded;
			if (isSceneLoaded)
			{
				var asyncOperation = SceneManager.UnloadSceneAsync(newSceneName);

				while (!asyncOperation.isDone)
				{
					yield return null;
				}

				var gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
				foreach (var g in gameObjects)
				{
					g.SetActive(true);
				}

			//	ManagerSingleton.ActiveManager.HookAnimatorBehaviour();
			}
		}
	public static void enableGO(string gameobjectName){
		var gameobject = GameObject.Find (gameobjectName);
		gameobject.SetActive (true);
	}
	}

