using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickandDrag : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 screenPoint;
    public GameObject paintingManager;
    public float cursorymin = 7f;
    public float cursorymax = 18f;
    public float placeYOffset = 1f;

    public bool iscarrying;
    public bool justClicked;

    void Start()
    {
        iscarrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (iscarrying)
        {
            isDragging();

                if (Input.GetKeyDown(KeyCode.Mouse0) && !justClicked)
                {
                transform.position = new Vector3(transform.position.x, transform.position.y - placeYOffset, transform.position.z);
                iscarrying = false;
                }
        }

        justClicked = false;

        
    }

    private void OnMouseDown()
    {
        if (!iscarrying)
        {
            iscarrying = true;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + 2, screenPoint.z));
            justClicked = true;
        }

        /*screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));*/
    }
    

    /*private void OnMouseDrag()
    {
        if (paintingManager.GetComponent<PaintingSceneManager>().state ==
            PaintingSceneManager.paintingState.wallPlacing)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            //cursorPos.y = Mathf.Clamp(transform.position.y, 0.2f, 1.25f);
            transform.position = cursorPos;
        }
        
    }*/

    private void isDragging()
    {
        /*if (paintingManager.GetComponent<PaintingSceneManager>().state ==
            PaintingSceneManager.paintingState.wallPlacing)
        {
            
        }*/
       
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            cursorPos.y = Mathf.Clamp(transform.position.y, cursorymin, cursorymax);
            transform.position = cursorPos;

    }

}
