using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccelerationChangeColor : MonoBehaviour {
    public float x;
    public float y;
    public float z;
    bool isWorking = true;
    int forwardnum = 0;
    GameObject Monster;
    // Use this for initialization
    void Start () {
        Monster = GameObject.Find("Monster");
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.acceleration.x;
        y = Input.acceleration.y;
        z = Input.acceleration.z;
        if(y>0.5&&isWorking)
        {
            isWorking = false;
            forwardnum++;
            this.GetComponent<Text>().text=forwardnum.ToString();
        }
        if (y < -0.5 && !isWorking)
        {
            isWorking = true;
            float max = 1;
            Monster.GetComponent<Image>().color = new Color(Random.Range(0, max), Random.Range(0, max), Random.Range(0, max), max);
        }
    }
}
