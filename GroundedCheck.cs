using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour {

    PlayerScript playerScript;
    public GameObject player;

    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Primary")
        {
            playerScript.isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Primary")
        {
            playerScript.isGrounded = false;
        }
    }
}
