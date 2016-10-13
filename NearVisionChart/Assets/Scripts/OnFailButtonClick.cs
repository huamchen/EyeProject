using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class OnFailButtonClick : MonoBehaviour {
    public GameObject scoreBoard;
    public Sprite[] sp;


    void Start()
    {
        scoreBoard = GameObject.Find("ScoreBoard");
    }

    public void Fail()
    {
        scoreBoard.GetComponent<ScoreBoard>().failNum++;
        Debug.Log("OnFailButtonClick");
        if (GameObject.Find("StereogramImage") != null)
        {
            int randomNum = Random.Range(0, 6);
            GameObject.Find("StereogramImage").GetComponent<Image>().sprite = sp[randomNum];
        }
    }
}
