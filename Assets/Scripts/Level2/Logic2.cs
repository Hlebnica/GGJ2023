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

    public void inc()
    {
        s++;

        switch (s)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
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
        SceneManager.LoadScene("Level3");
    }

}
