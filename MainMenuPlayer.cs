using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour {
    MainMenuReset reset;
    public GameObject environment;
    public float jumpForce;
    public float trampolineForce;
    Vector3 startpos;


    // Use this for initialization
    void Start() {
        startpos = environment.transform.position;
        reset = environment.GetComponent<MainMenuReset>();
        
    }

	
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Jump")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * jumpForce;
        }

        if (col.gameObject.tag == "Trampoline")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = -gameObject.GetComponent<Rigidbody2D>().velocity * trampolineForce;
        }

        if (col.gameObject.tag == "Append")
        {
           
            Instantiate(environment, new Vector3(startpos.x + 6.5f, startpos.y, startpos.z), transform.rotation);
        }

        if (col.gameObject.tag == "Destroy")
        {
            reset.Reset();
            reset = environment.GetComponent<MainMenuReset>();

        }
    }
}
