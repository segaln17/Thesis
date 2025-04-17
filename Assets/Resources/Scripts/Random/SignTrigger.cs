using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignTrigger : MonoBehaviour
{
    public Animator textAppear;

    public bool textOnReady;
    
    public TextMeshProUGUI dialogueIndicator;
    // Start is called before the first frame update
    void Start()
    {
        dialogueIndicator.gameObject.SetActive(false);
        textOnReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (textOnReady && Input.GetKeyDown(KeyCode.Mouse0))
        {
            dialogueIndicator.gameObject.SetActive(false);
            textAppear.SetBool("TurnonText", true);
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && textAppear.GetBool("TurnonText") == false)
        {
            textOnReady = true;
            dialogueIndicator.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && textAppear.GetBool("TurnonText") == false)
        {
            dialogueIndicator.gameObject.SetActive(false);
        }
    }
}
