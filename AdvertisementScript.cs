using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine;

/*public class AdvertisementScript : MonoBehaviour


{

    PlayerScript playerScript;
    PauseLevel pauseLevel;
    public GameObject player; public GameObject canvas;
    string deaths;
    bool adPlayed = false;
    public Text FailedAd;


    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        pauseLevel = GetComponent<PauseLevel>();

    }

    public void ShowAd(bool isRewardAd)
    {
        deaths = PlayerPrefs.GetInt("TotalDeaths").ToString();

        if (!isRewardAd)
        {

            if (deaths.EndsWith("0"))
            {
                if (!adPlayed)
                {
                    Advertisement.Show();
                    adPlayed = true;
                    if (Advertisement.isShowing)
                    {
                        canvas.SetActive(false);
                    }
                    else
                    {
                        canvas.SetActive(true);
                    }


                }

            }

            else if (deaths.EndsWith("1"))
            {
                adPlayed = false;
            }

        }

        if (isRewardAd)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("rewardedVideo");
                pauseLevel.adUI.gameObject.SetActive(false);

                if (Advertisement.isShowing)
                {
                    adPlayed = true;
                    canvas.SetActive(false);
                }
                else
                {
                    canvas.SetActive(true);
                }


                playerScript.numCoins *= 2; playerScript.CoinsNumberPause.text = playerScript.numCoins.ToString(); PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + (playerScript.numCoins / 2)); playerScript.TotalCoinsText.text = PlayerPrefs.GetInt("TotalCoins").ToString();
            }
            else {
                FailedAd.gameObject.SetActive(true);
            }
        }
    }
}
*/