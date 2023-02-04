using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Transform anchor;
    private bool go = false;

    IEnumerator Anim()
    {
        var startTime = Time.time;
        var delta = Time.time - startTime;
        while (delta < 1f)
        {
            delta = Time.time - startTime;

            var rot = transform.rotation;
            rot.eulerAngles = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -30.95f), delta);
            transform.rotation = rot;
            yield return null;
        }

        Destroy(this);
    }

    public void GO()
    {
        if (!go)
        {
            go = true;
            StartCoroutine(Anim());
        }
    }

}
