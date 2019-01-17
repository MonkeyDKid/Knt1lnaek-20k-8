using System;
using System.Linq;
using UnityEngine;


	[Serializable]
	public class BackgroundMusic
	{
		public string[] SceneIndices;
		public AudioClip AudioClip;

		public bool CheckIfShouldBeActive(string sceneIndex)
		{
			return SceneIndices.Contains(sceneIndex);
		}
	}

