using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTriggerIntro : MonoBehaviour
{
    public GameObject introAudio;

    public GameObject borderUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            introAudio.SetActive(true);
            borderUI.SetActive(true);
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
        
    }
}
