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
    public float cursorymin = 0.2f;
    public float cursorymax = 2f;
    private Vector3 originalBathPos;
    
    public bool iscarrying;

    public AudioSource rookAud;
    public AudioClip bucket;
    
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
       
    }
    
   private void OnMouseDown()
   {
       iscarrying = !iscarrying;
        rookAud.PlayOneShot(bucket);

        screenPoint = Camera.main.WorldToScreenPoint(brush.transform.position);
       offset = brush.transform.position -
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + 2, screenPoint.z));
 
   }
   private void isDragging()
   {
       
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
       Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
       cursorPos.y = Mathf.Clamp(transform.position.y, cursorymin, cursorymax);
       brush.transform.position = cursorPos;
   }
}
