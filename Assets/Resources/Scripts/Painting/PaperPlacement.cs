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
    //public GameObject wallPlacement;
    public float rotateyval = 10f;
    public GameObject PaintingSceneMan;

    public bool isDone = false;
    public bool isRotated = false;

    public float sheetscalexhigh = 1;
    public float sheetscalexlow = .9997f;

    

    private void Start()
    {
       paperPlacementColl = GetComponent<Collider>();
       //scaleLerp = new Vector3(1, 1, 1);
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
            PaintingSceneMan.GetComponent<PaintingSceneManager>().sheetNest = currentSheet;
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
            if (currentSheet.transform.localScale.x <= sheetscalexhigh && currentSheet.transform.localScale.x >= sheetscalexlow)
            {
                isDone = true;
                return;
            }
        }
        
    }

    public void turnOnCollider()
    {
        currentSheet.GetComponent<Collider>().enabled = true;
        
        Debug.Log("Collideron");
        StartCoroutine(turnonClick2());

    }

    public void turnOnClickandDrag()
    {
        if(!isRotated)
        {
            StartCoroutine(Rotated());
        }
        
            turnOnCollider();
 
    }

    public IEnumerator Rotated()
    {
        paperPlacementColl.enabled = false;
        currentSheet.transform.position = Vector3.Lerp(currentSheet.transform.position, new Vector3(currentSheet.transform.position.x, rotateyval, currentSheet.transform.position.z), Time.deltaTime * 1f);
            currentSheet.transform.localScale = Vector3.Lerp(currentSheet.transform.localScale,new Vector3(0.35f, 0.35f,0.35f), Time.deltaTime * 1f);
            currentSheet.transform.eulerAngles = Vector3.Lerp(currentSheet.transform.eulerAngles,
                new Vector3(currentSheet.transform.eulerAngles.x - 90f, currentSheet.transform.eulerAngles.y,
                    currentSheet.transform.eulerAngles.z), Time.deltaTime * .5f);
            //paperPlacementColl.enabled = false;
            yield return new WaitForSeconds(2f);
            isRotated = true;
        StopCoroutine(Rotated());
    }

    public IEnumerator turnonClick2()
    {
        yield return new WaitForSeconds(1.5f);
        currentSheet.GetComponent<ClickandDrag02>().enabled = true;
        Debug.Log("CanClick");
    }
    
}
