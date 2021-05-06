using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField]
    GameObject GameUI;

    [SerializeField]
    GameObject RulesUI;

    

    enum GameMode
    {
        InGame,
        MainMenu,
        
    }

    GameMode gameMode = GameMode.MainMenu;

    void Start()
    {
        Time.timeScale = 0f;
        StartMainMenu();

    }

    // Update is called once per frame
    void Update()
    {
        switch (gameMode)
        {
            case GameMode.MainMenu: UpdateMainMenu(); break;
            case GameMode.InGame: UpdateMainGame(); break;
        }

    }

    void UpdateMainMenu()
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
        gameMode = GameMode.MainMenu;
        RulesUI.gameObject.SetActive(true);       
        GameUI.gameObject.SetActive(false);
    }

    void StartGame()
    {

        gameMode = GameMode.InGame;
        Time.timeScale = 1f;
        RulesUI.gameObject.SetActive(false);
        GameUI.gameObject.SetActive(true);
      
    }
}
