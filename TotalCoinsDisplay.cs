using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TotalCoinsDisplay : MonoBehaviour {

    public Text coinsText;
    public Text secondaryCoinsText;

	// Use this for initialization
	void Start () {
        coinsText.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        secondaryCoinsText.text = PlayerPrefs.GetInt("TotalCoins").ToString();
                
    }


}
