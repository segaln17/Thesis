using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomoverlay : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject phoebeOrientation;
    
    // Start is called before the first frame update
    private void OnBecameVisible()
    {
        mainCamera.cullingMask = 1 << LayerMask.NameToLayer("Room");
        
    }

    private void OnBecameInvisible()
    {
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
    }
}
