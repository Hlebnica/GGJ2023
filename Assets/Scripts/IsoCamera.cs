using System;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class IsoCamera : MonoBehaviour
{
    private Camera _camera;
    public Transform target;


    private Vector3 oldMousePos;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }


    private void Update()
    {
        _camera.transform.rotation = Quaternion.LookRotation(target.position - transform.position);

        var rot = target.transform.rotation;
        var angles = rot.eulerAngles;
        var addVertical = Vector3.right * (Input.GetAxis("Vertical") * Time.deltaTime * 40);
        var addHorizontal = Vector3.down * (Input.GetAxis("Horizontal") * Time.deltaTime * 80);
        var test = (angles + addVertical).x;
        if (test > 180) test -= 360;
        if (test > -60 && test < 60)
            rot.eulerAngles += addVertical;
        rot.eulerAngles += addHorizontal;
        target.transform.rotation = rot;
        _camera.transform.localPosition += Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 200;

        if (Input.GetMouseButton(2))
        {
            var rot2 = target.transform.rotation;
            var delta = (Input.mousePosition - oldMousePos) / 3;
            rot2.eulerAngles += new Vector3(-delta.y, delta.x, 0);
            target.transform.rotation = rot2;
        }

        oldMousePos = Input.mousePosition;
    }
}
