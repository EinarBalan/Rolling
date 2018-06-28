using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSettings : MonoBehaviour {
    public GameObject settingsUI; public Sprite exitSprite; Sprite settingSprite; public Text DeathsText;
    public GameObject buttonSettings;
    

    public void Settings()
    {
        settingsUI.SetActive(!settingsUI.activeSelf);
        PlayerPrefs.SetInt("TotalDeaths", PlayerPrefs.GetInt("TotalDeaths"));
        DeathsText.text = PlayerPrefs.GetInt("TotalDeaths").ToString();
    }

    void Start ()
    {
        settingSprite = buttonSettings.GetComponent<Image>().sprite;
    }
    void Update ()
    {
        if (settingsUI.activeSelf)
        {
            buttonSettings.GetComponent<Image>().sprite = exitSprite;
            if (Input.GetKey(KeyCode.Escape))
                settingsUI.SetActive(!settingsUI.activeSelf);
        }
        if (!settingsUI.activeSelf)
        {
            buttonSettings.GetComponent<Image>().sprite = settingSprite;
        }


    }
}
