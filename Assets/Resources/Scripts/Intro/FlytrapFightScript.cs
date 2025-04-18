using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class FlytrapFightScript : MonoBehaviour
{
    public Button fightButton1;
    public Button fightButton2;
    public Button fightButtonFinal;

    public GameObject buttonCanvas;

    public IntroCutsceneAnimScript introCutsceneScript;

    public CinemachineVirtualCamera fightCam01;
    public CinemachineVirtualCamera fightCam02;
    public CinemachineVirtualCamera fightCam03;

    public Animator flytrapSlashAnimator;
    public Animator playerAnim;
    public Animator playerAnimShadow;

    private string nodeToCall;
    // Start is called before the first frame update
    void Start()
    {
        fightButton2.gameObject.SetActive(false);
        fightButtonFinal.gameObject.SetActive(false);
        fightCam02.Priority = 0;
        fightCam03.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //aim: each time you hit the button it changes to another button and then a third button
    //and then if you hit the final button it gets you to the flytrapfight function in IntroCutsceneAnimScript

    public void FirstHit()
    {
        fightButton1.gameObject.SetActive(false);
        nodeToCall = "FlytrapFight1";
        StartCoroutine("fightResponse");
        fightCam01.Priority = 0;
        fightCam02.Priority = 12;
        //buttonCanvas.SetActive(true);
        fightButton2.gameObject.SetActive(true);
        //StopCoroutine("fightResponse");
    }

    public void SecondHit()
    {
        StopCoroutine("fightResponse");
        fightButton2.gameObject.SetActive(false);
        nodeToCall = "FlytrapFight2";
        //buttonCanvas.SetActive(false);
        StartCoroutine("fightResponse");
        fightCam02.Priority = 0;
        fightCam03.Priority = 12;
        fightButtonFinal.gameObject.SetActive(true);
        //StopCoroutine("fightResponse");
    }

    IEnumerator fightResponse()
    {
        buttonCanvas.SetActive(false);
        Debug.Log("playing slash");
        playerAnim.SetBool("fight", true);
        playerAnimShadow.SetBool("fight", true);
        yield return new WaitForSeconds(1f);
        introCutsceneScript.slashObject.SetActive(true);
        introCutsceneScript.fightSounds.PlayOneShot(introCutsceneScript.slash);
        introCutsceneScript.fightSounds.PlayOneShot(introCutsceneScript.shriek);
        introCutsceneScript.slashObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        playerAnim.SetBool("fight", false);
        playerAnimShadow.SetBool("fight", false);
        yield return new WaitForSeconds(1f);
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
        {
            FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
        }
        yield return new WaitForSeconds(3.5f);
        buttonCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
}
