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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
