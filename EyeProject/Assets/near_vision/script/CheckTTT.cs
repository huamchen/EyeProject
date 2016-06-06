using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CheckTTT : MonoBehaviour {
    public int step;
    public GameObject bg;
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject FairText;
    // Use this for initialization
    void Start () {
        step = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public bool Check()
    {
        int flag = CheckWinLose();
        if(flag==1)
        {
            this.GetComponent<AudioSource>().Stop();
            AudioSource audio = GameObject.Find("RightAudio").GetComponent<AudioSource>();
            audio.Play();
            bg.SetActive(true);
            WinText.SetActive(true);
            for (int i = 0; i < 9; i++)
            {
                GameObject.Find("Button " + i.ToString()).SetActive(false);
            }

            return false;

        }
        if(flag==2)
        {
            this.GetComponent<AudioSource>().Stop();
            AudioSource audio = GameObject.Find("WrongAudio").GetComponent<AudioSource>();
            audio.Play();
            bg.SetActive(true);
            LoseText.SetActive(true);
            for (int i = 0; i < 9; i++)
            {
                GameObject.Find("Button " + i.ToString()).SetActive(false);
            }
            return false;
        }
        if (step == 9)
        {
            this.GetComponent<AudioSource>().Stop();
            AudioSource audio = GameObject.Find("WrongAudio").GetComponent<AudioSource>();
            audio.Play();
            bg.SetActive(true);
            FairText.SetActive(true);
            for (int i = 0; i < 9; i++)
            {
                GameObject.Find("Button " + i.ToString()).SetActive(false);
            }
        }
        return true;
    }
    public int CheckWinLose()
    {
        string[] checkArray = new string[9];
        step++;
        for(int i = 0; i < 9; i++)
        {
            checkArray[i] = GameObject.Find("Button " + i.ToString()).GetComponentInChildren<Text>().text;
        }
        if (checkArray[0] == checkArray[1] && checkArray[0] == checkArray[2])
        {
            if (checkArray[0] == "O")
                return 1;
            if (checkArray[0] == "X")
                return 2;
        }

        if (checkArray[3] == checkArray[4] && checkArray[3] == checkArray[5])
        {
            if (checkArray[3] == "O")
                return 1;
            if (checkArray[3] == "X")
                return 2;
        }
        if (checkArray[6] == checkArray[7] && checkArray[6] == checkArray[8])
        {
            if (checkArray[6] == "O")
                return 1;
            if (checkArray[6] == "X")
                return 2;
        }
        if (checkArray[0] == checkArray[3] && checkArray[3] == checkArray[6])
        {
            if (checkArray[0] == "O")
                return 1;
            if (checkArray[0] == "X")
                return 2;
        }
        if (checkArray[1] == checkArray[4] && checkArray[1] == checkArray[7])
        {
            if (checkArray[1] == "O")
                return 1;
            if (checkArray[1] == "X")
                return 2;
        }
        if (checkArray[2] == checkArray[5] && checkArray[2] == checkArray[8])
        {
            if (checkArray[2] == "O")
                return 1;
            if (checkArray[2] == "X")
                return 2;
        }
        if (checkArray[0] == checkArray[4] && checkArray[0] == checkArray[8])
        {
            if (checkArray[0] == "O")
                return 1;
            if (checkArray[0] == "X")
                return 2;
        }
        if (checkArray[2] == checkArray[4] && checkArray[2] == checkArray[6])
        {
            if (checkArray[2] == "O")
                return 1;
            if (checkArray[2] == "X")
                return 2;
        }
        return 0;
    }
}
