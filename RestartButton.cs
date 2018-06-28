using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {
    LevelCharacteristics levelCharacteristics;
    public GameObject UIManager;
    

    void Start()
    {
        levelCharacteristics = UIManager.GetComponent<LevelCharacteristics>();
    }

    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LevelChange(string level)
    {
        /*if (levelCharacteristics.isGravitySwitch)
            Physics2D.gravity = new Vector2(9.81f, 0);
        else if (!levelCharacteristics.isGravitySwitch)
            Physics2D.gravity = new Vector2(0, -9.81f); */

        Time.timeScale = 2;
        SceneManager.LoadScene(level);
    }

}
