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

    private void Awake()
    {
        sceneChanger = _sceneChanger.GetComponent<SceneChanger>();

        _transitionImage.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        sceneChanger.NextScene(_transitionImage, _transitionTime);
    }
}
