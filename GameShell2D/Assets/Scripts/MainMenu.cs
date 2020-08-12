using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Animator transitionImage;
    float transitionTime = 1f;
    public void StartGame()
    {
        SceneChanger.NextScene(/*transitionImage, transitionTime*/);

        // Attempting to call the corouting here since it wasn't working in the SceneChanger script due to NextScene() being static
        //SceneChanger sc = new SceneChanger();
        //StartCoroutine(sc.SceneTransition(SceneManager.GetActiveScene().buildIndex + 1, transitionImage, transitionTime));

    }
}
