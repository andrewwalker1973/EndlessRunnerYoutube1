using UnityEngine;
using Cinemachine;


// This script allows for the camera to be posioned facing the side of the player
// and then chnage to follow when the game starts
public class CameraSwitcher : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera StandingCamera;   // The Side camera
    [SerializeField] private CinemachineVirtualCamera FollowCamera;     // The follow camera
    [SerializeField] private CinemachineVirtualCamera LowFollowCamera;     // The follow camera  / try to slide under obstalkce

    public void SwitchPriority()                    // Function to change the priprit of the camera, higher is active camera
    {
        if (StandingCamera)                         // is we are standing camera, switch to follow
        {
            FollowCamera.Priority = 1;              // Set follow as higher priproty
            StandingCamera.Priority = 0;            // Lower standing camera protiry
            LowFollowCamera.Priority = 0;
        }
        
    }
    public void IntoSlideCamera()
    {
        LowFollowCamera.Priority = 1;
        FollowCamera.Priority = 0;
    }

    public void ExitSlideCamera()
    {
        FollowCamera.Priority = 1;
        LowFollowCamera.Priority = 0;
    }

}
