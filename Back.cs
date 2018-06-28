using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Back : MonoBehaviour {
    public string level;
    public GameObject settingsUI;

    // Update is called once per frame
    void Update () {
       
		if (Input.GetKey(KeyCode.Escape))
        {
                SceneManager.LoadScene(level);
        }
	}
}
