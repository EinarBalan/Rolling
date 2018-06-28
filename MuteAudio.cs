using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MuteAudio : MonoBehaviour {

    public Button buttonMute;
    public Sprite AudioActive;
    public Sprite AudioInactive;

    void Start()
    {
        if (PlayerPrefs.GetInt("isMuted") == 1)
        {
            buttonMute.GetComponent<Image>().sprite = AudioInactive;
            AudioListener.volume = 0;
        }
        if (PlayerPrefs.GetInt("isMuted") == 0)
        {
            buttonMute.GetComponent<Image>().sprite = AudioActive;
            AudioListener.volume = 1;
        }
    }


    public void Mute()
    {
        
        if (PlayerPrefs.GetInt("isMuted") == 0)
        {
            PlayerPrefs.SetInt("isMuted", 1);
            buttonMute.GetComponent<Image>().sprite = AudioInactive;
            AudioListener.volume = 0;
        }
        else
        {
            PlayerPrefs.SetInt("isMuted", 0);
            buttonMute.GetComponent<Image>().sprite = AudioActive;
            AudioListener.volume = 1;


        }

       
    }

    
}
