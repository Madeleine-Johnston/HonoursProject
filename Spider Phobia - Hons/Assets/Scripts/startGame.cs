using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void Start()
    {
        TextCanvas.SetActive(false);
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void StartAboutLevel()
    {
        SceneManager.LoadScene("About the Game");
    }

    public void StartRelaxTipLevel()
    {
        SceneManager.LoadScene("RelaxationTips");
    }

    public void StartStage2()
    {
        SceneManager.LoadScene("Stage_2");
    }

    public void StartStage3()
    {
        SceneManager.LoadScene("Stage_3");
    }

    public void StartStage4()
    {
        SceneManager.LoadScene("Stage_4");
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public GameObject Canvas;
    public GameObject TextCanvas;

    public void Display()
    {

      TextCanvas.SetActive(false);

    }

    public void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            TextCanvas.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextCanvas.SetActive(false);
        }
        if (Input.GetKeyDown("tab"))
        {
            SceneManager.LoadScene("Stage_4");
            TextCanvas.SetActive(false);
        }

    }

    //private bool showHelp = false;

    //void OnGUI()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        if (!showHelp) showHelp = true;
    //        else showHelp = false;
    //    }

    //    if (showHelp)
    //    {
    //        GUI.Box(new Rect(-98, 127, 0, 0), "Level Information");
    //    }
    //}

}


