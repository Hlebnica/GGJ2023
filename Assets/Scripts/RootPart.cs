using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPart : MonoBehaviour
{
    public int id = 0;
    public Transform model;
    public Transform pointer;
    public Transform end;
    public Rigidbody rb;
    public CapsuleCollider _collider;


    public RootPart next = null;
    public RootPart prev = null;


    public FixedJoint linkJoint;
    public Collider linkedObject;

    public Vector3? savedAnchor = null;

    public static bool grab = false;
    public GameObject grabber;

    public static RootPart lastRootPart;

    public void LinkObject(Collider obj, Vector3? newAnchor)
    {
        UnlinkObject();
        // Debug.Log("LINK " + (linkJoint != null) + " " + name);
        var joint = gameObject.AddComponent<FixedJoint>();
        joint.massScale = 0.1f;

        joint.connectedBody = obj.attachedRigidbody;
        joint.autoConfigureConnectedAnchor = false;
        if (newAnchor == null)
            savedAnchor = joint.connectedAnchor;
        else
        {
            savedAnchor = newAnchor;
            joint.connectedAnchor = newAnchor.Value;
        }

        linkJoint = joint;
        linkedObject = obj;
        obj.gameObject.layer = 6;
    }

    public void UnlinkObject()
    {
        // Debug.Log("UNLINK " + (linkJoint != null) + " " + name);
        if (linkJoint != null)
        {
            savedAnchor = null;
            linkedObject.gameObject.layer = 0;
            Destroy(linkJoint);
            linkJoint = null;
            linkedObject = null;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (!grab) return;
        if (linkJoint != null) return;
        if (collision.CompareTag("Clawable"))
            LinkObject(collision, null);
    }


    private void Start()
    {
        if (prev == null) lastRootPart = this;
        rb = GetComponent<Rigidbody>();
    }


    public RootPart CreateNextPart(Vector3 targetPos)
    {
        var nextPart = Instantiate(BugFix.staticRootPartPrefab);
        nextPart.transform.rotation = Quaternion.LookRotation(targetPos - transform.position);
        nextPart.transform.position = end.position;
        nextPart.GetComponent<Joint>().connectedBody = rb;
        var nextPartRootPart = nextPart.GetComponent<RootPart>();
        next = nextPartRootPart;
        next.prev = this;
        next.grabber = grabber;
        nextPartRootPart.id = id + 1;

        lastRootPart = nextPartRootPart;
        return nextPartRootPart;
    }


    private void OnDestroy()
    {
        lastRootPart = prev;
        if (next != null) next.prev = null;
        if (prev != null) prev.next = null;
    }

    void Update()
    {
        if (!grab && linkedObject != null) UnlinkObject();

        if (next == null && prev != null)
        {
            grabber.transform.position = pointer.transform.position;
            if (linkedObject == null)
                grabber.transform.rotation = pointer.transform.rotation;
            else
                grabber.transform.rotation =
                    Quaternion.LookRotation(linkedObject.transform.position - transform.position);
        }

        if (_collider != null)
            _collider.isTrigger = next == null;

        if (linkJoint != null)
        {
            // Debug.Log(model.transform.localScale.x);
            linkJoint.connectedAnchor = savedAnchor.Value-(pointer.position - transform.position);
            // (Vector3.back * model.transform.localScale.z);
        }
    }
}
