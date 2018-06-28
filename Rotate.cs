using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    LevelCharacteristics levelCharacteristics;
    public GameObject UIManager;
    public float speed = 30;
    public bool ManualOveride = false;
	void Start ()
    {
        levelCharacteristics = UIManager.GetComponent<LevelCharacteristics>();
    }

    // Update is called once per frame
    void Update () {
        if (levelCharacteristics.isGravitySwitch && !ManualOveride)
            transform.Rotate(new Vector3(1f, 0f, 0f) * Time.deltaTime * speed);
        else
            transform.Rotate(new Vector3(0f, 0f, 1f) * Time.deltaTime * speed);


    }
}
