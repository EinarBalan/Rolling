using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLevel : MonoBehaviour {
    CameraScroll cameraScroll;
    PlayerScript playerScript;
    public GameObject player;
    AudioSource music;
    public GameObject cam;
    public GameObject button;
    public Sprite play; public Sprite pause;
    public bool isPaused = false;
    public Image pauseUI; public Image playUI; public Image adUI;



    // Use this for initialization
    void Start()
    {
        cameraScroll = cam.GetComponent<CameraScroll>();
        music = player.GetComponent<AudioSource>();
        playerScript = player.GetComponent<PlayerScript>();
    }




    public void Pause()
    {
        if (Time.timeScale != 0 && !playerScript.isDone)
        {
            

            Time.timeScale = 0;
            isPaused = true;
            cameraScroll.shouldMove = false;
            pauseUI.gameObject.SetActive(true);
            playUI.gameObject.SetActive(false);
            button.GetComponent<Image>().sprite = play;

            
        }
        else if (Time.timeScale == 0 && !playerScript.isDone)
        {
           
            Time.timeScale = 2f;
            isPaused = false;
            cameraScroll.shouldMove = true;
            playUI.gameObject.SetActive(true);
            pauseUI.gameObject.SetActive(false);
            button.GetComponent<Image>().sprite = pause;

        }

    }
}
