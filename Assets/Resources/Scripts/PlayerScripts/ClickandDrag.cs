using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickandDrag : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 screenPoint;
    public GameObject paintingManager;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log(screenPoint.z);

    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    

    private void OnMouseDrag()
    {
        if (paintingManager.GetComponent<PaintingSceneManager>().state ==
            PaintingSceneManager.paintingState.wallPlacing)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            //cursorPos.y = Mathf.Clamp(transform.position.y, 0.2f, 1.25f);
            transform.position = cursorPos;
        }
        else
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            cursorPos.y = Mathf.Clamp(transform.position.y, 0.2f, 1.25f);
            transform.position = cursorPos;
        }
    }
    
}
