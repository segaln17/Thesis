using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyanobrushCollider : MonoBehaviour
{
    public PaintingSceneManager paintingSceneManager;
    private Vector3 offset;
    private Vector3 screenPoint;
    public GameObject brush;
    public float moveSpeed = 0.1f;
    private Vector3 originalBathPos;
    
    public bool iscarrying;
    // Start is called before the first frame update
    void Start()
    {
        originalBathPos = brush.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (iscarrying)
        {
            isDragging();
            paintingSceneManager.paintbrushActive = true;
        }
        else
        {
            brush.transform.position = originalBathPos;
        }
        //if brush is not in trigger box for bath
        //set isPainting to active?
        //can't click on stuff with multiple colliders but, we could click the bath box collider, and the brush has no collider/rb and it just follows?
    }
    
   private void OnMouseDown()
   {
       iscarrying = !iscarrying;
       //Debug.Log("dragging");
       //isDrag = true;
       screenPoint = Camera.main.WorldToScreenPoint(brush.transform.position);
       offset = brush.transform.position -
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + 2, screenPoint.z));
 
   }
   private void isDragging()
   {
       Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
       Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
       cursorPos.y = Mathf.Clamp(transform.position.y, 0.2f, 1.25f);
       brush.transform.position = cursorPos;
   }
}
