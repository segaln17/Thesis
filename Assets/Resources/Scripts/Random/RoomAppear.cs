using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
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
    public bool inRoom;
    public bool notinroom;

    public PlayableDirector roomTurnTimeline;

    public string nodeToCall;
    // Start is called before the first frame update
    void Start()
    {
        pForce = playerPhoebe.GetComponent<SimpleController>().force;
        pFallForce = playerPhoebe.GetComponent<SimpleController>().fallingforce;
        notinroom = true;
        roomOn = false;
        inRoom = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(phoebeOrientation.transform.localEulerAngles.y);
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            turnonRoom();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            turnoffRoom();
        }
        

        if (phoebeOrientation.transform.localEulerAngles.y <= -150 && phoebeOrientation.transform.localEulerAngles.y >= -200 && roomOn || phoebeOrientation.transform.localEulerAngles.y >= 150 && phoebeOrientation.transform.localEulerAngles.y <= 200 && roomOn)
        {
            playerPhoebe.GetComponent<SimpleController>().force = 0;
            playerPhoebe.GetComponent<SimpleController>().fallingforce = 0;

            playerCamScriptHolder.GetComponent<PlayerCam>().yRotation = Mathf.Clamp(playerCamScriptHolder.GetComponent<PlayerCam>().yRotation, -200, -145);
            playerCamScriptHolder.GetComponent<PlayerCam>().xRotation = Mathf.Clamp(playerCamScriptHolder.GetComponent<PlayerCam>().xRotation, 0, 30);
            inRoom = true;
            //mainCamera.cullingMask 
           // float tempY = phoebeOrientation.transform.localEulerAngles.y;
           // tempY = Mathf.Clamp(tempY, -175f, -195f);
            Debug.Log("roomsequence");

        }


    }

    [YarnCommand ("turnOnChorusRoom")]
    public void turnonRoom()
    {
        Room.SetActive(true);
        roomOn = true;
        StartCoroutine("WaitChorus");

        
    }

    [YarnCommand ("turnOffChorusRoom")]
    public void turnoffRoom()
    {
        //StopAllCoroutines();
        StopCoroutine(WaitChorus());
        StartCoroutine("WaitNoRoom");
        Room.SetActive(false);
        roomOn = false;
        
        playerPhoebe.GetComponent<SimpleController>().force = pForce;
        playerPhoebe.GetComponent<SimpleController>().fallingforce = pFallForce;
        playerCamScriptHolder.GetComponent<PlayerCam>().xRotation = Mathf.Clamp(playerCamScriptHolder.GetComponent<PlayerCam>().xRotation, -90, 90);
        playerCamScriptHolder.GetComponent<PlayerCam>().yRotation = Mathf.Clamp(playerCamScriptHolder.GetComponent<PlayerCam>().yRotation, -360, 360);
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("cam01");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("cam02");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("Default");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("Ground");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("Player");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("Water");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("Ignore Raycast");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("InventoryItem");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("PuzzlePieces");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("UI");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("PlayerWalkIgnore");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("TransparentFX");
        mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("NPCSprites");
        //mainCamera.cullingMask = 1 << LayerMask.NameToLayer("Everything");

        Debug.Log("noroomsequence");
    }

    IEnumerator WaitChorus()
    {
        yield return new WaitForSeconds(1f);
        //phoebeOrientation.transform.LookAt(Room.transform);
        //roomCameraAnimator.SetBool("RoomIsOn", true);
        //roomTurnTimeline.Play();
        yield return new WaitForSeconds(1f);
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
        {
            FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
        }
        Debug.Log("dialogue would play");
        yield return new WaitForSeconds(2f);
        
   
    }

    IEnumerator WaitNoRoom()
    {
        yield return new WaitForSeconds(2f);
        //roomCameraAnimator.SetBool("RoomIsOn", false);
        //yield return new WaitForSeconds(2f);
    }
}
