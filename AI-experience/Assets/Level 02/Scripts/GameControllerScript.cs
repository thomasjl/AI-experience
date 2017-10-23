using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControllerScript : MonoBehaviour {

	int human;
	bool waitingForAnswer;

	private String chosenAnswer;

	public Text text;

	public Text Input1;
	public Text Input2;
	public Text Input3;

	int lineIndex = 0;
	int conversationIndex = 0;

	// answer variables
	private String name;
	private int age;

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
		"Moi c'est Martin.",
		"Enchanté de faire votre connaissance !",
		"Quel âge avez-vous ?"
	};

	static private List<String> answer1 = new List<String>{
		"6",
		"22",
		"30"
	};

	static private List<String> text2 = new List<String>{
		"Le bel âge !",
		"Est-ce que tu es humain ?",
	};

	static private List<String> answer2 = new List<String>{
		"Oui !",
		"Euh... J'imagine",
		"..."
	};

	static private List<String> text3 = new List<String>{
		"Hmm, d'accord !",
		"Dis-moi, quel est le sens de la vie ?",
	};

	static private List<String> answer3 = new List<String>{
		"Je cherche encore...",
		"C'est un phénomène biologique de la naissance à la mort",
		"42."
	};

	static private List<String> text4 = new List<String>{
		"Merci pour cet éclaircissement !",
		"J'ai une devinette pour toi.",
		"J'ai 10 euros et je donne 3 euros à chacun de mes enfants.",
		"J'ai un frère, un garçon et une fille.",
		"Combien d'argent me reste-t-il ?"
	};

	static private List<String> answer4 = new List<String>{
		"7 euros",
		"1 euro",
		"42"
	};

	static private List<List<String>> conversations = new List<List<String>>{text0, text1, text2, text3, text4};
	List<String> conversation;

	static private List<List<String>> answers = new List<List<String>>{answer0, answer1, answer2, answer3, answer4};

	void Start(){
		StartCoroutine (Waiting());
		conversation = conversations [conversationIndex]; 
	}

	void Update(){
		if (waitingForAnswer) {
			if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown("1"))
				recordAnswer (Input1.text.Substring (3), 1);
			if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown("2"))
				recordAnswer (Input2.text.Substring (3), 2);
			if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown("3"))
				recordAnswer (Input3.text.Substring (3), 3);
		}

		if (text.cachedTextGenerator.lineCount >= 27) { // max = 27, delete 1st line
			text.text = text.text.Substring(text.text.IndexOf("\n")+1);
			// TODO : smooth effect
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

	void recordAnswer(String stringAnswer, int indexAnswer){
		StartCoroutine(AnimateText (stringAnswer, false));
		CleanAnswer ();
		waitingForAnswer = false;

		// treat answer
		switch (conversationIndex) {
		case 0: //name
			name = stringAnswer;
			break;
		case 1: // age
			age = int.Parse (stringAnswer);
			if (age == 6)
				human--;
			break;
		case 2: //human?
			if (indexAnswer == 3)
				human--;
			if (indexAnswer == 2)
				human++;
			break;
		case 4: //meaning of life
			if (indexAnswer == 2)
				human--;
			else
				human++;
			break;
		default:
			break;
		}

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
		yield return new WaitForSeconds (0F); //1F
		UpdateText ();
	}

	IEnumerator AnimateText(string strComplete, bool newLine=true){
		int i = 0;
		if (newLine){
			text.text = text.text + "\n";
		}
		while( i < strComplete.Length ){
			text.text = text.text + strComplete[i++];
			yield return new WaitForSeconds(0F); //0.05F
		}
		StartCoroutine( Waiting());
	}
}
