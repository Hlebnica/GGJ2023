using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HollerFire : MonoBehaviour
{

    public GameObject target;
    public UnityEvent _event;
    public bool done = false;

    public GameObject fire;


    public AudioSource m0;
    public AudioSource fire1;

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        // Debug.Log("KEK "+target.gameObject.name);
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done)
        {
            
            _event.Invoke();;
            
            other.tag = "Untagged";
            done = true;
            
            fire.SetActive(true);
            
            

            StartCoroutine(StartAnim.SoundFade(m0, -1, 0, 1f));
            StartCoroutine(StartAnim.SoundFade(fire1, 0, 0.2f, 1f));
        }
    }
}
