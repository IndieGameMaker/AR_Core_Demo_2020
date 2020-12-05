using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PlaneDetect : MonoBehaviour
{
    public GameObject tiger;
    private Transform arCamera;

    private Ray ray;
    private RaycastHit hitInfo;
    private bool isActiveCanvas = false;

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

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (UnityEngine.Physics.Raycast(ray.origin, ray.direction, out hitInfo,  10.0f,  1<<8))
        {
            GameObject hitObj = hitInfo.collider.gameObject;
            hitObj.transform.Find("Canvas").gameObject.SetActive(true);
            /*
                GameObject.Find("") : 하이러키 뷰 루트에서 부터 전체 검색
                GameObject.transform.Find("Canvas") : 해당 트랜스폼의 하위에 있는 게임오브젝트를 검색
            */
        }
    }
}
