using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickButton : MonoBehaviour {

	public Text text;

	public void onClickTest() {
		text.text = "Choix 1";
	}
}
