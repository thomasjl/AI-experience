using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControllerScript : MonoBehaviour {

	bool human;
	bool waitingForAnswer;

	private String chosenAnswer;

	public Text toDelete;

	public Text text;

	public Text Input1;
	public Text Input2;
	public Text Input3;

	int lineIndex = 0;
	int conversationIndex = 0;

	static private List<String> text0 = new List<String>{
		"Bienvenue dans le test de Turing.",
		"Un interrogateur va vous poser des questions et votre but est de répondre le plus humainenement possible.",
		"A la fin, il devra décider si vous êtes un humain ou une machine...",
		"Pour sélectionner votre réponse, appuyez sur la touche 1, 2 ou 3 !",
		"Bon courage !",
		"\n",
		"Je vais commencer par une question facile : ",
		"Comment vous appelez-vous ?"
	};

	static private List<String> answer0 = new List<String>{
		"Jeanne",
		"Terminator",
		"Franck"
	};


	static private List<String> text1 = new List<String>{
		"Joli nom!",
		"Quel âge avez-vous ?"
	};

	static private List<String> answer1 = new List<String>{
		"10",
		"20",
		"30"
	};

	static private List<List<String>> conversations = new List<List<String>>{text0, text1};
	List<String> conversation;

	static private List<List<String>> answers = new List<List<String>>{answer0, answer1};

	void Start(){
		StartCoroutine (Waiting());
		conversation = conversations [conversationIndex]; 
	}

	void Update(){
		if (waitingForAnswer) {
            if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown("1"))
				recordAnswer (Input1.text.Substring (3));
            if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown("2"))
				recordAnswer (Input2.text.Substring (3));
            if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown("3"))
				recordAnswer (Input3.text.Substring (3));
		}
	}

	void UpdateText(){
		if (lineIndex < conversation.Count) {
			StartCoroutine (AnimateText (conversation [lineIndex]));
			lineIndex++;
		} else {
			Answer ();
		}
	}

	void Answer(){
		text.text = text.text + "\n> ";
		Input1.text = "1: " + answers [conversationIndex] [0];
		Input2.text = "2: " + answers [conversationIndex] [1];
		Input3.text = "3: " + answers [conversationIndex] [2];
		waitingForAnswer = true;
	}

	void recordAnswer(String answer){
		StartCoroutine(AnimateText (answer, false));
		CleanAnswer ();
		waitingForAnswer = false;
		NextText ();
	}

	void NextText(){
		if (conversationIndex + 1  < conversations.Count) {
			conversation = conversations [++conversationIndex]; 
			lineIndex = 0;
		}
	}

	void CleanAnswer(){
		Input1.text = "";
		Input2.text = "";
		Input3.text = "";
	}

	IEnumerator Waiting()
	{
		yield return new WaitForSeconds (1F);
		UpdateText ();
	}

	IEnumerator AnimateText(string strComplete, bool newLine=true){
		int i = 0;
		if (newLine){
			text.text = text.text + "\n";
		}
		while( i < strComplete.Length ){
			text.text = text.text + strComplete[i++];
			yield return new WaitForSeconds(0.05F);
		}
		StartCoroutine( Waiting());
	}
}
