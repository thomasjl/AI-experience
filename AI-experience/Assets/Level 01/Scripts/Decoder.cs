using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Decoder {

	public static int nb_rotors = 4;

	public static int rotor_size = 26;

	public static string[] alphabet = {
		"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", 
		"N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
	};

	private Rotor decoder = new Rotor();

	// Use this for initialization
	public Decoder () {}

	public void UpdateDecoderRotor (int value) {
		this.decoder.UpdateRotorValues (value);
	}


	public string TranslateLetterThroughRotors(string letter) {
		return this.decoder.GetRotor () [letter.ToUpper ()];
	}

}
