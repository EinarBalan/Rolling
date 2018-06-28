using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ThemeChange : MonoBehaviour {

    public Color primary = new Color(50f, 50f, 50f);
    public Color secondary = new Color(50f, 50f, 50f);
    public Color tertiary = new Color(50f, 50f, 50f);
    public Camera cam;
    GameObject[] primaryObjects;
    GameObject[] secondaryObjects;
    GameObject[] tertiaryObjects;
    GameObject[] UIObjects;
    GameObject[] UIText;
   

    public bool ManualOveride = false;
    public bool isUI = false;
    public bool isUIText = false;
    public bool isPrimary = false;
    public bool isSecondary = false;
    public bool isTertiary = false;
    

	// Use this for initialization
	void Start()
    {
        if (!ManualOveride)
        {
            primaryObjects = GameObject.FindGameObjectsWithTag("Primary");
            secondaryObjects = GameObject.FindGameObjectsWithTag("Secondary");
            tertiaryObjects = GameObject.FindGameObjectsWithTag("Tertiary");
            UIObjects = GameObject.FindGameObjectsWithTag("UI");
            UIText = GameObject.FindGameObjectsWithTag("UIText");

            

            cam = Camera.main;
            cam.backgroundColor = secondary;

            for (int x = 0; x < primaryObjects.Length; x++)
            {
                primaryObjects[x].GetComponent<SpriteRenderer>().color = primary;
            }
            for (int x = 0; x < secondaryObjects.Length; x++)
            {
                secondaryObjects[x].GetComponent<SpriteRenderer>().color = secondary;
            }
            for (int x = 0; x < tertiaryObjects.Length; x++)
            {
                tertiaryObjects[x].GetComponent<SpriteRenderer>().color = tertiary;
            }

            for (int x = 0; x < UIObjects.Length; x++)
            {
                UIObjects[x].GetComponent<Image>().color = tertiary;
            }

            for (int x = 0; x < UIText.Length; x++)
            {
                UIText[x].GetComponent<Text>().color = tertiary;
            }

        }

        if (ManualOveride)
        {
            if (isPrimary)
                if (isUI)
                    gameObject.GetComponent<Image>().color = primary;
                else if (isUIText)
                    gameObject.GetComponent<Text>().color = primary;
                else
                    gameObject.GetComponent<SpriteRenderer>().color = primary;

            else if (isSecondary)
                if(isUI)
                    gameObject.GetComponent<Image>().color = secondary;
                else if (isUIText)
                    gameObject.GetComponent<Text>().color = secondary;
                else
                    gameObject.GetComponent<SpriteRenderer>().color = secondary;

            else if (isTertiary)
                if (isUI)
                    gameObject.GetComponent<Image>().color = tertiary;
                else if (isUIText)
                    gameObject.GetComponent<Text>().color = tertiary;
                else
                    gameObject.GetComponent<SpriteRenderer>().color = tertiary;


        }
    }
}
