using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    void Interact();
}

public interface IExamining
{
    void Examine();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public LayerMask interactableLayer;
    //public AudioSource mysteryJingle;

    Collider[] colliders;
    //[SerializeField] Image EButton;

    // Create a list to store interactable objects
    private List<IInteractable> inventory = new List<IInteractable>();


    void Update()
    {
        colliders = Physics.OverlapSphere(InteractorSource.position, InteractRange, interactableLayer);
        //EButton.enabled = (colliders.Length > 0);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
         
            CheckInteracte();
        }
    }

    private void CheckInteracte()
    {
        // Start a new interaction
    
        
        foreach (Collider collider in colliders)
        {
          
            if (collider.TryGetComponent<IInteractable>(out var interactObj))
            {
               
                // Check if the interactable object is within the specified range
                
                if (IsClose(collider) &&  !inventory.Contains(interactObj))
                {
                    
                    interactObj.Interact();  
                    inventory.Add(interactObj);
                   // mysteryJingle.Play();
                }
            } else if (collider.TryGetComponent<IExamining>(out var examineObj))
            {
                examineObj.Examine(); //examining the space
            }
        }
    }

    bool IsClose(Collider collider)
    {
        float distance = Vector3.Distance(InteractorSource.position, collider.transform.position);
        return distance <= InteractRange;
    }


}
