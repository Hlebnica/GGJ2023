using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HollerMeat : MonoBehaviour
{

    public GameObject target;
    public UnityEvent _event;
    public bool done = false;

    public HollerPter pterHoller;
    
    public GameObject dino;

    public GameObject dineHoller;
    
    public Transform toPlace;
    public GameObject dinodino;

    
    
    public AudioSource normal2;
    public AudioSource dyno_eat;

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        // Debug.Log("KEK "+target.gameObject.name);
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done && pterHoller.done)
        {
            
            _event.Invoke();;
            dineHoller.SetActive(true);
            
            
            
            done = true;
            Destroy(GetComponent<BoxCollider>());
            // var rb = other.attachedRigidbody;
            // dino.transform.position = toPlace.position;
            // Debug.LogError(toPlace.position);
            StartCoroutine(Anim());
            dinodino.transform.rotation = toPlace.rotation;
            StartCoroutine(StartAnim.SoundFade(normal2, -1, 0, 1f));
            StartCoroutine(StartAnim.SoundFade(dyno_eat, 0, 0.2f, 1f));

        }
    }

    IEnumerator Anim()
    {
        var startTime = Time.time;

        var start = dinodino.transform.position; 
        while (startTime + 1 > Time.time)
        {

            dinodino.transform.position = Vector3.Lerp(start, toPlace.position, Time.time - startTime);
            
            yield return null;
        }
    }
}
