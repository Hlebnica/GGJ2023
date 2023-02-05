using System;
using Unity.VisualScripting;
using UnityEngine;

public class StaticIsoCamera : MonoBehaviour
{
    public Transform target;
    private Camera _camera;
    public bool fix = false;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        
        if (fix)
        {
            var a = Quaternion.LookRotation(target.position - transform.position);
            var e = a.eulerAngles;
            e.x = 0;
            e.z = 0;
            transform.rotation = Quaternion.Euler(e);
        }
        else
        {
            
            _camera.transform.rotation = Quaternion.LookRotation(target.position - transform.position);
        }
    }
}
