using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    InputController controls;
    

    public GameObject pauseMenuUI;

    private void Awake()
    {
        controls = new InputController();

        

        controls.Gameplay.Pause.performed += ctx => Escape();


       controls.Gameplay.Why.started += ctx => Escape1();
        controls.Gameplay.Why.performed += ctx => Escape2();
        controls.Gameplay.Why.canceled += ctx => Escape3();
    }
    
    void Escape1()
    {
        print("Start");
    }

    void Escape2()
    {
        print("Performed");
    }

    void Escape3()
    {
        print("Cancelled");
    }

    private void Escape()
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
