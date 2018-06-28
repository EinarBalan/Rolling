using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InBoundsCheck : MonoBehaviour
{
    public GameObject player;
    PlayerScript playerScript;
    public bool level = true;


    // Use this for initialization
    void Start()
    {
        if (level)
            playerScript = player.GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (level)
            {
                playerScript.SetPlayer(true);
            }
            else
            {
                Scene loadedlevel = SceneManager.GetActiveScene();
                SceneManager.LoadScene(loadedlevel.buildIndex);
            }

           
        }
    }
}