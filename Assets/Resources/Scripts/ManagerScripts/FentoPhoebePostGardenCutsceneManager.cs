using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FentoPhoebePostGardenCutsceneManager : MonoBehaviour
{
    [Header("Yarn Triggers")]
    public YarnDialogueTrigger alteaCutsceneTrigger;
    public YarnDialogueTrigger yarnDialogueTrigger;
    public bool cutsceneEndedInCollider;

    public GameObject coroutineManager;
    
    // Start is called before the first frame update
    void Start()
    {
        cutsceneEndedInCollider = false;
        
    }

    // Update is called once per frame
    void Update()
    
    {
        //if (alteaCutsceneTrigger.cutsceneRun)
        if (cutsceneEndedInCollider)
        {
            StartCoroutine(coroutineManager.GetComponent<CutsceneCoroutineManager>().FtoPpostStable());
            //alteaCutsceneTrigger.cutsceneRun;
            gameObject.GetComponent<Collider>().enabled = false;
            cutsceneEndedInCollider = false;
            //alteaCutsceneTrigger.gameObject.SetActive(false);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            
            cutsceneEndedInCollider = true;
        }
        
    }
    
 
}
