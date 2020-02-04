using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ModeSwitch : MonoBehaviour
{
    public GameObject[] Modes;
    private int currentMode;
    public static int mode;

    public void Update()
    {
        for(int i = 0; i < Modes.Length; i++)
        {
            if (i == currentMode)
            {
                Modes[i].SetActive(true);
            }
            else
            {
                Modes[i].SetActive(false);
            }

        }
    }

    public void switchmodes()
    {
        if (currentMode == Modes.Length - 1)
        {
            currentMode = 0;
        }
        else
        {
            currentMode++;
        }
         mode = currentMode;
    }

    public void back()
    {
        SceneManager.LoadScene(0);

    }
}
