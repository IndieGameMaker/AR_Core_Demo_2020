﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PlaneDetect : MonoBehaviour
{
    public GameObject tiger;
    private Transform arCamera;

    void Start()
    {
        arCamera = GameObject.Find("First Person Camera").GetComponent<Transform>();        
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.tapCount == 0) return;

        TrackableHit hit;
        TrackableHitFlags flag = TrackableHitFlags.Default;

    }
}
