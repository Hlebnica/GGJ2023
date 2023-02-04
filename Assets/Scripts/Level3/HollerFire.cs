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


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        Debug.Log("KEK "+target.gameObject.name);
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done)
        {
            
            _event.Invoke();;
            
            other.tag = "Untagged";
            done = true;
            
            fire.SetActive(true);


        }
    }
}
