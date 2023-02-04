using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HollerCrystal : MonoBehaviour
{

    public GameObject target;
    public UnityEvent _event;
    public bool done = false;

    public Rigidbody ore;

    public GameObject Blocker;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        Debug.Log("KEK "+target.gameObject.name);
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done)
        {
            
            _event.Invoke();;
            
            other.tag = "Untagged";
            done = true;
            Destroy(Blocker);
            Destroy(GetComponent<BoxCollider>());
            ore.constraints = RigidbodyConstraints.None;


        }
    }
}
