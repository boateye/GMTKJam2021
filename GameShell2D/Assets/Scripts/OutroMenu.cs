using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroMenu : MonoBehaviour
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

    public void Yes()
    {
        sceneChanger.ChangeScene(1, _transitionImage, _transitionTime);
    }

    public void No()
    {
        sceneChanger.ChangeScene(0, _transitionImage, _transitionTime);
    }
}
