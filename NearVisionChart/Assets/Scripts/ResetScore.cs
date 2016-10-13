using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetScore : MonoBehaviour {


    // Update is called once per frame
    public void Reset () {
        GameObject scoreboard = GameObject.Find("ScoreBoard");
        scoreboard.GetComponent<ScoreBoard>().passNum = 0;
        scoreboard.GetComponent<ScoreBoard>().failNum = 0;
        GameObject.Find("Result").SetActive(false);
    }

}
