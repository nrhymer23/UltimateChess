using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public static int mode = 0;
    public static int pieceSelection;
    public GameObject[] PieceOption;
    private int currentPiece;
    public GameObject pickModetext;
    float time = 0f;

    public static bool QuickmodeEnabled = false;


    public AudioMixer audioMixer;


    public void Update()
    {
        time -= 1 * Time.deltaTime;
        if ((pickModetext != null) && (time <= 0f))
        {
            pickModetext.SetActive(false);
        }

        for (int i = 0; i < PieceOption.Length; i++)
        {
            if (i == currentPiece)
            {
                PieceOption[i].SetActive(true);
            }
            else
            {
                PieceOption[i].SetActive(false);
            }

        }


    }

    // Update is called once per frame
    public void SceneSwitcher()
    {
        if (Input.GetKeyDown("S"))
        {
            Play();
        }
        /*if(Input.GetKeyDown(KeyCode.O))
        {
            Options();
        }
        /*if(Input.GetKeyDown(KeyCode.H))
        {
            Help();
        }*/
        if (Input.GetKeyDown(KeyCode.M))
        {
            Mode();
        }
        /*if(Input.GetKeyDown(KeyCode.C))
        {
            Customization();
        }
        */

        
    }

    public void Play()
    {
       
        switch (mode)
        {
            case 0:
                pickModetext.SetActive(true);
                time = 3f;
                break;
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
            default:
                Debug.Log("You Must Choose a Mode");
                break;

        }
        

    }

    public void switchpieces()
    {
        if (currentPiece == PieceOption.Length - 1)
        {
            currentPiece = 0;
        }
        else
        {
            currentPiece++;
        }
        pieceSelection = currentPiece;
    }



    public void Mode()
    {
        //open mode menu
       
    }
    public void Mode0()
    {
        

        if (mode == 0)
        {
            pickModetext.SetActive(true);
            time = 3f;
        }
        if (time == 0f)
        {
            pickModetext.SetActive(false);
        }

    }

    public void Mode1()
    {
        mode = 1;
    }

    public void Mode2()
    {
        mode = 2;
    }

    public void Mode3()
    {
        mode = 3;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void quickMode()
    {
        if(QuickmodeEnabled == false)
        {
            QuickmodeEnabled = true;
        }
        else
        {
            QuickmodeEnabled = false;
        }
         
    }
}
