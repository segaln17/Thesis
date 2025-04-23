using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenHallucinations : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            image.SetActive(true);
            StartCoroutine(WaitDisappear());
        }
        
    }

    IEnumerator WaitDisappear()
    {
        yield return new WaitForSeconds(5f);
        image.SetActive(false);
        StopCoroutine(WaitDisappear());
    }
}
