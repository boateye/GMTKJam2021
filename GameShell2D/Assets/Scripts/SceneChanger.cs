using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Overload ChangeScene to allow for usage of scene name or buildID
    public void ChangeScene(string sceneName, Animator transitionImage, float transitionTime)
    {
        StartCoroutine(SceneTransition(sceneName, transitionImage, transitionTime));
    }

    public void ChangeScene(int sceneBuildID, Animator transitionImage, float transitionTime)
    {
        StartCoroutine(SceneTransition(sceneBuildID, transitionImage, transitionTime));
    }

    // Overload NextScene() to allow for a version w/ a transition.
    public void NextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextScene(Animator transitionImage, float transitionTime)
    {
        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex + 1, transitionImage, transitionTime));
    }

    public void ReloadScene(Animator transitionImage, float transitionTime)
    {
        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex, transitionImage, transitionTime));
    }

    // Coroutines to control the transition Animations.
    IEnumerator SceneTransition(int sceneBuildID, Animator transitionImage, float transitionTime)
    {
        // Play animation
        transitionImage.SetTrigger("Start");

        // Wait for animaiton to finish (would be more robust if we could set this equal to teh length of the animation) 
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(sceneBuildID);
    }

    IEnumerator SceneTransition(string sceneName, Animator transitionImage, float transitionTime)
    {
        // Play animation
        transitionImage.SetTrigger("Start");

        // Wait for animaiton to finish (would be more robust if we could set this equal to teh length of the animation) 
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(sceneName);
    }
}
