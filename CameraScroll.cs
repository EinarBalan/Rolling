using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

    public float camSpeed = 7f;
    public float multiplierInfinite = 10f;
    public bool isTouched = false;
    public bool shouldMove = true;
    AudioSource music;
    public Transform cam;
    public GameObject UIManager;
    public GameObject player;
    PauseLevel pauseLevel;
    PlayerScript playerScript;




    // Use this for initialization
    void Start () {
        pauseLevel = UIManager.GetComponent<PauseLevel>();
        playerScript = player.GetComponent<PlayerScript>();
        music = player.GetComponent<AudioSource>();

        Time.timeScale = 2f;

    }
	
	// Update is called once per frame

    
	void Update () {

        if (Input.touchCount > 0)
        {
            if (!pauseLevel.isPaused)
            {
                isTouched = true;
                shouldMove = true;

            }
        }

        if (isTouched && shouldMove)
        {
            cam.Translate(camSpeed * Time.deltaTime, 0, 0);


        }

        if (playerScript.isDone)
        {
            camSpeed = 0;
        }

        
    }

    
}

