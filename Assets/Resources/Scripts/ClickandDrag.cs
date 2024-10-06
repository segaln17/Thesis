using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickandDrag : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 screenPoint;
    //public GameObject cyanoBrush;

    public static ClickandDrag instance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnMouseDown()
    {
        //Debug.Log("dragging");
        //isDrag = true;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
 
    }
    

    private void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPos;
    }
    
}
