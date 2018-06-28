using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    LevelGeneratorPlatform levelGeneratorPlatform;
    CameraScroll cameraScroll;
    public GameObject trash01; public GameObject trash02;
    public GameObject environment01; public GameObject environment02;
    public GameObject genPos;
    public GameObject destroyPos;
    GameObject[] prefabs;
    public float platformLength = 30; public float distanceBetween = 0;


    // Use this for initialization
    void Start()
    {
        prefabs = Resources.LoadAll<GameObject>("Prefabs");
        cameraScroll = Camera.main.GetComponent<CameraScroll>();
        levelGeneratorPlatform = environment01.GetComponent<LevelGeneratorPlatform>();

    }



    // Update is called once per frame
    void Update()
    {
        
        if (cameraScroll.isTouched && cameraScroll.shouldMove)
        {
            if (environment02 != null && environment02.transform.position.x < genPos.transform.position.x)
            {
                if (trash02 != null)
                {
                    trash01 = trash02;
                }
                trash02 = environment01;
                environment01 = environment02;
                environment02 = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(genPos.transform.position.x + distanceBetween, genPos.transform.position.y, genPos.transform.position.z + 1), environment01.transform.rotation);

                if (transform.position.x >= genPos.transform.position.x - 30)
                {
                    genPos.transform.position += new Vector3(30f, 0, 0);
                }
            }
            if (trash01 != null)
            {
                if (trash01.transform.position.x < destroyPos.transform.position.x)
                {

                    Destroy(trash01);
                    destroyPos.transform.position += new Vector3(30f, 0, 0);

                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Append")
        {
            genPos.transform.position += new Vector3(30f, 0, 0);

        }
    }
    /*void OnTriggerEnter2D(Collider2D col)
    {
         
        if (col.gameObject.tag == "Append")
        {
            
           environment = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(startpos.x + 20f, startpos.y, startpos.z), transform.rotation);
           environment.GetComponent<LevelGeneratorPlatform>().player = gameObject;

        }

        if (col.gameObject.tag == "Destroy")
        {
            levelGeneratorPlatform.DestroyPlatform();
            //Destroy(cameraScroll.environment01); cameraScroll.environment01 = cameraScroll.environment02;
            levelGeneratorPlatform = environment.GetComponent<LevelGeneratorPlatform>();

        }
    }*/
}