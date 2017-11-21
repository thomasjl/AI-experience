using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotor {

	private Dictionary<string, string> rotor = new Dictionary<string, string>();

	// Use this for initialization
	public Rotor () {
		// At first, A=A, B=B, etc.
		foreach (string letter in Decoder.alphabet) {
			rotor.Add (letter, letter);
		}
	}

	public void UpdateRotorValues(int value_to_add) {

		List<string> keys = new List<string> (this.rotor.Keys);
		foreach(string key in keys) {
			int current_letter_index = Array.IndexOf (Decoder.alphabet, key);
			int new_letter_index = (current_letter_index + value_to_add) % Decoder.rotor_size;
			rotor [key] = Decoder.alphabet[new_letter_index] ;
		}
	}

	public Dictionary<string, string> GetRotor() {
		return this.rotor;
	}

	public void SetRotor(Dictionary<string, string> r) {
		this.rotor = r;
	}
}