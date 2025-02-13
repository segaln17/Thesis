using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentScript : MonoBehaviour
{
    public GameObject surprise;
    public GameObject fragment01;
    public GameObject fragment02;

    public List<GameObject> alignmentPuzzleObjects = new List<GameObject>();
    public bool isChecking = false;

    public int targetCastLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alignmentPuzzleObjects.Count >= targetCastLimit)
        {
            surprise.SetActive(true);
            fragment01.SetActive(false);
            fragment02.SetActive(false);
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
}
