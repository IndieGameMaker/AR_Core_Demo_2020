using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

public class MeasureMgr : MonoBehaviour
{
    public GameObject markArrow;
    public Text lenText;

    //레이캐스트 충돌한 지점의 정보
    private TrackableHit hit;
    //검출대상 설정
    private TrackableHitFlags flags = TrackableHitFlags.Default;
    //터치 갯수
    private int tapCount = 0;
    //첫번째 터치한 좌표
    private Vector3 firstPos = Vector3.zero;


    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (Input.touchCount < 1 || touch.phase != TouchPhase.Began) return;

        if (tapCount == 2) return;

        //Arrow 생성하는 루틴
        //레이캐스팅
        if (Frame.Raycast(touch.position.x, touch.position.y, flags, out hit))
        {
            //터치 횟수를 증가
            ++tapCount;

            //앵커를 생성 Pose = x, y, z 위치와 각도
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);
            //앵커 하위에 Arrow 생성
            Instantiate(markArrow, hit.Pose.position, Quaternion.identity, anchor.transform);

            if (firstPos != Vector3.zero && tapCount == 2)
            {
                //길이 계산 & 출력
                DisplayLength(firstPos, hit.Pose.position);
            }
            
            firstPos = anchor.transform.position;
        }
    }

    void DisplayLength(Vector3 prevPos, Vector3 currPos)
    {
        //Vector3.Distance(a, b)  --> a, b간의 거리
        float length = Vector3.Distance(prevPos, currPos);
        lenText.text = length.ToString("000.00") + "m";
    }

    public void OnInitMarker()
    {
        GameObject[] makers = GameObject.FindGameObjectsWithTag("MARKER");
        foreach(var _maker in makers)
        {
            Destroy(_maker);
        }

        firstPos = Vector3.zero;
        tapCount = 0;
        lenText.text = "0.0m";
    }
}
