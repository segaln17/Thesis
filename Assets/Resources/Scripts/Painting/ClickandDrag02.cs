using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickandDrag02 : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 screenPoint;
    public GameObject paintingManager;
    public float cursorxmin = 7f;
    public float cursorxmax = 18f;
    public float cursorymin = 7f;
    public float cursorymax = 18f;
    public float cursorzmin = 7f;
    public float cursorzmax = 18f;
    public float placeZOffset = 1f;

    public bool iscarrying;
    public bool justClicked;

    public AudioSource rookAud;
    public AudioClip clickSound;
    public AudioClip clickSoundDrop;

    // Start is called before the first frame update
    void Awake()
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
                rookAud.PlayOneShot(clickSoundDrop);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                iscarrying = false;
            }
        }

        justClicked = false;
    }

    private void OnMouseDown()
    {
        rookAud.PlayOneShot(clickSound);
        if (!iscarrying)
        {
            iscarrying = true;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + 2, screenPoint.z));
            justClicked = true;
        }

    }


    

    private void isDragging()
    {
      

        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z-placeZOffset);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        //cursorPos.x = Mathf.Clamp(transform.position.x, cursorxmin, cursorxmax);
        cursorPos.y = Mathf.Clamp(transform.position.y, cursorymin, cursorymax);
        //cursorPos.z = Mathf.Clamp(transform.position.z, cursorzmin, cursorzmax);
        transform.position = cursorPos;

    }
}
