using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrypointBool : MonoBehaviour
{
    public bool isInside;
    //public GameObject Rock01;
    // Start is called before the first frame update
    void Start()
    {
        isInside = false;
    }


    private void OnTriggerStay(Collider other)
    {
        isInside = true;
  
    }
    private void OnTriggerExit(Collider other)
    {
        isInside = false;
    }
}
