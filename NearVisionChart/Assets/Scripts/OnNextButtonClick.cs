using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnNextButtonClick : MonoBehaviour {

	public GameObject answersScript;

	// Use this for initialization
	void Start () {
		answersScript = GameObject.Find("AnswersScript");
	}
	
	public void Next () {
		answersScript.GetComponent<AnswersScript>().index++;
		Debug.Log("index: " + answersScript.GetComponent<AnswersScript>().index);
		GameObject.Find("QuestionPanel/DynamicQuestion").GetComponent<Text>().text = 
			answersScript.GetComponent<AnswersScript>().questionBank[answersScript.GetComponent<AnswersScript>().index];
		answersScript.GetComponent<AnswersScript>().highlightButton();
	}
}
