using System.Collections;
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
        if (touch.tapCount < 1 || touch.phase != TouchPhase.Began) return;

        TrackableHit hit;
        TrackableHitFlags flag = TrackableHitFlags.Default;

        if (Frame.Raycast(touch.position.x, touch.position.y, flag, out hit))
        {
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

            GameObject _tiger = Instantiate(tiger, hit.Pose.position, Quaternion.identity, anchor.transform);
            Quaternion rot = Quaternion.LookRotation(arCamera.position - hit.Pose.position);
            _tiger.transform.rotation = Quaternion.Euler(arCamera.position.x,
                                                         rot.eulerAngles.y,
                                                         arCamera.position.z);
        }
    }
}
