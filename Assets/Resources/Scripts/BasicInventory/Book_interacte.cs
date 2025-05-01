using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Book_interacte : MonoBehaviour, IInteractable
{

    public InventoryManager inventoryManager;
    public Interactor interactorScript;

    public string nodeToCall;
    public void Interact()
    {
        Debug.Log("interacting");
        inventoryManager.AddItem(gameObject.name);
        interactorScript.interactInstruction.SetActive(false);
        Destroy(gameObject, 0.1f);
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
        {
            FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
        }
    }
}
