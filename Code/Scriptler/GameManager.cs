using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public int score1=0;
    public Text Score;
    public Text livesText;
    public Text leftTime;
    public Text Second;
    public float sec = 3;
    public float timeleft = 60;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticle;
    public static GameManager instance = null;

    public GameObject enemy;

    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    bool b4 = false;
    bool b5 = false;


    public GameObject[] Array = new GameObject[5];    

    private GameObject clonePaddle;

    public void SetScore()
    {
        Score.text = "Score :" + score1;
    }

    public void Awake()
    {
        

        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        Setup();
    }
    void Update() 
    {
        if(GameObject.FindWithTag("BrickTag1") == null && b1 == false)
        {
            b1 = true;
            Instantiate(enemy, new Vector3(-6, 7, -6), Quaternion.identity);
            

        }
        if (GameObject.FindWithTag("BrickTag2") == null && b2 == false )
        {
            b2 = true;
            Instantiate(enemy, new Vector3(-3, 7, -6), Quaternion.identity);
           
        }
        if (GameObject.FindWithTag("BrickTag3") == null && b3 == false)
        {
            b3 = true;
            Instantiate(enemy, new Vector3(0, 7, -6), Quaternion.identity);
         
        }
        if (GameObject.FindWithTag("BrickTag4") == null && b4 == false)
        {
            b4 = true;
            Instantiate(enemy, new Vector3(3, 7, -6), Quaternion.identity);
           
        }
        if (GameObject.FindWithTag("BirckTag5") == null && b5 == false)
        {
            b5 = true;
            Instantiate(enemy, new Vector3(6, 7, -6), Quaternion.identity);
            
        }

        sec -= Time.deltaTime;
        Second.text = "" + (int)sec;
        if (sec < 0)
        {
            Second.text = "Start";
            Second.text = "";
            timeleft -= Time.deltaTime;
            leftTime.text = "Time Left :" + (int)timeleft;
            if (timeleft < 0)
            {
                loseLife();
                CheckGameOver();
            }
        }
        
    }


    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void loseLife()
    {
        lives--;  
        livesText.text = "Lives :" + lives;
        Instantiate(deathParticle, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        score1 = score1+20;
        SetScore();
        CheckGameOver();

    }
   
}
