using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PhoebetoFenGardenCutsceneManager : MonoBehaviour
{
    public DialogueTrigger outsideRookeryTrigger;

    public SimpleController divinerController;

    public GameObject PlayerPhoebe;

    public RookeryActivate rookeryControls;
    public CinemachineVirtualCamera fenCam01;
    public CinemachineVirtualCamera fenCam02;
    public CinemachineVirtualCamera phoebecam01;
    public GameObject phoebefeet;
    public GameObject phoebecolorway;
    public bool isswitiching;
    public bool isswitched;

    public YarnDialogueTrigger yarnDialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isswitiching = false;
        isswitched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (outsideRookeryTrigger.dialoguePlayed)
        {
            StartCoroutine("WaitSwitchtoFen");
        }

        /*if (!isswitiching && !isswitched)
        {
            StartCoroutine(PhoebeReveal());
        }*/
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isswitiching = true;
    }

    IEnumerator PhoebeReveal()
    {
        yield return new WaitForSeconds(2f);
        rookeryControls.firstPerson.Priority = 1;
        phoebecam01.Priority = 12;
        phoebefeet.SetActive(false);
        phoebecolorway.SetActive(true);
        PlayerPhoebe.GetComponent<SimpleController>().enabled = false;
        isswitched = true;
        StopCoroutine(PhoebeReveal());

    }

    IEnumerator WaitSwitchtoFen()
    {
        yield return new WaitForSeconds(2f);
        outsideRookeryTrigger.GetComponent<Collider>().enabled = false;
        PlayerPhoebe.GetComponent<SimpleController>().enabled = false;
        //switch camera to Fen
        phoebecam01.Priority = 0;
        rookeryControls.firstPerson.Priority = 1;
        fenCam01.Priority = 12;
        yield return new WaitForSeconds(4f);
        fenCam02.Priority = 12;
        fenCam01.gameObject.SetActive(false);
        fenCam01.Priority = 1;
        yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Diviner);
        divinerController.GetComponent<SimpleController>().enabled = true;
        yield return new WaitForSeconds(1f);
        yarnDialogueTrigger.gameObject.SetActive(false);
    }
}
