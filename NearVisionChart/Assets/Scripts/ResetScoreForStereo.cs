using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetScoreForStereo : MonoBehaviour {

    public void Reset()
    {
        GameObject scoreboard = GameObject.Find("ScoreBoard");
        scoreboard.GetComponent<ScoreBoardForStereo>().passNum = 0;
        scoreboard.GetComponent<ScoreBoardForStereo>().testNum = 0;
        GameObject.Find("Result").SetActive(false);
    }
}
