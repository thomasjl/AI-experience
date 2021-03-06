using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

	int human;
	bool waitingForAnswer;
	bool over;

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
		"Un interrogateur va vous poser des questions et votre but est de répondre le plus humainement possible.",
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
		"Moi c'est Marine.",
		"Enchantée de faire votre connaissance !",
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
		"Non! Je suis une licorne!",
		"Non! Je suis un dragon!"
	};

	static private List<String> text3 = new List<String>{
		"Hmm, d'accord !",
		"Dis-moi, quel est le sens de la vie ?",
	};

	static private List<String> answer3 = new List<String>{
		"Je cherche encore !",
		"nf: Etat d'activité caractéristique de tous les organismes animaux et végétaux, unicellulaires ou pluricellulaires, de leur naissance à leur mort.",
		"42."
	};

	static private List<String> text4 = new List<String>{
		"Merci pour cet éclaircissement !",
		"J'ai une devinette pour toi.",
		"J'ai 15 euros et je donne 3 euros à chacun de mes enfants.",
		"J'ai un frère, un garçon et une fille.",
		"Combien d'argent me reste-t-il ?"
	};

	static private List<String> answer4 = new List<String>{
		"9 euros",
		"12 euros",
		"6 euros"
	};

	static private List<String> text5 = new List<String>{
		"D'accord...",
		"Quelques questions un peu plus difficiles maintenant.",
		"J'espère que tu es prêt.",
		"Puex-tu lrie totue ctete phsrae snas le mrdonie pomlèrbe ?"
	};

	static private List<String> answer5 = new List<String>{
		"Oui.",
		"Non.",
		"Comment ? Pouvez-vous reformuler ?"
	};

	static private List<String> text6 = new List<String>{
		"Maintenant un petit problème, pour te chauffer les neurones, ou le processeur :",
		"La phrase suivante est fausse. La phrase précédente est fausse. Est-ce que la phrase précédente est vraie ?"
	};

	static private List<String> answer6 = new List<String>{
		"Oui.",
		"Bip. Bip. Boom ! Reboot system...",
		"Ni oui, ni non ! Comme le chat de Shrödinger."
	};

	static private List<String> text7 = new List<String>{
		"Et enfin, on va tester ta mémoire :",
		"Comment est-ce que je m'appelle ?"
	};

	static private List<String> answer7 = new List<String>{
		"Martin.",
		"Marine.",
		"Marie."
	};


	static private List<List<String>> conversations = new List<List<String>>{
		text0, 
		text1, 
		text2, 
		text3, 
		text4,
		text5,
		text6,
		text7
	};

	static private List<List<String>> answers = new List<List<String>>{
		answer0, 
		answer1, 
		answer2, 
		answer3, 
		answer4,
		answer5,
		answer6,
		answer7
	};

	List<String> conversation;

	void Start(){
		StartCoroutine (Waiting());
		conversation = conversations [conversationIndex]; 
		Cursor.visible = false;
	}

	void Update(){

		if (waitingForAnswer) {
			if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown("1") || Input.GetKeyDown(KeyCode.Alpha1) || Input.inputString == "1")
				recordAnswer (Input1.text.Substring (3), 1);
			if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown("2") || Input.GetKeyDown(KeyCode.Alpha2) || Input.inputString == "2")
				recordAnswer (Input2.text.Substring (3), 2);
			if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown("3") || Input.GetKeyDown(KeyCode.Alpha3) || Input.inputString == "3")
				recordAnswer (Input3.text.Substring (3), 3);
		}

		if (text.cachedTextGenerator.lineCount >= 27) { // max = 27, delete 1st line
			text.text = text.text.Substring(text.text.IndexOf("\n")+1);
			// TODO : smooth effect
		}

		if (over && (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter))) {
			if (over) {
				if (human > 0) {
					GlobalVariables.nextLevel = "Level 07";
					GlobalVariables.previousLevel = "Level 02";
					SceneManager.LoadScene ("Level Transition");
				} else {
					SceneManager.LoadScene ("Level 02");
				}
			}
		}
	}

	void UpdateText(){
		if (lineIndex < conversation.Count) {
			StartCoroutine (AnimateText (conversation [lineIndex]));
			lineIndex++;
		} else {
			if (!over)
				Answer ();
			else{
				if (human > 0) {
					StartCoroutine (AnimateText ("Je pense que tu es humain. Tu peux passer au niveau suivant en appuyant sur Entrée.", true, true));
				}
				if (human < 0) {
					StartCoroutine (AnimateText ("Je t'ai percé à jour IA ! Recommence le niveau pour t'améliorer à te faire passer pour un humain en appuyant sur Entrée.", true, true));
				}
				if (human == 0) {
					StartCoroutine (AnimateText ("Je n'arrive pas à décider. Es-tu un ciborg ? Recommence le niveau pour t'améliorer à te faire passer pour un humain en appuyant sur Entrée.", true, true));
				}
			}
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
			//if (indexAnswer == 3)
			//	human--;
			//if (indexAnswer == 2)
			//	human++;
			break;
		case 3: //meaning of life
			if (indexAnswer == 2)
				human--;
			else
				human++;
			break;
		case 4: //calcul
			if (indexAnswer == 1)
				human++;
			else
				human--;
			break;
		case 5: //typoglycemia
			if (indexAnswer == 1)
				human++;
			else
				human--;
			break;
		case 6: //paradox
			if (indexAnswer == 3)
				human++;
			else
				human--;
			break;
		case 7: //what's my name?
			if (indexAnswer == 1)
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
		if (conversationIndex + 1 < conversations.Count) {
			conversation = conversations [++conversationIndex]; 
			lineIndex = 0;
		} else {
			over = true;
		}
	}

	void CleanAnswer(){
		Input1.text = "";
		Input2.text = "";
		Input3.text = "";
	}

	IEnumerator Waiting()
	{
		yield return new WaitForSeconds (1F); //1F
		UpdateText ();
	}

	IEnumerator AnimateText(string strComplete, bool newLine=true, bool stop=false){
		int i = 0;
		if (newLine){
			text.text = text.text + "\n";
		}
		while( i < strComplete.Length ){
			text.text = text.text + strComplete[i++];
			yield return new WaitForSeconds(0.05F); //0.05F
		}
		if (!stop)
			StartCoroutine( Waiting());
	}
}
