using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Holler : MonoBehaviour
{
    public Transform toPalace;

    public GameObject target;
    public UnityEvent _event;
    public bool done = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done)
        {
            
            _event.Invoke();;
            var rb = other.attachedRigidbody;
            rb.transform.position = toPalace.position;
            rb.transform.rotation = toPalace.rotation;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            other.tag = "Untagged";
            done = true;
        }
    }
}
