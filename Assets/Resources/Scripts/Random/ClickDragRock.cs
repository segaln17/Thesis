using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragRock : MonoBehaviour
{

    //private Vector3 offset;
    private Vector3 screenPoint;
    public bool isInside;
    public float strength=2f;
    public float upstrength = 2f;


    public float placeYOffset = 1f;
    public float offsetInitial = 2f;

    public bool iscarrying;
    public bool justClicked;
    public Rigidbody objRB;

    public AudioSource objAud;
    public AudioClip clickSound;
    public AudioClip clickSoundDrop;

    public GameObject eEngage;
    public Transform orientation;


    // Update is called once per frame
    void Update()
    {
        if (isInside && !iscarrying)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnEntry();
                Debug.Log("pickup");
            }
        }

        if (iscarrying)
        {
            isDragging();

            if (Input.GetKeyDown(KeyCode.E) && !justClicked)
            {
                objAud.pitch = UnityEngine.Random.Range(.7f, 1);
                objAud.PlayOneShot(clickSoundDrop);
                transform.position = new Vector3(transform.position.x, transform.position.y - placeYOffset, transform.position.z);
                iscarrying = false;
                objRB.isKinematic = false;
                objRB.AddForce(orientation.forward * strength, ForceMode.Impulse);
                objRB.AddForce(orientation.up * upstrength, ForceMode.Impulse);
                Debug.Log("drop");
                justClicked = false;
           
            }
        }

        justClicked = false;
        //Debug.Log("justclicked");


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

