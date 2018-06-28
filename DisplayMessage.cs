using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayMessage : MonoBehaviour {

    public Text text;

	// Use this for initialization
	public void Display(string message)
    {
        text.text = message;
        text.gameObject.SetActive(true);
    }
}
