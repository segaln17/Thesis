using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ClickandDragOutside : MonoBehaviour
{
    //private Vector3 offset;
    private Vector3 screenPoint;
    public bool isInside;

    public GameObject eEngage;
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
        if(isInside && !iscarrying)
        {
            //if (Input.GetKeyUp(KeyCode.E))
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnEntry();
            }
        }
        if (iscarrying)
        {
            isDragging();
            
            //if (Input.GetKeyDown(KeyCode.E) && !justClicked)
            if (Input.GetKeyDown(KeyCode.Mouse0) && !justClicked)
            {
                objAud.pitch = UnityEngine.Random.Range(.7f, 1);
                objAud.PlayOneShot(clickSoundDrop);
                transform.position = new Vector3(transform.position.x, transform.position.y - placeYOffset, transform.position.z);
                iscarrying = false;
                objRB.isKinematic = false;
                //firstPersonPOV.LookAt = null;
                //Cursor.lockState = CursorLockMode.None;
            }
        }

        justClicked = false;


    }

    private void OnEntry()
    {
        objAud.pitch = UnityEngine.Random.Range(.7f, 1);
        objAud.PlayOneShot(clickSound);
        if (!iscarrying)
        {
            iscarrying = true;
            //Cursor.lockState = CursorLockMode.Locked;
            //firstPersonPOV.LookAt = targetObject.transform;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            //offset = transform.position -
                     //Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + offsetInitial, screenPoint.z));
            justClicked = true;
            eEngage.SetActive(false);
        }

 
    }


  
    private void isDragging()
    {
       
        Vector3 cursorPoint = new Vector3(Screen.width / 2, Screen.height / 2, screenPoint.z);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint);
        //cursorPos.y = Mathf.Clamp(transform.position.y, Screen.width / 2, Screen.width / 2);
        
        //Cursor.lockState = CursorLockMode.Confined;
        transform.position = cursorPos;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = true;
            eEngage.SetActive(true);
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = false;
            eEngage.SetActive(false);
        }
            
    }
}
