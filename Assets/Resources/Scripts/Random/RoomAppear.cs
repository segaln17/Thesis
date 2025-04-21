using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Yarn.Unity;

public class RoomAppear : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject Room;
    public GameObject phoebeOrientation;
    public GameObject playerPhoebe;
    public GameObject playerCamScriptHolder;
    //public layermask everything
    //public layermask just the one we want

    private float pForce;
    private float pFallForce;
    public bool roomOn;
    public bool notinroom;
    // Start is called before the first frame update
    void Start()
    {
        pForce = playerPhoebe.GetComponent<SimpleController>().force;
        pFallForce = playerPhoebe.GetComponent<SimpleController>().fallingforce;
        notinroom = true;
        roomOn = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(phoebeOrientation.transform.localEulerAngles.y);
        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            turnonRoom();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            turnoffRoom();
        }
        */

        if (phoebeOrientation.transform.localEulerAngles.y <= -150 && phoebeOrientation.transform.localEulerAngles.y >= -200 && roomOn || phoebeOrientation.transform.localEulerAngles.y >= 150 && phoebeOrientation.transform.localEulerAngles.y <= 200 && roomOn)
        {
            playerPhoebe.GetComponent<SimpleController>().force = 0;
            playerPhoebe.GetComponent<SimpleController>().fallingforce = 0;

            playerCamScriptHolder.GetComponent<PlayerCam>().yRotation = Mathf.Clamp(playerCamScriptHolder.GetComponent<PlayerCam>().yRotation, -200, -145);
            playerCamScriptHolder.GetComponent<PlayerCam>().xRotation = Mathf.Clamp(playerCamScriptHolder.GetComponent<PlayerCam>().xRotation, 0, 50);
            mainCamera.cullingMask = 1 << LayerMask.NameToLayer("Room");
            //mainCamera.cullingMask 
            //float tempY = phoebeOrientation.transform.localEulerAngles.y;
            //tempY = Mathf.Clamp(phoebeOrientation.transform.localEulerAngles.y, -175f, -195f);
            Debug.Log("roomsequence");

        }


    }

    [YarnCommand ("turnOnChorusRoom")]
    public void turnonRoom()
    {
        Room.SetActive(true);
        roomOn = true;

        
    }

    [YarnCommand ("turnOffChorusRoom")]
    public void turnoffRoom()
    {
        Room.SetActive(false);
        roomOn = false;

        playerPhoebe.GetComponent<SimpleController>().force = pForce;
        playerPhoebe.GetComponent<SimpleController>().fallingforce = pFallForce;
        playerCamScriptHolder.GetComponent<PlayerCam>().xRotation = Mathf.Clamp(playerCamScriptHolder.GetComponent<PlayerCam>().xRotation, -90, 90);
        playerCamScriptHolder.GetComponent<PlayerCam>().yRotation = Mathf.Clamp(playerCamScriptHolder.GetComponent<PlayerCam>().yRotation, -360, 360);

        //mainCamera.cullingMask = 1 << LayerMask.NameToLayer("Everything");

        Debug.Log("noroomsequence");
    }
}
