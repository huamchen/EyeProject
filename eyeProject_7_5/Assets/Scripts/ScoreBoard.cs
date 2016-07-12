using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    public int passNum = 0;
    public int failNum = 0;
    public int totalNum = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (passNum + failNum == totalNum)
            showResult();
	}
    void showResult()
    {
        GameObject.Find("Canvas").transform.Find("Result").gameObject.SetActive(true);
        GameObject.Find("Result/Score").GetComponent<Text>().text=passNum.ToString()+"/"+totalNum.ToString();
        if(passNum/totalNum>=0.6)
            GameObject.Find("Result/Text").GetComponent<Text>().text="PASS";
        else GameObject.Find("Result/Text").GetComponent<Text>().text = "FAIL";
    }
}
