using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NearVisionAcuityCheck : MonoBehaviour {
    public string input;
    string[] pattern = { "A", "DF", "HZP", "TXUD", "ZADNH", "PNTUHX", "UAZNFDT", "NPHTAFUX", "XDFHPTZAN", "FAXTDNHUPZ" };
    string[] level = { "20/200", "20/100", "20/70", "20/50", "20/40", "20/30", "20/25", "20/20", "20/15", "20/10" };    
    public void inputButton(string text)
    {
        input += text;
        GameObject.Find("Title").GetComponent<Text>().text = input;
    }
    public void returnButton()
    {
        if(input.Length>0)
            input=input.Substring(0, input.Length - 1);
        GameObject.Find("Title").GetComponent<Text>().text = input;
    }
    public void check()
    {
        
        int unblock = GameObject.Find("BlockImage").GetComponent<ChooseBlockImage>().unblock;
        if (input.Length != pattern[unblock].Length)
            return;
        int rightNum = 0;
        for(int i = 0; i < pattern[unblock].Length; i++)
        {
            if (input[i] == pattern[unblock][i])
                rightNum++;
        }
        GameObject.Find("Canvas").transform.Find("Result").gameObject.SetActive(true);
        GameObject.Find("Result/Score").GetComponent<Text>().text = rightNum.ToString() + "/" + pattern[unblock].Length.ToString();
        GameObject.Find("Result/Text").GetComponent<Text>().text = level[unblock];

    }

}
