using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    GameObject[] music;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        music = GameObject.FindGameObjectsWithTag("Music");
        if (music.Length > 1)
        {
            Destroy(music[1]);
        }
    }

  
}
