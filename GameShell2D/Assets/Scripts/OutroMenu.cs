using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroMenu : MonoBehaviour
{
    public GameObject _sceneChanger;
    private SceneChanger sceneChanger;

    private void Awake()
    {
        sceneChanger = _sceneChanger.GetComponent<SceneChanger>();
    }

    public void Restart()
    {
        sceneChanger.ChangeScene(0);
    }
}
