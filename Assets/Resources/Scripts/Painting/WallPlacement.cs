using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlacement : MonoBehaviour
{
    //private Vector3 offset;
    //private Vector3 screenPoint;
    public bool sheetPlaced = false;
    public bool clicked = false;
    public GameObject sheet;
    public float smooth = 1F;
    public Collider  wallPlacementColl;
    public float offset = -1.4f;
    public float yoffset = .5f;

    public GameObject paperplaceMan;
    // Start is called before the first frame update
    void Start()
    {
        wallPlacementColl = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            if (paperplaceMan.GetComponent<PaperPlacement>().isRotated)
            {
                sheet = paperplaceMan.GetComponent<PaperPlacement>().currentSheet;
                placeWallSheet();
            } 
        }
    }
    
    private void OnMouseDown()
    {
        clicked = true;
       
        
    }

    public void placeWallSheet()
    {
        if (!sheetPlaced)
        {
            sheet.GetComponent<ClickandDrag>().enabled = false;
            sheet.GetComponent<Collider>().enabled = false;
            

            // Calculate the journey length.
            //journeyLength = Vector3.Distance(currentSheet.transform.position, transform.position);
            // Distance moved equals elapsed time times speed..
            // float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            // float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            Debug.Log("placing");
            sheet.transform.position = Vector3.Lerp(sheet.transform.position, new Vector3(transform.position.x+offset,transform.position.y+yoffset , transform.position.z), Time.deltaTime * smooth);
           // sheet.transform.localScale = Vector3.Lerp(sheet.transform.localScale,new Vector3(.15f, .15f,.15f), Time.deltaTime * smooth);
            //sheet.transform.rotation = transform.rotation;
            
            wallPlacementColl.enabled = false;
            if (sheet.transform.position.z <= 2.13f && sheet.transform.position.z >= 2.12f)
            {
                Debug.Log("placed");
                sheet.tag = "Untagged";
                sheetPlaced = true;
                this.enabled = false;
                return;
            }
        }
    }
}
