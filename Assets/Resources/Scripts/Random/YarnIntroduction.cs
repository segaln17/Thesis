using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnIntroduction : MonoBehaviour
{
    public string nodeToCall;

    public bool inYarnTrigger;
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
            if (!inYarnTrigger)
            {
                inYarnTrigger = true;
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                {
                    FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
                }
            }
            
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            FindObjectOfType<DialogueRunner>().Stop();
            //FindObjectOfType<DialogueRunner>().startNode = nodeToCall;
        }
        
        inYarnTrigger = false;
    }
*/
}
