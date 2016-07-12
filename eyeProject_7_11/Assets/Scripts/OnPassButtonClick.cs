using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class OnPassButtonClick : MonoBehaviour {

    public GameObject scoreBoard;
    

    void Start()
    {
        scoreBoard = GameObject.Find("ScoreBoard");
    }
    public void Pass()
    {
        scoreBoard.GetComponent<ScoreBoard>().passNum++;
		Debug.Log("OnPassButtonClick");
    }
}
