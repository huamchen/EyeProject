using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		float max=1;
		this.GetComponent<Image>().color = new Color(Random.Range(0,max),Random.Range(0,max),Random.Range(0,max),max);
        this.GetComponent<Image>().overrideSprite=Resources.Load("texture/animals/animals_"+Random.Range(0,9).ToString(), typeof(Sprite)) as Sprite;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
