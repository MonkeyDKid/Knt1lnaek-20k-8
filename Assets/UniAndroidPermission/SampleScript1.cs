using UnityEngine;
using UnityEngine.UI;

public class SampleScript1 : MonoBehaviour {

  
    [SerializeField] GameObject GO;
    [SerializeField] IVCPickerExample Home;
    [SerializeField]
    Text text;

    public void RequestPermission(){
        if (UniAndroidPermission.IsPermitted (AndroidPermission.WRITE_EXTERNAL_STORAGE)) {
            Home.getGalery();
           // text.text = "WRITE_EXTERNAL_STORAGE is already permitted!!";
           // Home.OnHuntingClick();
          //  Lifeless.pindah();
            return;
        }

        UniAndroidPermission.RequestPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE, OnAllow, OnDeny, OnDenyAndNeverAskAgain);
    }

    private void OnAllow()
    {
        // text.text = "WRITE_EXTERNAL_STORAGE is permitted NOW!!";
        // Home.OnHuntingClick();
        // Lifeless.pindah(); 
        Home.getGalery();

    }

    private void OnDeny()
    {
        GO.SetActive(true);
        text.text = "WARNING\n\nYou can't use this mode yet, enable your Storage permission.";
    }

    private void OnDenyAndNeverAskAgain()
    {
        GO.SetActive(true);
          text.text = "WARNING\n\nYou can't use this mode yet, enable your Storage permission.";
    }
}
