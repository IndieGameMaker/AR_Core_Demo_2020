using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

public class SessionMgr : MonoBehaviour
{
    public Text sessionInfo;

    void Start()
    {
        StartCoroutine(UpdateUI());
    }
    
    string tmp = "";

    IEnumerator UpdateUI()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);


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
                    DisplayLostReason();
                    break;
            }
            sessionInfo.text = tmp;   
        } 
    }

    void DisplayLostReason()
    {
        //string tmp = "";
        if (Session.Status == SessionStatus.LostTracking)
        {
            switch (Session.LostTrackingReason)
            {
                case LostTrackingReason.InsufficientLight:
                    tmp += " Too Dark !!";
                    break;
                case LostTrackingReason.InsufficientFeatures:
                    tmp += " Less Feature Points !!!";
                    break;
            }
        }
        //sessionInfo.text = tmp;
    }

}
