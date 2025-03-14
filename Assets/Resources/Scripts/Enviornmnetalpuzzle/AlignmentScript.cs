using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentScript : MonoBehaviour
{
    public GameObject surprise;
    public GameObject fragment01;
    public GameObject fragment02;
    public GameObject memoryCanvas;
    public GameObject memoryCardButton;
    //public int triggercount;

    public List<GameObject> alignmentPuzzleObjects = new List<GameObject>();
    public bool isChecking = false;
    public bool hasplayedArch = false;
    public bool hasplayedDreamer = false;

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
        if (gameObject.CompareTag("Dreamer"))
        {
            if (alignmentPuzzleObjects.Count >= targetCastLimit && !hasplayedDreamer)
            {
                surprise.SetActive(true);
                fragment01.SetActive(false);
                fragment02.SetActive(false);
                StartCoroutine(memoryCardTrigger());
            }
        }

        if (gameObject.CompareTag("Archaeologist"))
        {
            if (alignmentPuzzleObjects.Count >= targetCastLimit && !hasplayedArch)
            {
                surprise.SetActive(true);
                fragment01.SetActive(false);
                fragment02.SetActive(false);
                StartCoroutine(memoryCardTrigger02());
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        isChecking = true;
        //Debug.Log("ischecking");
    }

    private void OnTriggerExit(Collider other)
    {
        isChecking = false;
    }

    private IEnumerator memoryCardTrigger()
    {
        hasplayedDreamer = true;
        if (!memoryCanvas.activeInHierarchy)
        {
            memoryCanvas.SetActive(true);
        }
        Debug.Log("turnonmemory");
        yield return new WaitForSeconds(2f);
        specificMemoryCard.SetActive(true);
        Debug.Log("cardon");
        yield return new WaitForSeconds(.5f);
        surprise.SetActive(false);      
        yield return new WaitForSeconds(1f);
        Debug.Log("buttons on");
        memoryCardButton.SetActive(true);
        yield return new WaitForSeconds(5f);
        Debug.Log("triggeroff");
        StopCoroutine(memoryCardTrigger());
        gameObject.SetActive(false);
    }

    private IEnumerator memoryCardTrigger02()
    {
        hasplayedArch = true;
        if (!memoryCanvas.activeInHierarchy)
        {
            memoryCanvas.SetActive(true);
        }
        Debug.Log("turnonmemory");
        yield return new WaitForSeconds(2f);
        specificMemoryCard.SetActive(true);
        Debug.Log("cardon");
        yield return new WaitForSeconds(.5f);
        surprise.SetActive(false);
        yield return new WaitForSeconds(1f);
        Debug.Log("buttons on");
        memoryCardButton.SetActive(true);
        yield return new WaitForSeconds(5f);
        Debug.Log("triggeroff");
        StopCoroutine(memoryCardTrigger());
        //gameObject.SetActive(false);
    }
}
