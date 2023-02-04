using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HollerPter : MonoBehaviour
{

    public GameObject target;
    public UnityEvent _event;
    public bool done = false;

    public HollerStick stikHOller;

    public Rigidbody meatrb;
    public GameObject pter;

    public GameObject meatHoller;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        Debug.Log("KEK "+target.gameObject.name);
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done && stikHOller.done)
        {
            
            _event.Invoke();;
            
            done = true;
            meatrb.constraints = RigidbodyConstraints.None;
            pter.SetActive(false);
            Destroy(GetComponent<BoxCollider>());
            meatHoller.SetActive(true);


        }
    }
}
