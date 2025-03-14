using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentScript : MonoBehaviour
{
    public GameObject surprise;
    public GameObject fragment01;
    public GameObject fragment02;
    //public GameObject memoryCard;
    public GameObject memoryCardButton;
    //public int triggercount;

    public List<GameObject> alignmentPuzzleObjects = new List<GameObject>();
    public bool isChecking = false;
    public bool hasplayed = false;

    public int targetCastLimit;

    public GameObject specificMemoryCard;
    // Start is called before the first frame update
    void Start()
    {
        //triggercount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(alignmentPuzzleObjects.Count >= targetCastLimit && !hasplayed)
        {
            surprise.SetActive(true);
            fragment01.SetActive(false);
            fragment02.SetActive(false);
            StartCoroutine(memoryCardTrigger());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isChecking = true;
        Debug.Log("ischecking");
    }

    private void OnTriggerExit(Collider other)
    {
        isChecking = false;
    }

    IEnumerator memoryCardTrigger()
    {
        hasplayed = true;
        Debug.Log("turnonmemory");
        yield return new WaitForSeconds(2f);
        specificMemoryCard.SetActive(true);
        yield return new WaitForSeconds(.5f);
        surprise.SetActive(false);      
        yield return new WaitForSeconds(1f);
        Debug.Log("buttons on");
        memoryCardButton.SetActive(true);
        yield return new WaitForSeconds(4f);
        Debug.Log("triggeroff");
        gameObject.SetActive(false);
    }
}
