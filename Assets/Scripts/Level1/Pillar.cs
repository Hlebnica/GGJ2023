using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public Bridge bridge;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            bridge.GO();
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(20,0,0), ForceMode.Impulse);
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
