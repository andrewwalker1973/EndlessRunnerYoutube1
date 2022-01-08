using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera StandingCamera;
    [SerializeField] private CinemachineVirtualCamera FollowCamera;

    public void SwitchPriority()
    {
        Debug.Log("IN function");
        if (StandingCamera)
        {
            FollowCamera.Priority = 1;
            StandingCamera.Priority = 0;
        }
        else
        {
            FollowCamera.Priority = 0;
            StandingCamera.Priority = 1;
        }

    }

    public void FollowCamerA()
    {
        Debug.Log("Hellol");
        FollowCamera.Priority = 0;
        StandingCamera.Priority = 1;
    }
}
