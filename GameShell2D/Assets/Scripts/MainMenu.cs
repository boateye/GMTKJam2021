using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _sceneChanger;
    private SceneChanger sceneChanger;

    public Animator transitionImage;
    public float transitionTime = 1f;

    private void Awake()
    {
        sceneChanger = _sceneChanger.GetComponent<SceneChanger>();
    }

    public void StartGame()
    {
        sceneChanger.NextScene(transitionImage, transitionTime);
    }
}
