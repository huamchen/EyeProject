using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBoardForStereo : MonoBehaviour {

    public int passNum = 0;
    public int testNum = 0;
    public int totalNum = 20;

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (passNum == 5)
            showResult(true);
        if (testNum == totalNum)
            showResult(false);
        
    }
    void showResult(bool pass)
    {
        GameObject.Find("Canvas").transform.Find("Result").gameObject.SetActive(true);
        GameObject.Find("Result/Score").GetComponent<Text>().text = "";
        if (pass)
            GameObject.Find("Result/Text").GetComponent<Text>().text = "PASS";
        else GameObject.Find("Result/Text").GetComponent<Text>().text = "FAIL";
    }
}
