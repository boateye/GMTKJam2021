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
    public GameObject optionsMenuUI;
    public GameObject audioMenuUI;
    public GameObject quitPromptUI;

    private void Awake()
    {
        sceneChanger = _sceneChanger.GetComponent<SceneChanger>();

        controls = new InputController();

        controls.Gameplay.Pause.performed += ctx => Escape();

        _transitionImage.gameObject.SetActive(true);
    }


    private void Escape()
    {

    }

    public void StartGame()
    {
        sceneChanger.NextScene(_transitionImage, _transitionTime);
    }

    public void OptionsMenuButton()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void OptionsBack()
    {
        optionsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void AudioMenuButton()
    {
        optionsMenuUI.SetActive(false);
        audioMenuUI.SetActive(true);
    }

    public void AudioBack()
    {
        audioMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void QuitButton()
    {
        mainMenuUI.SetActive(false);
        quitPromptUI.SetActive(true);
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo()
    {
        quitPromptUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
