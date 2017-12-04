using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class GameControlLevel1 : MonoBehaviour {

	public static GameControlLevel1 instance;
	public GameObject canvasRotors; // Assign in inspector
	public GameObject canvasRoom; // Assign in inspector
	public GameObject canvasIntro; // Assign in inspector
	public GameObject canvasHelp; // Assign in inspector
	public GameObject canvasMoreInfo; // Assign in inspector

	public GameObject papier_text_to_decode; // Assign in inspector
	public GameObject papier_text_decoded; // Assign in inspector
	public GameObject feuille_explication; // Assign in inspector
	public Button intro_button;

	public Texture2D hand_cursor;

	string intro_message = "28 JUIN 1942.\n\nVOUS AVEZ MIS LA MAIN SUR UNE MACHINE D'ENCRYPTAGE ALLEMANDE ENIGMA.\n\nVOTRE MISSION EST DE L'UTILISER AFIN DE DECODER LE MESSAGE INTERCEPTE PAR LA RESISTANCE.\n\nDES VIES SONT EN JEU, FAITES VITE !";

	public ProblemInstance problem_instance;

	public AudioSource typewriter_sound;
	public AudioSource typewriter_sound_carriage_return;

	private KeyCode[] desired_keys = {
		KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, 
		KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, 
		KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, 
		KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, 
		KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};
	
	private Decoder decoder = new Decoder ();

	public Text decoded_text;
	public Text text_to_decode;
	public Text explication_text;

	public int rotor_one_value = 0;
	public int rotor_two_value = 0;
	public int rotor_three_value = 0;
	public int rotor_four_value = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} 
		else if (instance != this) {
			Destroy (gameObject);
		}
	}



	bool first_time = true;


	void Start() {
		ProblemInstanceFactory pif = new ProblemInstanceFactory ();
		this.problem_instance = pif.GetDemoProblemInstance (); 
		this.text_to_decode.text = this.problem_instance.encoded_text;

		this.SwitchToCanvasIntro ();
		StartCoroutine(this.AnimateTextInto ());
	}
	
	// Update is called once per frame
	void Update () {

		if (!this.canvasRoom.activeSelf)
			return;
		
		if (Input.GetKeyDown (KeyCode.Backspace)) {
			if (this.decoded_text.text.Length > 0) {
				this.typewriter_sound.Stop ();
				this.typewriter_sound.Play ();
				this.decoded_text.text = this.decoded_text.text.Substring (0, this.decoded_text.text.Length - 1);
			}
		} 
		else if (Input.GetKeyDown (KeyCode.Space)) {
			this.decoded_text.text += " ";
			this.typewriter_sound.Stop ();
			this.typewriter_sound.Play ();
		}
		else {
			foreach (KeyCode key_to_check in desired_keys){
				if (Input.GetKeyDown (key_to_check)) {
					this.typewriter_sound.Stop ();
					this.typewriter_sound.Play ();
					string translated_letter = this.decoder.TranslateLetterThroughRotors (key_to_check.ToString ());
					this.decoded_text.text += translated_letter;
					break;
				}		
			}
		}

		if (this.decoded_text.text == this.problem_instance.text_to_decode) {
			this.GameIsWon ();
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



	public void UpdateDecoderRotor() {
		this.decoder.UpdateDecoderRotor (this.SumUpRotorUpdateValues ());
	}

	private int SumUpRotorUpdateValues() {
		return this.rotor_one_value + this.rotor_two_value + this.rotor_three_value + this.rotor_four_value;
	}
		
	public void SwitchToCanvasRoom () {
		this.canvasRoom.SetActive (true);

		this.canvasRotors.SetActive (false);
		this.canvasIntro.SetActive (false);
		this.canvasHelp.SetActive (false);
		this.canvasMoreInfo.SetActive (false);
	}

	public void SwitchToCanvasRotors () {
		this.canvasRotors.SetActive (true);

		this.canvasRoom.SetActive (false);
		this.canvasIntro.SetActive (false);
		this.canvasHelp.SetActive (false);
		this.canvasMoreInfo.SetActive (false);
	}

	public void SwitchToCanvasIntro() {
		this.canvasIntro.SetActive (true);

		this.canvasRoom.SetActive (false);
		this.canvasRotors.SetActive (false);
		this.canvasHelp.SetActive (false);
		this.canvasMoreInfo.SetActive (false);
	}

	public void SwitchToCanvasHelp() {
		this.canvasHelp.SetActive (true);

		this.canvasRoom.SetActive (false);
		this.canvasRotors.SetActive (false);
		this.canvasIntro.SetActive (false);
		this.canvasMoreInfo.SetActive (false);
	}


	public void SwitchToCanvasMoreInfo() {
		this.canvasMoreInfo.SetActive (true);

		this.canvasRoom.SetActive (false);
		this.canvasRotors.SetActive (false);
		this.canvasIntro.SetActive (false);
		this.canvasHelp.SetActive (false);

	}


	public void ButtonContinuerAction(){
		if (this.first_time) {
			this.first_time = false;
			this.SwitchToCanvasHelp ();
		} else {
			this.SwitchToCanvasRoom ();
		}
	}

	public void MoreInformation(){
		
	}

	IEnumerator AnimateTextInto() {
		this.explication_text.text = "";
		int i = 0;
		yield return new WaitForSeconds(1F);
		while( i < this.intro_message.Length ){
			this.explication_text.text = this.explication_text.text + this.intro_message[i];

			if (this.canvasIntro.activeSelf) {
				if (this.intro_message [i] == '\n') {
					this.typewriter_sound_carriage_return.Stop ();
					this.typewriter_sound_carriage_return.Play ();
					yield return new WaitForSeconds(.7F);
				} else {
					this.typewriter_sound.Stop ();
					this.typewriter_sound.Play ();	
					yield return new WaitForSeconds(Random.Range(0.02F, 0.1F));
				}

			}
			i++;
		}
	}


	public void GameIsWon() {
		
	}
}
