using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public LayerMask m_Mask = 10;
    [Header("Dreamer")]
    public AlignmentScript dreamerpuzzleList;
    public GameObject dreamerpuzzleGameTrigger;
    [Header("Archaelogist")]
    public AlignmentScript archpuzzleList;
    public GameObject archpuzzleGameTrigger;


    //public bool ishitting = false;
    // Start is called before the first frame update
    void Start()
    {
        dreamerpuzzleList = dreamerpuzzleGameTrigger.GetComponent<AlignmentScript>();
        archpuzzleList = archpuzzleGameTrigger.GetComponent<AlignmentScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //------DREAMER SECTION------
        if (dreamerpuzzleList.isChecking)
        {     
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, 500.0F, m_Mask.value, QueryTriggerInteraction.Collide);

            Debug.Log("iscasting");

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                Debug.Log(hit.collider.name);
                //Debug.DrawLine(transform.position, hit.point - transform.position, Color.red);


                if (dreamerpuzzleList.alignmentPuzzleObjects.Contains(hit.collider.gameObject))
                {
                    Debug.Log("Already Added");
                }
                else
                {
                    dreamerpuzzleList.alignmentPuzzleObjects.Add(hit.collider.gameObject);
                }


            }
        }

        //------ARCHAELOGIST SECTION------
        if (archpuzzleList.isChecking)
        {  
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.up, 500.0F, m_Mask.value, QueryTriggerInteraction.Collide);

            Debug.Log("iscasting");

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                Debug.Log(hit.collider.name);
                //Debug.DrawLine(transform.position, hit.point - transform.position, Color.red);


                if (archpuzzleList.alignmentPuzzleObjects.Contains(hit.collider.gameObject))
                {
                    Debug.Log("Already Added");
                }
                else
                {
                    archpuzzleList.alignmentPuzzleObjects.Add(hit.collider.gameObject);
                }


            }
        }



    }


}
