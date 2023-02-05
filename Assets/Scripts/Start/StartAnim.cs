using System;
using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class StartAnim : MonoBehaviour
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

    public GameObject l1;
    public GameObject l2;


    public AudioSource music;
    public AudioSource build;

    private void Start()
    {
        VcameraTargetStart = cameraTargetStart.position;
        VcameraStart = cameraStart.position;
        VcameraTargetEnd = cameraTargetEnd.position;
        VcameraEnd = cameraEnd.position;


        _cameraC = Camera.main;
        Ssize = _cameraC.orthographicSize;

        _camera = Camera.main.GameObject().transform;
        StartCoroutine(TOTALANIM());
    }

    IEnumerator TOTALANIM()
    {
        yield return Anim(1.5f, VcameraStart, VcameraTargetStart, VcameraEnd,
            VcameraTargetEnd, 2, Ssize, maxSizeEnd);

        yield return Anim(0.5f, VcameraEnd,
            VcameraTargetEnd, VcameraStart, VcameraTargetStart, 2, maxSizeEnd,
            Ssize);

        yield return new WaitForSeconds(0.5f);
        yield return SoundFade(music, -1, 0.1f, 0.5f);
        l1.SetActive(false);
        l2.SetActive(true);
        yield return SoundFade(build, 0, 0.18f, 0.5f);

        yield return Anim(0.5f, VcameraStart, VcameraTargetStart, VcameraEnd,
            VcameraTargetEnd, 2, Ssize, maxSizeEnd);

        yield return Anim(0.5f, VcameraEnd,
            VcameraTargetEnd, VcameraStart, VcameraTargetStart, 2, maxSizeEnd,
            Ssize);

        SceneChanger.instance.ChangeScene("Level1");
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

    public static IEnumerator SoundFade(AudioSource sound, float a, float b, float l)
    {
        float t = 0;
        if (a < 0) a = sound.volume;
        if (b < 0) b = sound.volume;
        do
        {
            t += Time.deltaTime;
            var d = t / l;


            sound.volume = Mathf.Lerp(a, b, d);
            yield return null;
        } while (t < l);

        sound.volume = b;
    }
}
