using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Yarn.Unity;

public class BonfireCutsceneCommands : MonoBehaviour
{
    public CinemachineBrain mainCamera;
    public CinemachineVirtualCamera BonfireFenCam;
    public CinemachineVirtualCamera BonfireAmosCam;
    public CinemachineVirtualCamera BonfireSnobbishCam;
    public CinemachineVirtualCamera BonfireWindyCam;
    public CinemachineVirtualCamera BonfireLieselCam;
    public CinemachineVirtualCamera BonfireHeloiseCam;
    public CinemachineVirtualCamera BonfireShrillCam;

    public float easetime = 3f;


    // Start is called before the first frame update
    void Start()
    {
        BonfireFenCam.Priority = 0;
        BonfireAmosCam.Priority = 0;
        BonfireSnobbishCam.Priority = 0;
        BonfireWindyCam.Priority = 0;
        BonfireLieselCam.Priority = 0;
        BonfireHeloiseCam.Priority = 0;
        BonfireShrillCam.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("setEaseBrain")]
    public void easeBrain()
    {
        mainCamera.m_DefaultBlend.m_Time = easetime;
    }

    [YarnCommand("switchFenBonCam")]
    public void bonswitchFen()
    {

        BonfireFenCam.Priority = 20;
        BonfireAmosCam.Priority = 0;
        BonfireSnobbishCam.Priority = 0;
        BonfireWindyCam.Priority = 0;
        BonfireLieselCam.Priority = 0;
        BonfireHeloiseCam.Priority = 0;
        BonfireShrillCam.Priority = 0;
    }

    [YarnCommand("switchAmosCam")]
    public void bonswitchAmos()
    {

        BonfireFenCam.Priority = 0;
        BonfireAmosCam.Priority = 20;
        BonfireSnobbishCam.Priority = 0;
        BonfireWindyCam.Priority = 0;
        BonfireLieselCam.Priority = 0;
        BonfireHeloiseCam.Priority = 0;
        BonfireShrillCam.Priority = 0;
    }

    [YarnCommand("switchSnobbishCam")]
    public void bonswitchSnobbish()
    {

        BonfireFenCam.Priority = 0;
        BonfireAmosCam.Priority = 0;
        BonfireSnobbishCam.Priority = 20;
        BonfireWindyCam.Priority = 0;
        BonfireLieselCam.Priority = 0;
        BonfireHeloiseCam.Priority = 0;
        BonfireShrillCam.Priority = 0;
    }

    [YarnCommand("switchWindyCam")]
    public void bonswitchWindy()
    {

        BonfireFenCam.Priority = 0;
        BonfireAmosCam.Priority = 0;
        BonfireSnobbishCam.Priority = 0;
        BonfireWindyCam.Priority = 20;
        BonfireLieselCam.Priority = 0;
        BonfireHeloiseCam.Priority = 0;
        BonfireShrillCam.Priority = 0;
    }

    [YarnCommand("switchLieselCam")]
    public void bonswitchLiesel()
    {

        BonfireFenCam.Priority = 0;
        BonfireAmosCam.Priority = 0;
        BonfireSnobbishCam.Priority = 0;
        BonfireWindyCam.Priority = 0;
        BonfireLieselCam.Priority = 20;
        BonfireHeloiseCam.Priority = 0;
        BonfireShrillCam.Priority = 0;
    }

    [YarnCommand("switchHeloiseCam")]
    public void bonswitchHeloise()
    {

        BonfireFenCam.Priority = 0;
        BonfireAmosCam.Priority = 0;
        BonfireSnobbishCam.Priority = 0;
        BonfireWindyCam.Priority = 0;
        BonfireLieselCam.Priority = 0;
        BonfireHeloiseCam.Priority = 20;
        BonfireShrillCam.Priority = 0;
    }

    [YarnCommand("switchShrillCam")]
    public void bonswitchShrill()
    {

        BonfireFenCam.Priority = 0;
        BonfireAmosCam.Priority = 0;
        BonfireSnobbishCam.Priority = 0;
        BonfireWindyCam.Priority = 0;
        BonfireLieselCam.Priority = 0;
        BonfireHeloiseCam.Priority = 0;
        BonfireShrillCam.Priority = 20;
    }

    [YarnCommand("resetBonCam")]
    public void bonswitchReset()
    {

        BonfireFenCam.Priority = 0;
        BonfireAmosCam.Priority = 0;
        BonfireSnobbishCam.Priority = 0;
        BonfireWindyCam.Priority = 0;
        BonfireLieselCam.Priority = 0;
        BonfireHeloiseCam.Priority = 0;
        BonfireShrillCam.Priority = 0;
        mainCamera.m_DefaultBlend.m_Time = 2f;
    }
}
