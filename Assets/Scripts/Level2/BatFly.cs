using System;
using UnityEngine;

public class BatFly : MonoBehaviour
{
    public float offset;

    private void Update()
    {
        var pos = transform.position;
        pos.y += Mathf.Sin(Time.time*2+offset)*Time.deltaTime;
        pos.x += Mathf.Cos(Time.time*2+offset)/1.3f*Time.deltaTime;
        transform.position = pos;
    }

}
