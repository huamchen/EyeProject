using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour {

    public void register()
    {
        string firstname = GameObject.Find("FirstName/InputField/Text").GetComponent<Text>().text;
        string lastname = GameObject.Find("LastName/InputField/Text").GetComponent<Text>().text;
        string grade = GameObject.Find("Grade/InputField/Text").GetComponent<Text>().text;
        string sid = GameObject.Find("SID/InputField/Text").GetComponent<Text>().text;



        Debug.Log("OK!");
        PlayerPrefs.SetString("sid", sid);
    }
}
