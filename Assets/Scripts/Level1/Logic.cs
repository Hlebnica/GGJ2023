using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public Holler a;
    public Holler b;
    public Holler c;

    public int s = 0;

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
                SceneManager.LoadScene("Level2");
                break;
        }
    }

}
