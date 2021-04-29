using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getLevel : MonoBehaviour
{
    public Text Level;

    void Start()
    {
        int currentLevel= SceneManager.GetActiveScene().buildIndex;

        Level.text = "Level:\n" + (currentLevel + 1);

    }
}
