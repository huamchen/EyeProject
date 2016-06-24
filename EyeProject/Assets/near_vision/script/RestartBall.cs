using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RestartBall : MonoBehaviour {
    public bool flag = false;
    public GameObject timer;
    public GameObject bg;
    public GameObject ball;
    public GameObject pencil;

    // Use this for initialization
    void Awake() {
          var button = this.gameObject.GetComponent<Button>();
          if (button != null)
          {
              button.onClick.RemoveAllListeners();
              button.onClick.AddListener(TestClick);
          }
        timer = GameObject.Find("Timer");
        bg = GameObject.Find("backGround");
        ball = GameObject.Find("ball");
        pencil= GameObject.Find("pencil");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void TestClick()
    {
        if (flag)
        {
            AudioSource audio= GameObject.Find("RightAudio").GetComponent<AudioSource>();
            audio.Play();
            if (ball.GetComponent<TimerAndColor>().enableTime < 5)
            {
                timer.SetActive(true);
                bg.SetActive(true);
                ball.SetActive(true);
                pencil.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
        else
        {
            AudioSource audio = GameObject.Find("WrongAudio").GetComponent<AudioSource>();
            audio.Play();
            ball.GetComponent<TimerAndColor>().wrongTime++;
        }
        
    }
}
