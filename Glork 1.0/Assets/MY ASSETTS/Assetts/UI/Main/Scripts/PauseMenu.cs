using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject PauseUI;
    public bool GamePause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        GamePause = false;

    }

    void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        GamePause = true;
    }
}
