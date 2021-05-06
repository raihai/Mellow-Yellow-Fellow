using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bestScore : MonoBehaviour
{
    public HighScoreTable getBestScore;

    public Text writeHighScore;

    private void Start()
    {

        getBestScore.LoadHighScoreTable();
        getBestScore.SortHighScoreEntries();
        writeHighScore.text = "High Score:\n" + getBestScore.allScores[0].score;
    }


}
