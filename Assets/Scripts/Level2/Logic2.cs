using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class Logic2 : MonoBehaviour
{
    public int s = 0;
    public GameObject[] ores;

    public Transform left;
    public Transform right;

    
    public AudioSource m0;
    public AudioSource m1;
    public AudioSource m2;
    public AudioSource m3;
    
    // public GameObject allOre;
    public GameObject door;
    public AudioSource minicard;
    
    public GameObject od0;
    public GameObject od1;
    public GameObject od2;
    public GameObject boi;
    
    
    
    
    
    public void inc()
    {
        s++;
        var v = 0.3f;

        switch (s)
        {
            case 1:
                StartCoroutine(StartAnim.SoundFade(m0, -1, 0, 1f));
                StartCoroutine(StartAnim.SoundFade(m1, 0, v, 1f));
                od0.SetActive(true);
                
                
                
                break;
            case 2:
                StartCoroutine(StartAnim.SoundFade(m1, -1, 0, 1f));
                StartCoroutine(StartAnim.SoundFade(m2, 0, v, 1f));
                od1.SetActive(true);
                break;
            case 3:
                StartCoroutine(StartAnim.SoundFade(m2, -1, 0, 1f));
                StartCoroutine(StartAnim.SoundFade(m3, 0, v, 1f));
                od2.SetActive(true);
                door.SetActive(true);
                StartCoroutine(StartAnim.SoundFade(minicard, 0, v, 1f));
                StartCoroutine(Anim());
                
                break;
        }
    }

    IEnumerator Anim()
    {
        float startTime = Time.time;

        while (startTime + 2 > Time.time)
        {
            var rotl = left.rotation;
            rotl.eulerAngles = Vector3.down * (Mathf.Min(1, Time.time - startTime))*90;
            left.rotation = rotl;

            var rotr = right.rotation;
            rotr.eulerAngles = Vector3.up * (Mathf.Min(1, Time.time - startTime))*90;
            right.rotation = rotr;
            foreach (var ore in ores)
            {
                var pos = ore.transform.position;
                pos.x += Time.deltaTime*4;
                ore.transform.position = pos;
            }

            yield return null;
        }

        yield return new WaitForSeconds(2);
        SceneChanger.instance.ChangeScene("Level3");
    }

}
