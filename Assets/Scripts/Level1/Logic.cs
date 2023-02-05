using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public Holler a;
    public Holler b;
    public Holler c;
    public GameObject dim;
    public GameObject water;

    public int s = 0;

    public Transform[] rot;
    public Transform[] arot;
    
    
    public AudioSource m0;
    public AudioSource m1;
    public AudioSource m2;
    public AudioSource m3;

    public void inc()
    {
        s++;

        var v = 0.3f;
        switch (s)
        {
            case 1:
                StartCoroutine(StartAnim.SoundFade(m0, -1, 0, 1f));
                StartCoroutine(StartAnim.SoundFade(m1, 0, v, 1f));
                break;
            case 2:
                StartCoroutine(StartAnim.SoundFade(m1, -1, 0, 1f));
                StartCoroutine(StartAnim.SoundFade(m2, 0, v, 1f));
                break;
            case 3:
                water.SetActive(true);
                StartCoroutine(StartAnim.SoundFade(m2, -1, 0, 1f));
                StartCoroutine(StartAnim.SoundFade(m3, 0, v, 1f));
                StartCoroutine(Anim());
                break;
        }
    }

 

    IEnumerator Anim()
    {
        dim.SetActive(true);
        float startTime = Time.time;


        float t = 0;
        while (true)
        {
            t += Time.deltaTime;


            foreach (var r in rot)
            {
                var rr = r.rotation;
                // rr.
                rr.eulerAngles = Vector3.right * t * 90;
                r.rotation = rr;
            }

            foreach (var r in arot)
            {
                var rr = r.rotation;
                rr.eulerAngles = Vector3.right * t * -90;
                r.rotation = rr;
            }

            if (Time.time - startTime > 5)
                SceneChanger.instance.ChangeScene("Level2");
            yield return null;
        }
    }

}
