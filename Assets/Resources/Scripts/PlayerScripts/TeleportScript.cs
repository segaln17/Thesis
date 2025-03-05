using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject player;

    public Transform teleportPos;

    public GameManager gameManager;

    public MemoryGuidance memoryGuidanceScript;

    public bool inTeleportCollider = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if in the collider and fen's hand and memory guide are both active
        if (inTeleportCollider && memoryGuidanceScript.fenHandUI.activeInHierarchy && memoryGuidanceScript.memoryGuide.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                player.transform.position = teleportPos.position;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            inTeleportCollider = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            inTeleportCollider = true;
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            inTeleportCollider = false;
        }
    }
}
