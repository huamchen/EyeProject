using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;
public class TimerAndColor : MonoBehaviour {

    public bool[] flag;
    public int index;
    public int wrongTime;
    public GameObject WinText;
    public int enableTime;
    System.DateTime beginTime;
    public Sprite[] sp;
	// Use this for initialization
	void Awake () {
        flag = new bool[4];
        for (int i = 0; i < 4; i++)
            flag[i] = true;
        enableTime = 0;
        wrongTime = 0;
        sp = Resources.LoadAll<Sprite>("texture/animals") as Sprite[];
    }
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Timer").GetComponent<Text>().text = (System.DateTime.Now - beginTime).ToString();
        if (System.DateTime.Now.Ticks - beginTime.Ticks > 30000000)
        {
            GameObject.Find("Timer").SetActive(false);
            GameObject.Find("backGround").SetActive(false);
            GameObject.Find("ball").SetActive(false);
            GameObject.Find("pencil").SetActive(false);
        }
    }

    void OnEnable ()
    {
        float max = 1;
        enableTime++;
        if (enableTime < 5)
        {
            bool[] spFlag = new bool[9];
            for (int i = 0; i < 9; i++)
                spFlag[i]= false;
            int spNum;
            if (flag[0])
            {
                ///  GameObject.Find("TopLeftButton").GetComponent<Image>().color = new Color(Random.Range(0, max), Random.Range(0, max), Random.Range(0, max), max);
                do
                {
                    spNum = Random.Range(0, 9);
                }
                while (spFlag[spNum]);
                spFlag[spNum] = true;
                GameObject.Find("TopLeftButton").GetComponent<Image>().sprite= sp[spNum];
            }
            if (flag[1])
            {
                do
                {
                    spNum = Random.Range(0, 9);
                }
                while (spFlag[spNum]);
                spFlag[spNum] = true;
                // GameObject.Find("TopRightButton").GetComponent<Image>().color = new Color(Random.Range(0, max), Random.Range(0, max), Random.Range(0, max), max);
                GameObject.Find("TopRightButton").GetComponent<Image>().sprite = sp[spNum];
            }
            if (flag[2])
            {
                do
                {
                    spNum = Random.Range(0, 9);
                }
                while (spFlag[spNum]);
                spFlag[spNum] = true;
                //  GameObject.Find("BottomLeftButton").GetComponent<Image>().color = new Color(Random.Range(0, max), Random.Range(0, max), Random.Range(0, max), max);
                GameObject.Find("BottomLeftButton").GetComponent<Image>().sprite = sp[spNum];
            }
            if (flag[3])
            {
                do
                {
                    spNum = Random.Range(0, 9);
                }
                while (spFlag[spNum]);
                spFlag[spNum] = true;
                // GameObject.Find("BottomRightButton").GetComponent<Image>().color= new Color(Random.Range(0, max), Random.Range(0, max), Random.Range(0, max), max);
                GameObject.Find("BottomRightButton").GetComponent<Image>().sprite = sp[spNum];
            }


            do
                index = Random.Range(0, 4);
            while (!flag[index]);
            flag[index] = false;


            if (index == 0)
            {
              //  this.GetComponent<Image>().color = GameObject.Find("TopLeftButton").GetComponent<Image>().color;
                this.GetComponent<Image>().sprite = GameObject.Find("TopLeftButton").GetComponent<Image>().sprite;
                GameObject.Find("TopLeftButton").GetComponent<RestartBall>().flag = true;
            }
            if (index == 1)
            {
              //  this.GetComponent<Image>().color = GameObject.Find("TopRightButton").GetComponent<Image>().color;
                this.GetComponent<Image>().sprite = GameObject.Find("TopRightButton").GetComponent<Image>().sprite;
                GameObject.Find("TopRightButton").GetComponent<RestartBall>().flag = true;
            }
            if (index == 2)
            {
              //  this.GetComponent<Image>().color = GameObject.Find("BottomLeftButton").GetComponent<Image>().color;
                this.GetComponent<Image>().sprite = GameObject.Find("BottomLeftButton").GetComponent<Image>().sprite;
                GameObject.Find("BottomLeftButton").GetComponent<RestartBall>().flag = true;
            }
            if (index == 3)
            {
              //  this.GetComponent<Image>().color = GameObject.Find("BottomRightButton").GetComponent<Image>().color;
                this.GetComponent<Image>().sprite = GameObject.Find("BottomRightButton").GetComponent<Image>().sprite;
                GameObject.Find("BottomRightButton").GetComponent<RestartBall>().flag = true;
            }
            beginTime = System.DateTime.Now;
        }
        else if (enableTime == 5)
        {
            GameObject.Find("BGM").GetComponent<AudioSource>().Stop();

            WinText.SetActive(true);

            GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>().Upload(wrongTime);
        }
    }
}
