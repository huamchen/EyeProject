using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StereogramCheck : MonoBehaviour {


    public void check(int myFlag)
    {
        GameObject scoreboard = GameObject.Find("ScoreBoard");
        int flag = GameObject.Find("Canvas").GetComponent<RanDotStereogram>().flag;
        if (flag == myFlag)
        {
            scoreboard.GetComponent<ScoreBoardForStereo>().passNum++;
        }
        else scoreboard.GetComponent<ScoreBoardForStereo>().passNum=0;
        scoreboard.GetComponent<ScoreBoardForStereo>().testNum++;
        GameObject.Find("Canvas").GetComponent<RanDotStereogram>().newRandomImage();

    }
}
