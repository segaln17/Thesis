using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class YarnCutsceneManager : MonoBehaviour
{
    public YarnDialogueTrigger yarnDialogueTrigger;
    private DialogueRunner dialogueRunner;
    public string nonCutsceneNode;
    public bool cutsceneRun = false;

    public GameObject NPC;

    private Vector3 NPCstartpos;

    private Vector3 NPCendpos;
    // Start is called before the first frame update
    void Start()
    {
        NPCstartpos = NPC.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ok I don't know if these actually work but we can attempt to fix later
    [YarnCommand("runOpening")]
    public void OpeningCutscene()
    {
        yarnDialogueTrigger.GetComponent<YarnDialogueTrigger>();
        yarnDialogueTrigger.nodeToCall = "Opening";
        dialogueRunner.startAutomatically = true;

        Debug.Log("cutscene");
        cutsceneRun = true;
    }

    [YarnCommand("gardenCutscene")]
    public void GardenCutscene()
    {
        //yarnDialogueTrigger.GetComponent<YarnDialogueTrigger>();
        //yarnDialogueTrigger.nodeToCall = "PhoebeintheGarden";
        dialogueRunner.startNode = "PhoebeintheGarden";
        dialogueRunner.startAutomatically = true;
        
    }

    [YarnCommand("NotAutomatic")]
    public void RunnerNotAutomatic()
    {
        dialogueRunner.startAutomatically = false;
        yarnDialogueTrigger.nodeToCall = nonCutsceneNode;
    }
}
