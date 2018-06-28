using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorPlatform : MonoBehaviour {

    LevelGenerator levelGenerator;
    CameraScroll cameraScroll;
    public GameObject player;

    void Start()
    {
        //levelGenerator = player.GetComponent<LevelGenerator>();
        //cameraScroll = Camera.main.GetComponent<CameraScroll>();
        //levelGenerator.environment = gameObject; //cameraScroll.environment02 = gameObject;
    }

   void Update()
    {
        

    }

    public void DestroyPlatform()
    {
        Destroy(gameObject);
    }


}
