using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleted : MonoBehaviour
{
    [SerializeField]
    GameObject inputWindow;

    private void LoadNewLevel()
    {
        Time.timeScale = 0f;
        inputWindow.SetActive(true);
    }
}
