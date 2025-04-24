using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class TextBoxCustomCommands : MonoBehaviour
{
    public GameObject cloudBG;
    public GameObject bookBG;
    public GameObject phoebeBG;
    public GameObject fenBG;
    public GameObject NPCBG;

    public GameObject avatar;
    //public GameObject border;
    //public GameObject bgBox;
    //public GameObject bgBorder;
    public GameObject characterName;

    public TextMeshProUGUI charText;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI bodyText;

    private void Start()
    {
        cloudBG.SetActive(false);
        bookBG.SetActive(false);
        fenBG.SetActive(false);
        phoebeBG.SetActive(false);

        avatar.SetActive(true);
        NPCBG.SetActive(true);
        characterName.SetActive(true);
    }

    [YarnCommand("turnOnCloud")]
    public void TurnOnCloud()
    {
        avatar.SetActive(false);
        NPCBG.SetActive(false);
        characterName.SetActive(false);

        bookBG.SetActive(false);
        cloudBG.SetActive(true);
        fenBG.SetActive(false);
        phoebeBG.SetActive(false);
        //charText.color = new Color(255, 208, 0, 1);
        instructionText.color = new Color(255, 208, 0, 1);
        bodyText.color = new Color(255, 208, 0, 1);
    }

    [YarnCommand("turnOnBook")]
    public void TurnOnBook()
    {
        avatar.SetActive(false);
        NPCBG.SetActive(false);
        fenBG.SetActive(false);
        characterName.SetActive(false);

        cloudBG.SetActive(false);
        bookBG.SetActive(true);
        charText.color = new Color(25f, 29f, 36f, 1);
        instructionText.color = new Color(25f, 29f, 36f, 1);
        bodyText.color = new Color(25f, 29f, 36f, 1);
    }

    [YarnCommand("turnOnDialogue")]
    public void TurnOnDialogue()
    {
        cloudBG.SetActive(false);
        bookBG.SetActive(false);
        fenBG.SetActive(false);
        phoebeBG.SetActive(false);

        avatar.SetActive(true);
        NPCBG.SetActive(true);
        characterName.SetActive(true);
        charText.color = new Color(255f, 255f, 255f, 1);
        instructionText.color = new Color(255f, 255f, 255f, 1);
        bodyText.color = new Color(255f, 255f, 255f, 1);
    }

    [YarnCommand("turnOnPhoebe")]
    public void TurnOnPhoebe()
    {
        cloudBG.SetActive(false);
        bookBG.SetActive(false);
        fenBG.SetActive(false);
        NPCBG.SetActive(false);
        
        phoebeBG.SetActive(true);
        characterName.SetActive(true);
        avatar.SetActive(true);
        charText.color = new Color(255f, 0f, 123f, 1);
        instructionText.color = new Color(255f, 0f, 123f, 1);
        bodyText.color = new Color(255f, 0f, 123f, 1);

    }
    
    [YarnCommand("turnOnFen")]
    public void TurnOnFen()
    {
        cloudBG.SetActive(false);
        bookBG.SetActive(false);
        NPCBG.SetActive(false);
        phoebeBG.SetActive(false);
        
        fenBG.SetActive(true);
        characterName.SetActive(true);
        avatar.SetActive(true);
        charText.color = new Color(229, 255, 0, 1);
        instructionText.color = new Color(229, 255, 0, 1);
        bodyText.color = new Color(229, 255, 0, 1);

    }
    
}
