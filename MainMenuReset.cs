using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuReset : MonoBehaviour {

    MainMenuPlayer mainMenuPlayer;
    public GameObject player;

    void Start ()
    {
        mainMenuPlayer = player.GetComponent<MainMenuPlayer>();
        mainMenuPlayer.environment = gameObject;
    }
    void Update () {
        transform.Translate(new Vector3(-1, 0, 0) * 1.5f * Time.deltaTime);
    }

    public void Reset ()
    {
        Destroy(gameObject);
    }

  

   
}
