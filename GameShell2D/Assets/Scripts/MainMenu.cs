using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _sceneChanger;
    private SceneChanger sceneChanger;

    public Animator _transitionImage;
    public float _transitionTime = 1f;

    InputController controls;

    public GameObject mainMenuUI;
    private bool isMainMenu = true;

    public GameObject optionsMenuUI;
    private bool isOptionsMenu = false;

    public GameObject audioMenuUI;
    private bool isAudioMenu = false;

    public GameObject quitPromptUI;
    private bool isQuitPrompt = false;

    private void Awake()
    {
        sceneChanger = _sceneChanger.GetComponent<SceneChanger>();

        controls = new InputController();

        controls.Gameplay.Pause.performed += ctx => Escape();

        _transitionImage.gameObject.SetActive(true);
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
        if (isOptionsMenu)
        {
            OptionsBack();
        }
        else if (isAudioMenu)
        {
            AudioBack();
        }
        else if (isQuitPrompt)
        {
            QuitNo();
        }
    }

    public void StartGame()
    {
        sceneChanger.NextScene(_transitionImage, _transitionTime);
    }

    public void OptionsMenuButton()
    {
        mainMenuUI.SetActive(false);
        isMainMenu = false;
        optionsMenuUI.SetActive(true);
        isOptionsMenu = true;
    }

    public void OptionsBack()
    {
        optionsMenuUI.SetActive(false);
        isOptionsMenu = false;
        mainMenuUI.SetActive(true);
        isMainMenu = true;
    }

    public void AudioMenuButton()
    {
        optionsMenuUI.SetActive(false);
        isOptionsMenu = false;
        audioMenuUI.SetActive(true);
        isAudioMenu = true;
    }

    public void AudioBack()
    {
        audioMenuUI.SetActive(false);
        isAudioMenu = false;
        optionsMenuUI.SetActive(true);
        isOptionsMenu = true;
    }

    public void QuitButton()
    {
        mainMenuUI.SetActive(false);
        isMainMenu = false;
        quitPromptUI.SetActive(true);
        isQuitPrompt = true;
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo()
    {
        quitPromptUI.SetActive(false);
        isQuitPrompt = false;
        mainMenuUI.SetActive(true);
        isMainMenu = true;
    }
}
