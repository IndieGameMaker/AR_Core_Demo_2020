using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PlacerMgr : MonoBehaviour
{
    public Camera arCamera;
    public GameObject mummy;

    void Start()
    {
        arCamera = GameObject.Find("First Person Camera").GetComponent<Camera>();
    }

    void Update()
    {
        //첫번째 터치 정보
        Touch touch = Input.GetTouch(0);

        if (Input.touchCount < 1 || (touch.phase != TouchPhase.Began))
        {
            return;
        } 

        TrackableHit hit;
        TrackableHitFlags filter = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.FeaturePointWithSurfaceNormal;

        
        
    }
}
