using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OnFailButtonClick : MonoBehaviour {
    public GameObject scoreBoard;


    void Start()
    {
        scoreBoard = GameObject.Find("ScoreBoard");
    }

    public void Fail()
    {
        scoreBoard.GetComponent<ScoreBoard>().failNum++;
        Debug.Log("OnFailButtonClick");
    }
}
