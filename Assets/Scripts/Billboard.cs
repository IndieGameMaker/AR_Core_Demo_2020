using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform arCamera;

    void Start()
    {
        arCamera = GameObject.Find("First Person Camera").GetComponent<Transform>();        
    }

    void LateUpdate()
    {
        transform.LookAt(arCamera.position);
    }
}
