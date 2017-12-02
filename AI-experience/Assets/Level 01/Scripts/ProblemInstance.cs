using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class ProblemInstance {


	public string text_to_decode = "";
	public string encoded_text = "";
	public int[] rotors_values = new int[Decoder.nb_rotors];
	public string[] enigm_texts;
	public string[] enigm_answers;
	public string[] enigm_player_answers;
	public Rotor decoder = new Rotor();
	public Rotor encoder = new Rotor();


	public ProblemInstance (string text_to_decode, int[] rotors_values, string[] enigm_texts, string[] enigm_answers) {
		this.text_to_decode = text_to_decode;
		this.rotors_values = rotors_values;
		this.decoder = this.BuildDecoder ();
		this.encoder = this.BuildEncoder ();
		this.encoded_text = this.EncodeText ();

		this.enigm_texts = enigm_texts;
		this.enigm_answers = enigm_answers;
		this.enigm_player_answers = new string[]{ "", "", "", "" };
	}

	private Rotor BuildDecoder() {
		Rotor decoder = new Rotor ();
		int decode_increment = 0;
		System.Array.ForEach (this.rotors_values, delegate(int i) { decode_increment += i; });
		decoder.UpdateRotorValues (decode_increment);
		return decoder;
	}

	private Rotor BuildEncoder(){
		Rotor encoder = new Rotor ();
		Dictionary<string, string> rotor = new Dictionary<string, string> ();
		foreach (string letter in Decoder.alphabet) {
			rotor.Add (this.decoder.GetRotor () [letter], letter);
		}
		encoder.SetRotor (rotor);
		return encoder;
	}


	private string EncodeText() {
		StringBuilder encoded_text = new StringBuilder ();
		foreach (char s in this.text_to_decode) {
			if (s == ' ')
				encoded_text.Append (s.ToString());
			else
				encoded_text.Append (this.encoder.GetRotor()[s.ToString().ToUpper()]);
		}
		return encoded_text.ToString ();
	}
}
