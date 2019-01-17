using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleSignInController2 : MonoBehaviour
{
    public string WEB_CLIENT_ID = "YOUR_CLIENT_ID_HERE";

    private bool _loginStarted;
    private string _token;
    private string _errorMsg;
    public string Username, Id, Email, PhotoURL;
  
    public Text statusText;

    public GameObject rg;
    private AndroidGoogleSignIn _pluginScript;

    #region Ui
    //void OnGUI()
    //{
    //    if (!_loginStarted)
    //    {
    //        if (GUI.Button(new Rect(20, 10, Screen.width - 20, 50), "Click To Login with Google", new GUIStyle{fontSize= 100}))
    //        {
    //            _loginStarted = true;
    //            GoogleLogin();
    //        }
    //    }
    //    else
    //    {
    //        if (!string.IsNullOrEmpty(_token))
    //        {
    //            GUI.Label(new Rect(10, 50, Screen.width - 10, 100), _token, new GUIStyle{fontSize= 100});
    //        }
    //        else if (!string.IsNullOrEmpty(_errorMsg))
    //        {
    //            GUI.Label(new Rect(10, 10, Screen.width - 10, 50), _errorMsg, new GUIStyle{fontSize= 100});
    //        }
    //    }
    //}

    #endregion

    #region Implementation

    void Start()
    {
        _pluginScript = AndroidGoogleSignIn.Init(this.gameObject);
    }

    private void GoogleLogin()
    {
        _pluginScript.SignIn(WEB_CLIENT_ID, GoogleSuccessCallback, GoogleErrorCallback);
    }

    public void OnSignIn()
    {
        _pluginScript.SignIn(WEB_CLIENT_ID, GoogleSuccessCallback, GoogleErrorCallback);
     
    }


    private void GoogleSuccessCallback(AndroidGoogleSignInAccount result)
    {
        _token = "Login successful, your Email is: " + result.Email;
        _token += "\n your Name is: " + result.DisplayName;
        _token += "\n your ID is: " + result.Id;
        _token += "\n your Photo is: " + result.PhotoUrl;
        Username = result.DisplayName;
        Id = result.Id;
        PhotoURL = result.PhotoUrl;
        Email = result.Email;
        	if (Application.loadedLevelName == "Register") {
				rg.GetComponent<Register> ().CekLoginFromGoogle ();
			} else {
				rg.GetComponent<LinkUser> ().LUser (2);
			}
       
         _token += "\nand your Token: " + result.Token;
        statusText.text = _token;

    }

    private void GoogleErrorCallback(string errorMsg) {
        _errorMsg = "Google Sign in Failed";
    }

    #endregion

}
