using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TextBoxCustomCommands : MonoBehaviour
{
    public GameObject cloudBG;
    public GameObject bookBG;

    public GameObject avatar;
    public GameObject border;
    public GameObject bgBox;
    public GameObject bgBorder;
    public GameObject characterName;

    private void Start()
    {
        cloudBG.SetActive(false);
        bookBG.SetActive(false);

        avatar.SetActive(true);
        border.SetActive(true);
        bgBox.SetActive(true);
        bgBorder.SetActive(true);
        characterName.SetActive(true);
    }

    [YarnCommand("turnOnCloud")]
    public void TurnOnCloud()
    {
        avatar.SetActive(false);
        border.SetActive(false);
        bgBox.SetActive(false);
        bgBorder.SetActive(false);
        characterName.SetActive(false);

        bookBG.SetActive(false);
        cloudBG.SetActive(true);
    }

    [YarnCommand("turnOnBook")]
    public void TurnOnBook()
    {
        avatar.SetActive(false);
        border.SetActive(false);
        bgBox.SetActive(false);
        bgBorder.SetActive(false);
        characterName.SetActive(false);

        cloudBG.SetActive(false);
        bookBG.SetActive(true);
    }

    [YarnCommand("turnOnDialogue")]
    public void TurnOnDialogue()
    {
        cloudBG.SetActive(false);
        bookBG.SetActive(false);

        avatar.SetActive(true);
        border.SetActive(true);
        bgBox.SetActive(true);
        bgBorder.SetActive(true);
        characterName.SetActive(true);
    }
}
