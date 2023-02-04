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
    public GameObject pterModel1;
    public GameObject pterModel2;

    public GameObject meatHoller;
    
    


    IEnumerator FlyAnim()
    {
        pterModel1.SetActive(false);
        pterModel2.SetActive(true);
        while (true)
        {
            var rot = pter.transform.rotation;
            rot.eulerAngles += new Vector3(0, Time.deltaTime*90, 0);
            pter.transform.rotation = rot;
            if (pter.transform.position.y < 10)
            {
                var a =pter.transform.position; 
                a.y += Time.deltaTime;
                pter.transform.position = a;
            }

            yield return null;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done && stikHOller.done)
        {
            
            _event.Invoke();;
            
            done = true;
            meatrb.constraints = RigidbodyConstraints.None;
            // pter.SetActive(false);
            Destroy(GetComponent<BoxCollider>());
            meatHoller.SetActive(true);
            StartCoroutine(FlyAnim());

        }
    }
}
