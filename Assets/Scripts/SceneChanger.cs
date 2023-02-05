using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour

{
    public static SceneChanger instance;
    public Image image;
    private bool work=false;
    private void Start()
    {
        instance = this;
        StartCoroutine(FadeIn(1f));
    }

    public void ChangeScene(String sceneName)
    {
        if (work) return;
        work = true;
        StartCoroutine(FadeOut(1f, sceneName));
    }
    
    

    IEnumerator FadeIn(float l)
    {
        float t = 0;
        while (t < l)
        {
            // Debug.LogWarning(t);
            t += Time.deltaTime;
            var d = 1-(t / l);

            var c = image.color;
            c.a = d;
            image.color = c;
            yield return null;
        }
        var c2 = image.color;
        c2.a = 0;
        image.color = c2;
    }

    IEnumerator FadeOut(float l, string scene)
    {
        float t = 0;
        while (t < l)
        {
            // Debug.Log(t);
            t += Time.deltaTime;
            var d = t / l;

            var c = image.color;
            c.a = d;
            image.color = c;
            yield return null;
        }

        var c2 = image.color;
        c2.a = 1;
        image.color = c2;
        SceneManager.LoadScene(scene);
    }
}
