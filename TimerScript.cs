using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour {

    public bool isActive = true;
    public int minutes = 0;
    public float seconds = 0;
    public Text timerText; public Text pauseTimerText;
    public string secondsText;
    public GameObject cam;
    public GameObject UIManager;
    CameraScroll cameraScroll;
    PauseLevel pauseLevel;

	// Use this for initialization
	void Start () {
        cameraScroll = cam.GetComponent<CameraScroll>();
        pauseLevel = UIManager.GetComponent<PauseLevel>();

    }

    // Update is called once per frame
    void Update () {
        if (cameraScroll.isTouched && !pauseLevel.isPaused && isActive)
        {
            seconds += (Time.deltaTime * .5f);
            if (seconds >= 60)
            {
                minutes += 1;
                seconds = 0;
            }

            if (seconds < 10)
                secondsText = "0" + ((int)seconds).ToString();
            else
                secondsText = ((int)seconds).ToString();

            timerText.text = minutes.ToString() + ":" + secondsText;
            pauseTimerText.text = minutes.ToString() + ":" + secondsText;


        }
    }
}
