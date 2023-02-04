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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        Debug.Log("KEK "+target.gameObject.name);
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
