using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KEY : MonoBehaviour
{

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.sceneCount);
    }

}
