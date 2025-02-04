using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public LayerMask m_Mask = 10;
    public AlignmentScript puzzleList;
    public GameObject puzzleGameTrigger;
    
    //public bool ishitting = false;
    // Start is called before the first frame update
    void Start()
    {
        puzzleList = puzzleGameTrigger.GetComponent<AlignmentScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (puzzleList.isChecking)
        {      //Vector3 position = (transform.position);
            //Ray ray = Camera.main.ScreenPointToRay(transform.position);
            //RaycastHit hit;

            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, 500.0F, m_Mask.value, QueryTriggerInteraction.Collide);

            Debug.Log("iscasting");

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                Debug.Log(hit.collider.name);
                //Debug.DrawLine(transform.position, hit.point - transform.position, Color.red);


                if (puzzleList.alignmentPuzzleObjects.Contains(hit.collider.gameObject))
                {
                    Debug.Log("Already Added");
                }
                else
                {
                    puzzleList.alignmentPuzzleObjects.Add(hit.collider.gameObject);
                }


            }
        }
      
        

    }

    public void ViewPoint()
    {
       
    }
}
