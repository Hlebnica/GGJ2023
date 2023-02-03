using System;
using UnityEngine;

public class BugFix : MonoBehaviour
{
    //https://forum.unity.com/threads/prefab-with-reference-to-itself.412240/
    //обходим багу юнити

    public GameObject rootPartPrefab;
    public static GameObject staticRootPartPrefab;

    private void Start()
    {
        staticRootPartPrefab = rootPartPrefab;
    }


}
