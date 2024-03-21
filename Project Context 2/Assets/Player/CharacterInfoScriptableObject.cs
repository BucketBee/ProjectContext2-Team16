using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "CustomScriptableObjects/Character")]
public class CharacterInfoScriptableObject : ScriptableObject
{
    [Header("Name")]
    public string _name;
    [Header("Photo")]
    public Sprite _icon;
    [Header("Description")]
    [TextArea] public string _description;
}
