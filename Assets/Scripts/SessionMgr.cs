using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

public class SessionMgr : MonoBehaviour
{
    public Text sessionInfo;

    // Update is called once per frame
    void Update()
    {
        string tmp = "";

        switch (Session.Status)
        {
            case SessionStatus.Initializing:
                tmp = "Initializing...";
                break;
            case SessionStatus.Tracking:
                tmp = "Tracking...";
                break;
            case SessionStatus.LostTracking:
                tmp = "Lost Tracking!!!";
                break;
        }
        sessionInfo.text = tmp;    
    }

}
