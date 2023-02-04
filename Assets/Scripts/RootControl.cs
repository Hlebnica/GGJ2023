using System;
using System.Collections;
using UnityEngine;

public class RootControl : MonoBehaviour
{
    Vector3 GetClosestPoint(Ray ray, Vector3 point)
    {
        return ray.origin + Vector3.Project(point - ray.origin, ray.direction);
    }


    public GameObject grabber;
    public RootPart baseRootPart;

    private Coroutine currentAnimation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RootPart.grab = true;
            grabber.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            RootPart.grab = false;
            grabber.SetActive(false);
        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var pointForcer = GetClosestPoint(ray, RootPart.lastRootPart.end.transform.position);
        RootPart.lastRootPart.rb.AddForce(pointForcer.normalized * 2, ForceMode.Acceleration);

        if (Input.GetMouseButton(0) && currentAnimation == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                var part = baseRootPart;
                while (part.next != null)
                {
                    part = part.next;
                }

                var lastObj = part.linkedObject;
                var lastAnchor = part.savedAnchor;
                part.UnlinkObject();
                var p = part.CreateNextPart(hit.point);
                if (p != null)
                {
                    part = p;
                    part.savedAnchor = lastAnchor;
                    if (lastObj != null) part.LinkObject(lastObj, lastAnchor);


                    currentAnimation = StartCoroutine(InflationAnim(part, 0.3f, 10));
                }
            }
        }

        if (Input.GetMouseButton(1) && currentAnimation == null && baseRootPart.next != null)
        {
            var part = baseRootPart;
            while (part.next != null)
            {
                part = part.next;
            }

            currentAnimation = StartCoroutine(DeflationAnim(part, 0.3f, 10));
        }
    }

    private IEnumerator InflationAnim(RootPart lastPart, float t, int d)
    {
        var lastId = lastPart.id;


        var start = Time.time;
        var end = start + t;
        while (Time.time < end)
        {
            var part = lastPart;
            var dt = (t - (end - Time.time)) / t;

            while (part.prev != null)
            {
                var endScale = Mathf.Min(((float)lastId - (part.id - 1) + 1) / (d + 1), 1);
                var startScale = Mathf.Min(((float)lastId - part.id + 1) / (d + 1), 1);


                var f = Mathf.Lerp(startScale, endScale, dt);
                part.model.localScale = new Vector3(f, f, 1);
                part = part.prev;
            }

            var lastScale = lastPart.model.localScale;
            lastScale.z = dt;

            lastPart.model.localScale = lastScale;

            yield return null;
        }


        currentAnimation = null;
    }

    private IEnumerator DeflationAnim(RootPart lastPart, float t, int d)
    {
        var lastId = lastPart.id;


        var start = Time.time;
        var end = start + t;
        while (Time.time < end)
        {
            var dt = (end - Time.time) / t;

            var part = lastPart;


            while (part.prev != null)
            {
                var endScale = Mathf.Min(((float)lastId - (part.id - 1) + 1) / (d + 1), 1);
                var startScale = Mathf.Min(((float)lastId - part.id + 1) / (d + 1), 1);


                var f = Mathf.Lerp(startScale, endScale, dt);
                part.model.localScale = new Vector3(f, f, 1);
                part = part.prev;
            }

            var lastScale = lastPart.model.localScale;
            lastScale.z = dt;

            lastPart.model.localScale = lastScale;

            yield return null;
        }

        var lastyObj = lastPart.linkedObject;
        var lastyAnchor = lastPart.savedAnchor;

        lastPart.UnlinkObject();
        if (lastyObj != null)
            lastPart.prev.LinkObject(lastyObj, lastyAnchor);
        Destroy(lastPart.gameObject);
        currentAnimation = null;
    }

}
