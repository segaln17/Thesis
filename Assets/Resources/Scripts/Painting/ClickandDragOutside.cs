using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickandDragOutside : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 screenPoint;
    //public GameObject EntryPoint;
    
    //public float cursorymin = 7f;
    //public float cursorymax = 18f;
  
    public float placeYOffset = 1f;
    public float offsetInitial = 2f;

    public bool iscarrying;
    public bool justClicked;
    public Rigidbody objRB;

    public AudioSource objAud;
    public AudioClip clickSound;
    public AudioClip clickSoundDrop;


    // Update is called once per frame
    void Update()
    {
        
        if (iscarrying)
        {
            isDragging();

            if (Input.GetKeyDown(KeyCode.Mouse0) && !justClicked)
            {
                objAud.pitch = UnityEngine.Random.Range(.7f, 1);
                objAud.PlayOneShot(clickSoundDrop);
                transform.position = new Vector3(transform.position.x, transform.position.y - placeYOffset, transform.position.z);
                iscarrying = false;
                objRB.isKinematic = false;
            }
        }

        justClicked = false;


    }

    private void OnMouseDown()
    {
        objAud.pitch = UnityEngine.Random.Range(.7f, 1);
        objAud.PlayOneShot(clickSound);
        if (!iscarrying)
        {
            iscarrying = true;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + offsetInitial, screenPoint.z));
            justClicked = true;
        }

 
    }


  
    private void isDragging()
    {
       
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        //cursorPos.y = Mathf.Clamp(transform.position.y, cursorymin, cursorymax);
        transform.position = cursorPos;

    }
}
