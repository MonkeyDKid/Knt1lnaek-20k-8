using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SoundBG : MonoBehaviour {
	//private AudioSource soundBG;
	public BackgroundMusic[] BackgroundMusics;
	private static BackgroundMusic[] _backgroundMusics;
	private static AudioSource soundBG;

	void Start () {
		soundBG = GetComponent<AudioSource> ();
		//soundBG.volume = PlayerPrefs.GetFloat ("Music");
		_backgroundMusics = BackgroundMusics;
		CheckBackgroundMusic(SceneManager.GetActiveScene().name);
		
	}
	public void Onchange(){
		soundBG.volume = PlayerPrefs.GetFloat ("Music");
	}
	
	public static void myvolume(float changevalue)
	{
		soundBG.volume = changevalue;
	}

		

		public static void CheckBackgroundMusic(string sceneIndex)
		{
			foreach (var backgroundMusic in _backgroundMusics)
			{
				var isActive = backgroundMusic.CheckIfShouldBeActive(sceneIndex);
				if (isActive)
				{
					if (soundBG.clip != backgroundMusic.AudioClip)
					{
						soundBG.clip = backgroundMusic.AudioClip;
						soundBG.loop = true;
						soundBG.Play();
					}
				}
			}
		}

		public static void CheckBackgroundMusicPlayOnce(string sceneIndex)
		{
			foreach (var backgroundMusic in _backgroundMusics)
			{
				var isActive = backgroundMusic.CheckIfShouldBeActive(sceneIndex);
				if (isActive)
				{
					if (soundBG.clip != backgroundMusic.AudioClip)
					{
						soundBG.clip = backgroundMusic.AudioClip;
						soundBG.loop = false;
						soundBG.Play();
					}
				}
			}
		}

		public static void StopBackgroundMusic()
		{
			soundBG.enabled = false;
		}

		public static void StopBGMusic()
		{
			soundBG.Stop();
		}

		public static void PlayBackgroundMusic()
		{
			soundBG.enabled = true;
		}
	
	

}

