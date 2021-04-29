using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class inputWindow : MonoBehaviour
{
    
    public TMP_InputField userName;
    public int userScore;
    public HighScoreTable inputUserScore;
    public Fellow getScore;
    


 

    public void InputUser()
    {
        
        if (getScore.dead)
        {
            userScore = getScore.currentScore;
            

            using (StreamWriter file = File.AppendText(inputUserScore.highscoreFile))
            {
                file.WriteLine(userName.text + ' ' + userScore);

                SceneManager.LoadScene("Level1");
            }
        }
        else
        {
            Debug.Log("No dead, bad code");
        }

      
    }

    public void cancelInput()
    {
        SceneManager.LoadScene("Level1");
    }





}
