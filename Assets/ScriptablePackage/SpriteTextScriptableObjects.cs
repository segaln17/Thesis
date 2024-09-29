using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu
(fileName = "NewLine", 
    menuName = "NewLine", order = 0),]

public class SpriteTextScriptableObjects : ScriptableObject
{
    public Sprite textLine;
    public Sprite textBox;
}
