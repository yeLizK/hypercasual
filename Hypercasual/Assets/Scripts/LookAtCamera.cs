using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera MainCamera;

    private void Start()
    {
        MainCamera = Camera.main;
        transform.LookAt(MainCamera.transform);
    }
}
