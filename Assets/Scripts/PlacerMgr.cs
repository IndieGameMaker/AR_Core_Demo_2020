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
        TrackableHitFlags filter = TrackableHitFlags.PlaneWithinPolygon 
                                    | TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(touch.position.x, touch.position.y, filter, out hit))
        {
            //앵커 생성
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);
            //증강시킬 객체 생성
            GameObject _mummy = Instantiate(mummy, hit.Pose.position, Quaternion.identity, anchor.transform);
        }

        
    }
}
