using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoebetoFenGardenCutsceneManager : MonoBehaviour
{
    public DialogueTrigger outsideRookeryTrigger;

    public SimpleController divinerController;

    public SimpleController fighterController;

    public RookeryActivate rookeryControls;

    public YarnDialogueTrigger yarnDialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (outsideRookeryTrigger.dialoguePlayed)
        {
            StartCoroutine("WaitSwitchtoFen");
        }
    }

    IEnumerator WaitSwitchtoFen()
    {
        yield return new WaitForSeconds(2f);
        outsideRookeryTrigger.GetComponent<Collider>().enabled = false;
        //switch camera to Fen
        rookeryControls.firstPersonDiviner.Priority = 12;
        rookeryControls.firstPerson.Priority = 1;
        yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Diviner);
        fighterController.GetComponent<SimpleController>().enabled = false;
        divinerController.GetComponent<SimpleController>().enabled = true;
        yarnDialogueTrigger.GetComponent<Collider>().enabled = false;
    }
}
