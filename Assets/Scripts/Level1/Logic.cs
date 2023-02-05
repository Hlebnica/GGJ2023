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

    public int s = 0;

    public Transform[] rot;
    public Transform[] arot;
    public void inc()
    {
        s++;


        switch (s)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                StartCoroutine(Anim());
                break;
        }
    }

    // private void Start()
    // {
    //     StartCoroutine(Anim());
    // }

    IEnumerator Anim()
    {
        dim.SetActive(true);
        float startTime = Time.time;

        float t=0;
        while (true)
        {
            t += Time.deltaTime;
            

            foreach (var r in rot)
            {
                var rr=r.rotation;
                // rr.
                rr.eulerAngles= Vector3.right*t * 90;
                r.rotation = rr;
            }
            foreach (var r in arot)
            {
                var rr=r.rotation;
                rr.eulerAngles= Vector3.right*t * -90;
                r.rotation = rr;
            }
            
           if (Time.time - startTime > 5)
               SceneManager.LoadScene("Level2");
            yield return null;
        }

        
    }

}
