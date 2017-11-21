using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class GameControlLevel1 : MonoBehaviour {

	private static GameControlLevel1 instance;

	private KeyCode[] desired_keys = {
		KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, 
		KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, 
		KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, 
		KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, 
		KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};
	
	private Decoder decoder = new Decoder ();

	public Text decoded_text;
	public Text text_to_decode;

	public int rotor_one_value;
	public int rotor_two_value;
	public int rotor_three_value;
	public int rotor_four_value;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} 
		else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start() {
		ProblemInstanceFactory pif = new ProblemInstanceFactory ();
		ProblemInstance demo = pif.GetDemoProblemInstance ();
		this.text_to_decode.text = demo.encoded_text;

		// For demo
		this.UpdateDecoderRotor();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Backspace)) {
			if (this.decoded_text.text.Length > 0) {
				this.decoded_text.text = this.decoded_text.text.Substring (0, this.decoded_text.text.Length - 1);
			}
		} 
		else if (Input.GetKeyDown (KeyCode.Space)) {
			this.decoded_text.text += " ";
		}
		else {
			foreach (KeyCode key_to_check in desired_keys){
				if (Input.GetKeyDown (key_to_check)) {
					string translated_letter = this.decoder.TranslateLetterThroughRotors (key_to_check.ToString ());
					this.decoded_text.text += translated_letter;
					break;
				}		
			}
		}
	}

	void ResetTranslationTextBox() {
		this.decoded_text.text = "";
	}
		
	void UpdateRotorOneValue(int value) {
		this.rotor_one_value = value;
	}

	void UpdateRotorTwoValue(int value) {
		this.rotor_two_value = value;
	}

	void UpdateRotorThreeValue(int value) {
		this.rotor_three_value = value;
	}

	void UpdateRotorFourValue(int value) {
		this.rotor_four_value = value;
	}



	private void UpdateDecoderRotor() {
		this.decoder.UpdateDecoderRotor (this.SumUpRotorUpdateValues ());
	}

	private int SumUpRotorUpdateValues() {
		return this.rotor_one_value + this.rotor_two_value + this.rotor_three_value + this.rotor_four_value;
	}
		
}
