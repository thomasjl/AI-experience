using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRotorsControl : MonoBehaviour {


	public Text saved_text;
	public Text enigm;
	public Text answer;
	public GameControlLevel1 game_control_level_1;

	public Button button_save;
	public Button button_help_enigm;

	public int current_enigm_number = 0;
	string[] enigm_texts;
	string[] enigm_answers;
	string[] enigm_player_answers;


	public int[] try_counter = new int[Decoder.nb_rotors];

	// Use this for initialization
	void Start () {
		this.button_help_enigm.interactable = false;
		this.saved_text.enabled = false;
		this.enigm_texts = game_control_level_1.problem_instance.enigm_texts;
		this.enigm_answers = game_control_level_1.problem_instance.enigm_answers;
		this.enigm_player_answers = game_control_level_1.problem_instance.enigm_player_answers;
		this.LoadEnigm (1);
	}

	void Update() {

		if (Input.anyKeyDown) {
			double d;
			if (double.TryParse(Input.inputString, out d)) {
				this.answer.text += Input.inputString ;
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			game_control_level_1.SwitchToCanvasRoom();
		} 
		else if (Input.GetKeyDown (KeyCode.Backspace)) {
			if (this.answer.text.Length > 0) {
				this.answer.text = this.answer.text.Substring (0, this.answer.text.Length - 1);
			}
		}


		if (this.try_counter [this.current_enigm_number] > 3) {
			this.button_help_enigm.interactable = true;
		} else {
			this.button_help_enigm.interactable = false;
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (this.saved_text.enabled) {
				this.saved_text.enabled = false;
				this.enigm.enabled = true;
			}
		}
			

	}




	public void LoadEnigm(int enigmNumber) {
		this.current_enigm_number = enigmNumber - 1;

		this.enigm.text = "énigme ".ToUpper() + enigmNumber + "\n";
		this.enigm.text = this.enigm.text + "Répondez à l'énigme pour calibrer le rotor numéro ".ToUpper() + enigmNumber + "\n\n\n";
		this.enigm.text = this.enigm.text + this.enigm_texts[this.current_enigm_number];

		this.answer.text = this.enigm_player_answers [this.current_enigm_number];
	}



	public void SaveAnswer() {
		if (this.answer.text == "") {
			string saved_message = "Vous devez répondre à l'énigme à l'aide de votre clavier avant de sauvegarder la valeur et ainsi calibrer le rotor";
			StartCoroutine (ShowSavedMessage (saved_message, 4));
		}
		else {
			this.enigm_player_answers [this.current_enigm_number] = this.answer.text;
			this.UpdateRotorValue ();
			this.try_counter [this.current_enigm_number]++;
			string saved_message = "Le rotor numéro " + (this.current_enigm_number + 1) + " a bien été calibré avec la valeur " + this.answer.text + ".";
			if (this.enigm_player_answers [this.current_enigm_number] == this.enigm_answers [this.current_enigm_number]) {
				saved_message = saved_message + "\n\n" + "PS : Ceci est la bonne réponse";
			} else {
				saved_message = saved_message + "\n\n" + "PS : Ceci n'est pas la bonne réponse";
			}
			StartCoroutine (ShowSavedMessage (saved_message, 3));
		}
	}

	IEnumerator ShowSavedMessage (string message, float delay) {
		this.saved_text.text = message;
		this.enigm.enabled = false;
		this.saved_text.enabled = true;
		yield return new WaitForSeconds(delay);
		this.saved_text.enabled = false;
		this.enigm.enabled = true;
	}


	public void GetHelpForEnigm(){
		string message = "La réponse est " + this.enigm_answers [this.current_enigm_number];
		StartCoroutine (ShowSavedMessage (message, 2));
	}


	public void UpdateRotorValue() {
		if (this.enigm_player_answers [this.current_enigm_number].Length == 0)
			return;
		
		double d;
		int rotor_value;
		if (double.TryParse (this.enigm_player_answers[this.current_enigm_number], out d)) {
			rotor_value = (int)d;
		} 
		else {
			throw new System.ArgumentException ("Answer to enigm should only be numbers");
		}


		switch (this.current_enigm_number+1) {
			case 1:
				game_control_level_1.rotor_one_value = rotor_value;
				break;
			case 2:
				game_control_level_1.rotor_two_value = rotor_value;
				break;
			case 3:
				game_control_level_1.rotor_three_value = rotor_value;
				break;
			case 4:
				game_control_level_1.rotor_four_value = rotor_value;
				break;
			default:
				throw new System.ArgumentException ("Wrong enigm number : " + this.current_enigm_number);
		}

		game_control_level_1.UpdateDecoderRotor ();
	}
}