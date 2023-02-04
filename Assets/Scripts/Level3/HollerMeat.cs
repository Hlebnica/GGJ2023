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


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        Debug.Log("KEK "+target.gameObject.name);
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done && pterHoller.done)
        {
            
            _event.Invoke();;
            dineHoller.SetActive(true);
            
            
            
            done = true;
            Destroy(GetComponent<BoxCollider>());
            // var rb = other.attachedRigidbody;
            dino.transform.position = toPlace.position;
            Debug.LogError(toPlace.position);
            dino.transform.rotation = toPlace.rotation;

        }
    }
}
