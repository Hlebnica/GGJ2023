using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HollerStick : MonoBehaviour
{

    public GameObject target;
    public UnityEvent _event;
    public bool done = false;

    public GameObject fire;

    public HollerFire fireHoller;

    public AudioSource fire1;
    public AudioSource fire2;


    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        // Debug.Log("KEK "+target.gameObject.name);
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done && fireHoller.done)
        {
            
            _event.Invoke();
            
            done = true;
            fire.SetActive(true);
            
            StartCoroutine(StartAnim.SoundFade(fire1, -1, 0, 1f));
            StartCoroutine(StartAnim.SoundFade(fire2, 0, 0.2f, 1f));
        }
    }
}
