using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOnMouseOver : MonoBehaviour {




	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
		
	public void ChangeCursorToHand() {
		Cursor.SetCursor (GameControlLevel1.instance.hand_cursor , Vector2.zero, CursorMode.Auto);
	}

	public void ChangeCursorToNormal() {
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}

}
