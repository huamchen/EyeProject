using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class ScoreBoard : MonoBehaviour {
    public System.DateTime date;
    public System.TimeSpan startTime;

    // Use this for initialization
    void Start () {
        date = System.DateTime.Now.Date;
        startTime = new System.TimeSpan(System.DateTime.Now.Ticks);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Upload(int s)
    {
        System.DateTime date;
        System.TimeSpan startTime;
        date = System.DateTime.Now.Date;
        startTime = new System.TimeSpan(System.DateTime.Now.Ticks);
        var svcClient = new BasicHttpBinding_IEyeWebService();
        PatientGameScore score = new PatientGameScore();
        GameScore gs = new GameScore
        {
            datePlayed = date.ToString(),
           // durationInMin =(new System.TimeSpan(System.DateTime.Now.Ticks) - startTime).ToString(),
            score = s
        };
        GameScore[] gameScoreCollection = new GameScore[] { gs };
        score.gameScoreList = gameScoreCollection;
        score.patientId = 34;
        score.game = new Game { gameId = 10 };
     //   Debug.Log(score.gameScoreList[0].durationInMin);
        Debug.Log(score.gameScoreList[0].score);
        PatientGameScore newscore = svcClient.SetGameScoresForPatient(score);
     //   Debug.Log(newscore.gameScoreList[0].durationInMin);
        Debug.Log(newscore.gameScoreList[0].score);
    }
}
