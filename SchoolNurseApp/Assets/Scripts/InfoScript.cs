using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoScript : MonoBehaviour {

    public GameObject Info;
	public void OpenMoreInfo(Button button){
        Info.SetActive(true);
	}
	
	public void CloseMoreInfo(Button button){
        Info.SetActive(false);
    }
}
