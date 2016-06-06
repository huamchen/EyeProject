using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CalTTT : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var button = this.gameObject.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(TestClick);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void TestClick()
    {
        
        CheckTTT checkScript = GameObject.Find("CheckObject").GetComponent<CheckTTT>();
        if (this.GetComponentInChildren<Text>().text.Length == 0)
        {            
            this.GetComponentInChildren<Text>().text = "O";
            if (checkScript.Check())
            {
                while (checkScript.step < 9)
                {
                    int num = Random.Range(0, 9);
                    if (GameObject.Find("Button " + num.ToString()).GetComponentInChildren<Text>().text.Length == 0)
                    {
                        GameObject.Find("Button " + num.ToString()).GetComponentInChildren<Text>().text = "X";
                        checkScript.Check();
                        break;
                    }
                }
            }
        }
    }
}
