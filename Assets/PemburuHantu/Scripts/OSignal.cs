using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalPush.MiniJSON;

public class OSignal : MonoBehaviour {
	private static string extraMessage;
	public string id = "";
	// Use this for initialization
	void Start () {
		#if !UNITY_EDITOR
		OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.VERBOSE, OneSignal.LOG_LEVEL.NONE);
		OneSignal.StartInit("d1637280-1caa-4fbe-a688-a10c9bb36890")
		.HandleNotificationReceived(HandleNotificationReceived)
		.HandleNotificationOpened(HandleNotificationOpened)
		.InFocusDisplaying(OneSignal.OSInFocusDisplayOption.None)
		.EndInit();

		OneSignal.IdsAvailable((userId, pushToken) => {
		id = userId;
		//StartCoroutine (onCoroutine());
		});
		#endif


			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private static void HandleNotificationReceived(OSNotification notification) {
		OSNotificationPayload payload = notification.payload;
		string message = payload.body;

		print("GameControllerExample:HandleNotificationReceived: " + message);
		print("displayType: " + notification.displayType);
		extraMessage = "Notification received with text: " + message;

		Dictionary<string, object> additionalData = payload.additionalData;
		if (additionalData == null) 
			Debug.Log ("[HandleNotificationReceived] Additional Data == null");
		else
			Debug.Log("[HandleNotificationReceived] message "+ message +", additionalData: "+ Json.Serialize(additionalData) as string);
	}

	// Called when a notification is opened.
	// The name of the method can be anything as long as the signature matches.
	// Method must be static or this object should be marked as DontDestroyOnLoad
	public static void HandleNotificationOpened(OSNotificationOpenedResult result) {
		OSNotificationPayload payload = result.notification.payload;
		string message = payload.body;
		string actionID = result.action.actionID;

		print("GameControllerExample:HandleNotificationOpened: " + message);
		extraMessage = "Notification opened with text: " + message;

		Dictionary<string, object> additionalData = payload.additionalData;
		if (additionalData == null) 
			Debug.Log ("[HandleNotificationOpened] Additional Data == null");
		else
			Debug.Log("[HandleNotificationOpened] message "+ message +", additionalData: "+ Json.Serialize(additionalData) as string);

		if (actionID != null) {
			// actionSelected equals the id on the button the user pressed.
			// actionSelected will equal "__DEFAULT__" when the notification itself was tapped when buttons were present.
			extraMessage = "Pressed ButtonId: " + actionID;
		}
	}


}
