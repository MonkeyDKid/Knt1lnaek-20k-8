using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
public class ButtonClick : MonoBehaviour {
public UnityEvent task;
private Button Click;
	// Use this for initialization
	void Awake()
	{
		Click = GetComponent<Button>();
	}

	void Start () 
	{
		Click.onClick.AddListener(OnClicking);
	}
	
	private void OnClicking()
	{
		Click.gameObject.transform.DOPunchScale((new Vector3(.2f,.2f,.2f)),.1f,2,.2f).OnComplete(DoTask);
	}
	private void DoTask()
	{
		task.Invoke();
	}
}
