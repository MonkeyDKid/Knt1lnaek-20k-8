using UnityEngine;
using UnityEngine.UI;

public class SampleScript2 : MonoBehaviour {

  
    [SerializeField] GameObject GO;
    [SerializeField] GameObject Another;
   

    public void RequestPermission(){
        if (UniAndroidPermission.IsPermitted(AndroidPermission.ACCESS_FINE_LOCATION))
        {
            Another.SetActive(true);
           // text.text = "WRITE_EXTERNAL_STORAGE is already permitted!!";
           // Home.OnHuntingClick();
          //  Lifeless.pindah();
            return;
        }

        UniAndroidPermission.RequestPermission(AndroidPermission.ACCESS_FINE_LOCATION, OnAllow, OnDeny, OnDenyAndNeverAskAgain);
    }

    private void OnAllow()
    {
        // text.text = "WRITE_EXTERNAL_STORAGE is permitted NOW!!";
        // Home.OnHuntingClick();
        // Lifeless.pindah(); 
        Another.SetActive(true);

    }

    private void OnDeny()
    {
        GO.SetActive(true);       
        // text.text = "WRITE_EXTERNAL_STORAGE is NOT permitted...";
    }

    private void OnDenyAndNeverAskAgain()
    {
        GO.SetActive(true);
        //  text.text = "WRITE_EXTERNAL_STORAGE is NOT permitted and checked never ask again option";
    }
}
