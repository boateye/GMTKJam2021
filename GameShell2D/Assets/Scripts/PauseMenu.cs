using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject _sceneChanger;
    private SceneChanger sceneChanger;

    public static bool gameIsPaused = false;
    public static bool quitPrompt = false;

    InputController controls;
    
    public GameObject pauseMenuUI;
    public GameObject quitPromptUI;

    private void Awake()
    {
        sceneChanger = _sceneChanger.GetComponent<SceneChanger>();

        controls = new InputController();
        
        controls.Gameplay.Pause.performed += ctx => Escape();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Escape()
    {
        if (quitPrompt)
        {
            quitPrompt = false;
            pauseMenuUI.SetActive(true);
            quitPromptUI.SetActive(false);
        }
        else
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

    //be careful with these, Time.timescale is static it continutes to other scenes
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

    public void Outro()
    {
        Time.timeScale = 1;
        sceneChanger.NextScene();
    }

    public void MainMenu()
    {
        //This method is only used by a button in the pause menu,
        //so we have to make sure we resume the time scale.
        Time.timeScale = 1;
        sceneChanger.ChangeScene(0);
    }

    public void Quit()
    {
        quitPrompt = true;
        pauseMenuUI.SetActive(false);
        quitPromptUI.SetActive(true);
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo()
    {
        quitPrompt = false;
        pauseMenuUI.SetActive(true);
        quitPromptUI.SetActive(false);
    }
}
