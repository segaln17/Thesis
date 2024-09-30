using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu
(fileName = "NewLine", 
    menuName = "NewLine", order = 0),]

public class SpriteTextScriptableObjects : ScriptableObject
{
    public Sprite textLine;
    public Sprite textBox;

    public string writtenText;
    //for when character portraits:
    public Sprite characterPortrait;
}
