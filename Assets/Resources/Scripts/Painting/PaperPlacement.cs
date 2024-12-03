using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlacement : MonoBehaviour
{
    public bool sheet01 = false;
    // Movement speed in units per second.
    public float smooth = 1F;
    public Collider  paperPlacementColl;
    public GameObject currentSheet;

    public bool isDone = false;

    // Time when the movement started.
    //public float startTime;

    // Total distance between the markers.
    //private float smooth = ;

    private void Start()
    {
       paperPlacementColl = GetComponent<Collider>();
    }

    private void Update()
    {
        if (sheet01)
        {
            placeSheet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CyanoSheet")
        {
            // Keep a note of the time the movement started.
            //startTime = Time.time;
            currentSheet = other.gameObject;
            sheet01 = true;
        }
    }

    public void placeSheet()
    {
        if (!isDone)
        {
            currentSheet.GetComponent<ClickandDrag>().enabled = false;
            currentSheet.GetComponent<Collider>().enabled = false;

            // Calculate the journey length.
            //journeyLength = Vector3.Distance(currentSheet.transform.position, transform.position);
            // Distance moved equals elapsed time times speed..
            // float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            // float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            currentSheet.transform.position = Vector3.Lerp(currentSheet.transform.position, transform.position, Time.deltaTime * smooth);
            currentSheet.transform.localScale = Vector3.Lerp(currentSheet.transform.localScale,new Vector3(1, 1,1), Time.deltaTime * smooth);
            currentSheet.transform.rotation = transform.rotation;
            
            paperPlacementColl.enabled = false;
            if (currentSheet.transform.position == transform.position)
            {
                isDone = true;
                return;
            }
        }
        
    }
}
