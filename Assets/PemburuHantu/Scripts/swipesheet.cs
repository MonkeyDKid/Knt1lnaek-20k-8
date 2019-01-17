using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipesheet : MonoBehaviour {
	float startTime,swipeTime,swipeDist,endTime;
	public GameObject vanny;
	public int maxTime,minSwipeDist;
	public Text debug;
	Vector2 startPos,endPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.touchCount > 0) { 
//			Touch touch = Input.GetTouch(0);
//			if (touch.phase == TouchPhase.Began) {
//				 startTime = Time.time;
//				 startPos = touch.position;
//			} 
//			else if (touch.phase == TouchPhase.Ended) {
//				 endTime = Time.time;
//				 endPos = touch.position;
//				 swipeDist = (endPos - startPos).magnitude;
//				 swipeTime = endTime - startTime;
//			}
//			if (swipeTime < maxTime && swipeDist > minSwipeDist) {
//				swipe ();
//			}
		
//		}
	}
	void OnMouseDrag(){
		float rotX = Input.GetAxis ("Mouse X") * 10 * Mathf.Deg2Rad;
		transform.RotateAround (Vector3.up, -rotX);
	}

		//	And this code for swipe:

				void swipe()
			{
				Vector2 distance = endPos - startPos;
				if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
				{ 
					if (distance.x > 0)
					{
				debug.text=("Right swipe");
				vanny.transform.localEulerAngles +=  new Vector3 (0, distance.x, 0);
					}
					if (distance.x < 0)
					{
				debug.text=("Left swipe");
				vanny.transform.localEulerAngles -= new Vector3 (0, distance.x, 0);
					}
				}
				if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
				{
					if (distance.y > 0)
					{
				debug.text=("Up swipe");
					}
					if (distance.y < 0)
					{
				debug.text=("Down swipe");
					}
				} 
			}
}
