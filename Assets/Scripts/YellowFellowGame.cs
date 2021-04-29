using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YellowFellowGame : MonoBehaviour
{
    [SerializeField]
    GameObject highScoreUI;

    [SerializeField]
    GameObject mainMenuUI;

    [SerializeField]
    GameObject gameUI;

    [SerializeField]
    GameObject winUI;

    [SerializeField]
     Fellow playerObject;

    [SerializeField]
    GameObject inputWindow;

    
    public GameObject cutsceneUI;


    GameObject[] pellets;

    public Animator animateCamera;
    public static bool isCutSceneOn;

    public GameObject completeLevelUI;
    


    enum GameMode
    {
        InGame,
        MainMenu,
        HighScores,
        Cutscene
    }

    GameMode gameMode = GameMode.MainMenu;

 

    // Start is called before the first frame update
    void Start()
    {
        string nname = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;
        if (nname == "Level1")
        {
            
            StartMainMenu();
        } else
        {
            
           
            Cutscene();



        }


        pellets = GameObject.FindGameObjectsWithTag("Pellet");
    }

  



    // Update is called once per frame
    void Update()
    {
        switch(gameMode)
        {
            case GameMode.MainMenu:     UpdateMainMenu(); break;
            case GameMode.HighScores:   UpdateHighScores(); break;
            case GameMode.InGame:       UpdateMainGame(); break;
            case GameMode.Cutscene:     UpdateCutscene(); break;
        }

        if(playerObject.PelletsEaten() == pellets.Length)
        {
            
            completeLevelUI.SetActive(true);
            Debug.Log("Game Over");
           
         
        }

        if (playerObject.dead)
        {
            Time.timeScale = 0f;
            inputWindow.SetActive(true);
            Debug.Log("Wanna save your score!");
        }
    }

  

    void UpdateMainMenu()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            StartHighScores();
        }
    }

    void UpdateHighScores()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartMainMenu();
        }
    }

    void UpdateCutscene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void UpdateMainGame()
    {
       // playerObject
    }

    void StartMainMenu()
    {
        gameMode                        = GameMode.MainMenu;
        mainMenuUI.gameObject.SetActive(true);
        highScoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
    }


    void StartHighScores()
    {
        gameMode                = GameMode.HighScores;
        mainMenuUI.gameObject.SetActive(false);
        highScoreUI.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
    }

    void StartGame()
    {

        gameMode                = GameMode.InGame;
        Time.timeScale = 1f;
        mainMenuUI.gameObject.SetActive(false);
        highScoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        cutsceneUI.gameObject.SetActive(false);
    }

    void Cutscene()
    {
        gameMode                    = GameMode.Cutscene;
        mainMenuUI.gameObject.SetActive(false);
        highScoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        
    }


}
