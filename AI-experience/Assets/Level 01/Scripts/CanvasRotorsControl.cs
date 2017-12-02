using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRotorsControl : MonoBehaviour {


	public Text enigm;
	public Text answer;
	public GameControlLevel1 game_control_level_1;

	public Button button_save;

	public int current_enigm_number = 0;
	string[] enigm_texts;
	string[] enigm_answers;
	string[] enigm_player_answers;

	// Use this for initialization
	void Start () {
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
	}




	public void LoadEnigm(int enigmNumber) {
		this.current_enigm_number = enigmNumber - 1;

		this.enigm.text = "ENIGME " + enigmNumber + "\n\n";
		this.enigm.text = this.enigm.text + this.enigm_texts[this.current_enigm_number];

		this.answer.text = this.enigm_player_answers [this.current_enigm_number];
	}



	public void SaveAnswer() {
		this.enigm_player_answers [this.current_enigm_number] = this.answer.text;
		this.UpdateRotorValue ();
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