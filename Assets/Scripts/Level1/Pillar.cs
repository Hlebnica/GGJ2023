using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public Holler hooll;
    public Bridge bridge;
    public Collider BarrelCollider;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            bridge.GO();
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(20,0,0), ForceMode.Impulse);
            rb.constraints = RigidbodyConstraints.None;
            StartCoroutine(BarrelRoll());
        }
    }

    IEnumerator BarrelRoll()
    {
        yield return new WaitForSeconds(4);
        hooll.OnTriggerEnter(BarrelCollider);

    }
}
