using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger
{
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void ChangeScene(int sceneBuildID)
    {
        SceneManager.LoadScene(sceneBuildID);
    }
    // Overload NextScene() to allow for a version w/ a transition.
    public static void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void NextScene(Animator transitionImage, float transitionTime)
    {
        //StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex + 1, transitionImage, transitionTime));
    }
   public static IEnumerator SceneTransition(int sceneBuildID, Animator transitionImage, float transitionTime)
    {
        // Play animation
        transitionImage.SetTrigger("Start");

        // Wait for animaiton to finish (would be more robust if we could set this equal to teh length of the animation) 
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(sceneBuildID);
    }
}
