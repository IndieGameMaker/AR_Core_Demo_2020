using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyCtrl : MonoBehaviour
{
    public Transform targetTr;
    private Transform tr;

    void Start()
    {
        targetTr = GameObject.Find("First Person Camera").GetComponent<Transform>();
        tr = transform;
    }

    void Update()
    {
        //목적지로 회전
        Vector3 dir = targetTr.position - tr.position;     
        //쿼터니언 타입으로 변환
        Quaternion rot = Quaternion.LookRotation(dir);
        //부드럽게 회전 Slerp
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * 3.0f);
        //직진 이동
        tr.Translate(Vector3.forward * Time.deltaTime * 0.2f);

    }
}
