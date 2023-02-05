using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSign : MonoBehaviour
{
    public GameObject sprite;

    // Update is called once per frame
    void Update()
    {
        sprite.transform.rotation = Quaternion.LookRotation(transform.position-Camera.main.transform.position);
        sprite.transform.localPosition = new Vector3(0, Mathf.Sin(Time.time)/4f, 0);
    }
}
