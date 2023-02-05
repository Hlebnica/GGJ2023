using System;
using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class EndAnim : MonoBehaviour
{
    public Transform cameraTargetStart;
    public Transform cameraStart;
    public Transform cameraTargetEnd;
    public Transform cameraEnd;

    public Vector3 VcameraTargetStart;
    public Vector3 VcameraStart;
    public Vector3 VcameraTargetEnd;
    public Vector3 VcameraEnd;
    public float Ssize;


    private Transform _camera;
    private Camera _cameraC;
    public Transform _cameraTarget;

    public float maxSizeEnd;

    private Vector3 startCameraPos;
    private Vector3 endCameraPos;

    public Rigidbody fist;
    public Rigidbody building;
    public GameObject treeTarget;
    public GameObject treeTargetEnd;
    public Vector3 VtreeTargetStart;
    public Vector3 VtreeTargetEnd;

    public Transform end;
    
    
    public AudioSource A1;
    public GameObject punch;
    public GameObject rot;
    public AudioSource A2;
    


    private void Start()
    {
        VcameraTargetStart = cameraTargetStart.position;
        VcameraStart = cameraStart.position;
        VcameraTargetEnd = cameraTargetEnd.position;
        VcameraEnd = cameraEnd.position;

        VtreeTargetStart = treeTarget.transform.position;
        VtreeTargetEnd = treeTargetEnd.transform.position;

        

        _cameraC = Camera.main;
        Ssize = _cameraC.orthographicSize;

        _camera = Camera.main.GameObject().transform;
        StartCoroutine(TOTALANIM());
    }

    IEnumerator TOTALANIM()
    {
        
        yield return Anim(1.5f, VcameraStart, VcameraTargetStart, VcameraEnd,
            VcameraTargetEnd, 2, Ssize, maxSizeEnd);
        StartCoroutine(StartAnim.SoundFade(A1, -1, 0, 1f));


        yield return new WaitForSeconds(1.6f);
        rot.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        yield return RotateAnim(3);
        yield return new WaitForSeconds(1f);
        building.isKinematic = false;
        fist.isKinematic = false;
        fist.AddForce((end.position-transform.position)*10, ForceMode.VelocityChange);
        punch.SetActive(true);
        
        StartCoroutine(StartAnim.SoundFade(A2, 0, 0.1f, 1f));
    }

    IEnumerator RotateAnim( float l)
    {
        float t = 0;
        while (t < l)
        {
            t += Time.deltaTime;
            var dn = t / l;
            treeTarget.transform.position = Vector3.Lerp(VtreeTargetStart, VtreeTargetEnd, dn);
            yield return null;
        }
    }
    
    
    IEnumerator Anim(float delay, Vector3 cs, Vector3 cts, Vector3 ce, Vector3 cte, float l, float fs, float fe)
    {
        yield return new WaitForSeconds(delay);
        float t = 0;
        while (t < l)
        {
            t += Time.deltaTime;
            var dn = t / l;
            _camera.position = Vector3.Lerp(cs, ce, dn);
            _cameraTarget.position = Vector3.Lerp(cts, cte, dn);
            _cameraC.orthographicSize = Mathf.Lerp(fs, fe, dn);
            yield return null;
        }
    }
}
