using System;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 7)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

}
