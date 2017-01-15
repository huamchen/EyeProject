using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AnswersScript : MonoBehaviour {
	
	public int[] panelScore = new int[15];	// saves weighted answer (0-4)
	public bool[] panelBool = new bool[15]; // sets panelBool[index] to true if user has pressed any of the answer buttons ONCE
	public string[] questionBank = {
		"1. Do your eyes feel tired when reading or doing close work?",
		"2. Do your eyes feel uncomfortable when reading of doing close work?",
		"3. Do you have headaches when reading or doing close work?",
		"4. Do you feel sleepy when reading or doing class work?",
		"5. Do you lose concentration when reading or doing close work?",
		"6. Do you have trouble remembering what you have read?",
		"7. Do you have double vision when reading of doing close work?",
		"8. Do you see the words move, jump, swim, or appear to float on the page when reading or doing close work?",
		"9. Do you feel like you read slowly?",
		"10. Do your eyes ever hurt when reading or doing close work?",
		"11. Do your eyes ever feel sore when reading or doing close work?",
		"12. Do you feel a \"pulling\" feeling around your eyes when reading or doing close work?",
		"13. Do you notice the words blurring or coming in and out of focus when reading or doing close work?",
		"14. Do you lose your place while reading or doing close work?",
		"15. Do you have to re-read the same line of words when reading?"
	};
	public int index = 0; 					// keeps track of which panel user is at
	public int total = 0;					// survey's total score
	
	public GameObject QuestionPanel;
	public Button NeverButton, InfrequentlyButton, SometimesButton, FairlyOftenButton, AlwaysButton,
		NextButton, PrevButton;
	public Text ResultText, ResultText2;

	public void GetScore (Button button) {
		if (button.name == "NeverButton") {
			panelScore[index] = 0;
			panelBool[index] = true;
		} else if (button.name == "InfrequentlyButton") {
			panelScore[index] = 1;
			panelBool[index] = true;
		} else if (button.name == "SometimesButton") {
			panelScore[index] = 2;
			panelBool[index] = true;
		} else if (button.name == "FairlyOftenButton") {
			panelScore[index] = 3;
			panelBool[index] = true;
		} else if (button.name == "AlwaysButton") {
			panelScore[index] = 4;
			panelBool[index] = true;
		}
			
		Debug.Log ("panelScore[" + index + "] is " + panelScore[index] + " and Button is " + button.name);
	}
	
	public void SubmitButton(Button button){
		// int[] unanswered = new int[15]; // stores question numbers that are unanswered
		List<int> unanswered = new List<int>(); // stores question numbers that are unanswered
		int sizeOfList; 						// size of List unanswered
		
		// Add to end of list if user hasn't answered
		for (int i=0; i < panelBool.Length; i++){
			if (!panelBool[i]){
				unanswered.Add(i);
			}
		}
		
		sizeOfList = unanswered.Count;
		
		if(sizeOfList == 0){
			ResultText.text = "Do you want to submit?";
		} else {
			string unQuest = "" + (unanswered.ElementAt(0)+1); //unanswered questions
			if (sizeOfList > 1){
				for(int i = 1; i<sizeOfList; i++){
					unQuest += ", " + (unanswered.ElementAt(i)+1);
				}
			}
			ResultText.text = "The following question(s) have not been answered yet:\n\n" + unQuest
				+ "\n\nAre you sure you want to submit?";
		}
		GameObject.Find("Canvas").transform.Find("ResultPanels").transform.Find("Result").gameObject.SetActive(true);
	}
	
	public void ConfirmButton(Button button){
		//send score to DB
		/* totalScore();
		Debug.Log("Total score is " + total + " and Button is " + button.name);
		Debug.Log(button.name + " is pressed.");
		Debug.Log("total = " + total); */
		addTotalScore();
		
		GameObject.Find("Canvas").transform.Find("ResultPanels").transform.Find("Result").gameObject.SetActive(false);
		
		//for development's sake, lets user know what the total score is
		//can be deleted when not needed
		GameObject.Find("Canvas").transform.Find("ResultPanels").transform.Find("Result2").gameObject.SetActive(true);
		ResultText2.text = "Your total score is: " + total+"\n";
        if (total < 20)
        {
            ResultText2.text += "You don't have convergence insufficiency";
        }
        else ResultText2.text += "You are showing symptoms";
    }
	
	public void CloseButton(Button button){
		GameObject.Find("Canvas").transform.Find("ResultPanels").transform.Find("Result2").gameObject.SetActive(false);
	}
	
	public void CancelButton(Button button){
		Debug.Log(button.name + " is pressed.");
		GameObject.Find("Canvas").transform.Find("ResultPanels").transform.Find("Result").gameObject.SetActive(false);
	}
	
	//Remembers user's answers by highlighting the pressed answer
	//Script file "OnNextButtonClick.cs" and "OnPrevButtonClick.cs" use this method
	public void highlightButton(){
		if (panelBool[index]){
			if (panelScore[index] == 0) NeverButton.Select();
			if (panelScore[index] == 1) InfrequentlyButton.Select();
			if (panelScore[index] == 2) SometimesButton.Select();
			if (panelScore[index] == 3) FairlyOftenButton.Select();
			if (panelScore[index] == 4) AlwaysButton.Select();
		}
	}
	
	private void addTotalScore(){
		total = 0; // reset total's value before calculating score
		for (int i = 0; i < panelScore.Length; i++)
			this.total += panelScore[i];
	}
	
	void Start(){
		QuestionPanel.SetActive(true); // makes sure QuestionPanel is always active at start of app
	}
	
	void Update() {
		if (index == 0){
			GameObject.Find("Canvas").transform.Find("QuestionPanel").transform.Find("PrevButton").gameObject.SetActive(false);
		} else{
			GameObject.Find("Canvas").transform.Find("QuestionPanel").transform.Find("PrevButton").gameObject.SetActive(true);
		}
		if (index == 14){
			GameObject.Find("Canvas").transform.Find("QuestionPanel").transform.Find("SubmitButton").gameObject.SetActive(true);
			GameObject.Find("Canvas").transform.Find("QuestionPanel").transform.Find("NextButton").gameObject.SetActive(false);
		} else{
			GameObject.Find("Canvas").transform.Find("QuestionPanel").transform.Find("SubmitButton").gameObject.SetActive(false);
			GameObject.Find("Canvas").transform.Find("QuestionPanel").transform.Find("NextButton").gameObject.SetActive(true);
		}
	}
}
