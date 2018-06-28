using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PlayerScript : MonoBehaviour {
    CameraScroll cameraScroll;
    PauseLevel pauseLevel;
    TimerScript timerScript;
    //AdvertisementScript advertismentScript;
    LevelCharacteristics levelCharacteristics;
    MuteAudio muteAudio;
    GameObject[] coinArray;
    public List<GameObject> coinList = new List<GameObject>();
    public AudioSource music;
    public AudioSource coinPickup;
    public AudioClip coinClip;
    public AudioLowPassFilter audioFilter;
    public Sprite checkpointActive;
    public Sprite endMarkerActive;
    public bool isGrounded = false;
    public bool isDone = false;
   // public bool isTiltControls = true;
    public Rigidbody2D player; 
    public float jumpForce = 5f; public float trampolineForce = 1.2f; public float tiltSensitivity = 22;
    public GameObject cam; 
    public GameObject UIManager;
    public int numDeaths = 0;
    public int numCoins = 0; int preCheckPtCoins = 0; public int coinListLength;
    public Text DeathsNumber; public Text CoinsNumber; public Text CoinsNumberPause; public Text TotalCoinsText;  public Text Header;
    public Image Pause;
    public Vector3 playerPosition; public Vector3 camPosition;
    public Vector2 jumpDirection = new Vector2(0, 1);






    // Use this for initialization
    void Start () {
        TotalCoinsText.text = PlayerPrefs.GetInt("TotalCoins").ToString();

        cameraScroll = cam.GetComponent<CameraScroll>();
        pauseLevel = UIManager.GetComponent<PauseLevel>();
        timerScript = UIManager.GetComponent<TimerScript>();
        //advertismentScript = UIManager.GetComponent<AdvertisementScript>();
        muteAudio = UIManager.GetComponent<MuteAudio>();
        levelCharacteristics = UIManager.GetComponent<LevelCharacteristics>();

        if (levelCharacteristics.isGravitySwitch)
        {
            jumpDirection = Vector2.left;
            levelCharacteristics.GravitySwitch();

        }




        coinArray = GameObject.FindGameObjectsWithTag("Coin");
         coinListLength = coinArray.Length;
         for (int x = 0; x < coinListLength; x++)
         {
             coinList.Add(coinArray[x]);
         }

        

         playerPosition = player.transform.position; camPosition = cam.transform.position;
         music.Pause();

          
    }

    bool IsPointerOverGameObject(int fingerId)
    {
        EventSystem eventSystem = EventSystem.current;
        return (eventSystem.IsPointerOverGameObject(fingerId)
            && eventSystem.currentSelectedGameObject != null);
    }

    // Update is called once per frame
    void Update () {


        /*if (PlayerPrefs.GetInt("TotalDeaths") != 0 && numDeaths != 0)
        {
            advertismentScript.ShowAd(false);
        }
        */

        if (cameraScroll.isTouched && !music.isPlaying)
        {
            music.Play();
        }

        if (!cameraScroll.isTouched)
        {
            music.Pause();
        }

        if (pauseLevel.isPaused)
        {
            audioFilter.cutoffFrequency = 1500;
        }

        if (!pauseLevel.isPaused)
        {
            audioFilter.cutoffFrequency = 22000;

        }



        if (Input.touchCount > 0  || Input.GetKey(KeyCode.Space))
        {
            if (Input.GetTouch(0).phase != TouchPhase.Ended)
            {
               if (!IsPointerOverGameObject(0) && isGrounded && !pauseLevel.isPaused && !isDone)
                {
                    player.velocity = jumpDirection * jumpForce;
                }
               
            }
        }
        
        if (levelCharacteristics.isGravitySwitch)
        {
            if (!pauseLevel.isPaused && !isDone && cameraScroll.isTouched)
            {

                player.velocity = new Vector2(player.velocity.x, Input.acceleration.x * tiltSensitivity);

            }
        
            /*else if (!pauseLevel.isPaused)
            {
                if (Input.touchCount == 1)
                {


                    player.transform.position = new Vector2 (player.transform.position.x, cam01.ScreenToWorldPoint(Input.GetTouch(0).position).y);


                   
    



                }
                else if (Input.touchCount > 1 && isGrounded)
                    player.velocity = jumpDirection * jumpForce;

            }
            */
        }
 
        if (!isDone && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseLevel.Pause();
        }
}


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "FloorTouch")
        {
            isGrounded = true;
        }

    }
    void OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.tag == "Obstacle")
        {
            SetPlayer(true);

        }

        if (col.gameObject.tag == "CameraStop")
        {
            cameraScroll.shouldMove = false;
        }

        if (col.gameObject.tag == "Trampoline")
        {
            if (levelCharacteristics.isGravitySwitch)
            {
                player.velocity = new Vector2(player.velocity.x, -player.velocity.y * (trampolineForce * 2));
            }
            else
                player.velocity = -player.velocity * trampolineForce;
            }
        if (col.gameObject.tag == "TrampolineConsec")
            {
                if (levelCharacteristics.isGravitySwitch)
                {
                    player.velocity = -player.velocity;
                }
                else
                {
                    player.velocity = -player.velocity;
                }
        }
        if (col.gameObject.tag == "Checkpoint")
        {
            col.gameObject.GetComponent<SpriteRenderer>().sprite = checkpointActive;
            SetPlayer(false);
        }

        if (col.gameObject.tag == "Goal")
        {
            isDone = true; Time.timeScale = 0;
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + numCoins); TotalCoinsText.text = PlayerPrefs.GetInt("TotalCoins").ToString(); 
            col.gameObject.GetComponent<SpriteRenderer>().sprite = endMarkerActive;
            timerScript.isActive = false;
            Header.text = "Finished";
            pauseLevel.pauseUI.gameObject.SetActive(true);
            Pause.gameObject.SetActive(false);
            pauseLevel.playUI.gameObject.SetActive(false);
            pauseLevel.adUI.gameObject.SetActive(true);



        }

        if (col.gameObject.tag == "Coin")
        {
            coinPickup = gameObject.AddComponent<AudioSource>(); coinPickup.clip = coinClip; coinPickup.volume = .6f; coinPickup.Play();
            Destroy(coinPickup, 1);
            col.gameObject.SetActive(false);
            numCoins ++;

            if (CoinsNumber.text != null)
            {
                CoinsNumber.text = numCoins.ToString();
                CoinsNumberPause.text = numCoins.ToString();

            }
        }
      
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "FloorTouch")
        {
            isGrounded = false;

        }
    }

    
 


   public void SetPlayer(bool isDeath)
    {
        coinListLength = coinList.Count;

        if (isDeath && levelCharacteristics.isGravitySwitch && !levelCharacteristics.isInfinite)
        {
            music.Pause();
            
            player.transform.position = playerPosition; cam.transform.position = camPosition; player.velocity = Vector3.zero; player.angularVelocity = 0f;

            numDeaths += 1; PlayerPrefs.SetInt("TotalDeaths", PlayerPrefs.GetInt("TotalDeaths") + 1);
            DeathsNumber.text = numDeaths.ToString(); 
            

            cameraScroll.shouldMove = false;
            cameraScroll.isTouched = false;

            numCoins = 0;
            numCoins += preCheckPtCoins;
            if (CoinsNumber.text != null)
            {
                CoinsNumber.text = numCoins.ToString();
                CoinsNumberPause.text = numCoins.ToString();

            }
            for (int x = 0; x < coinListLength; x++)
            {
                if (coinList[x].activeSelf != true)
                    coinList[x].SetActive(true);
            }

        }
        else if (isDeath && !levelCharacteristics.isGravitySwitch && !levelCharacteristics.isInfinite)
        {

            music.Pause();

            cam.transform.position = camPosition; player.transform.position = playerPosition; player.velocity = Vector3.zero; player.angularVelocity = 0f;

            numDeaths += 1; PlayerPrefs.SetInt("TotalDeaths", PlayerPrefs.GetInt("TotalDeaths") + 1);
            DeathsNumber.text = numDeaths.ToString();
            

            cameraScroll.shouldMove = false;
            cameraScroll.isTouched = false;

            numCoins = 0;
            numCoins += preCheckPtCoins;
            if (CoinsNumber.text != null)
            {
                CoinsNumber.text = numCoins.ToString();
                CoinsNumberPause.text = numCoins.ToString();
            }
            for (int x = 0; x < coinListLength; x++)
            {
                if (coinList[x].activeSelf != true && coinList[x] != null)
                    coinList[x].SetActive(true);
            }

        }

        if (isDeath && levelCharacteristics.isInfinite)
        {
            PlayerPrefs.SetInt("TotalDeaths", PlayerPrefs.GetInt("TotalDeaths") + 1);
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + numCoins);
            pauseLevel.Pause(); 
            Header.text = "You Died";
            Pause.gameObject.SetActive(false); pauseLevel.adUI.gameObject.SetActive(true);
        }
        else
        {
            playerPosition = player.transform.position; camPosition = cam.transform.position;

            preCheckPtCoins = numCoins;
            for (int x = 0; x < coinListLength; x++)
            {
                if (coinList[x].activeSelf != true)
                    coinList.RemoveAt(x);
            }
        }
    }

   
}
