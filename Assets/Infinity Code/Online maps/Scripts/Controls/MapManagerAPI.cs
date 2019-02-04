using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
/// <summary>
/// Class control the map for the Tileset.
/// Tileset - a dynamic mesh, created at runtime.
/// </summary>
[Serializable]
[AddComponentMenu("Infinity Code/Online Maps/Controls/Tileset")]
public class MapManagerAPI : MonoBehaviour {

	public OnlineMapsControlBase3D abc;
	public GameObject bcd;
	// Use this for initialization
	void Start () {
		OnlineMapsMarker3D marker = abc.AddMarker3D(new Vector2(-6.27074973995987f,106.932347372895f), bcd);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}