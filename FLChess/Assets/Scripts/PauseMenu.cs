using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MainMenu
{
    public static bool Gameispaused = false;
    public GameObject Pausemenu;


    void Update()
    {

        if (Gameispaused == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        
            if (Gameispaused == false)
            {
                Time.timeScale = 1f;
                Resume();
            }
            else
            {
                Time.timeScale = 0f;
                Pause();
            }

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Quit();
        }

    }

    public void Resume()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        Gameispaused = false;
    }

    public void Pause()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0f;
        Gameispaused = true;

    }

    public void Restart()
    {
        if (mode == 1)
            SceneManager.LoadScene(1);
        else if (mode == 2)
            SceneManager.LoadScene(2);
        else if (mode == 3)
            SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        SceneManager.LoadScene(0);
        mode = 0;
        pieceSelection = 0;
        QuickmodeEnabled = false;
    }
}
