using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteManager : MonoBehaviour
{
    static public CharacterInfoScriptableObject currentCharacter { get; private set; }
    public static void ChangeCharacter(CharacterInfoScriptableObject character)
    {
        currentCharacter= character;
        EventManager.CallOnCharacterChangeEvent(character);
    }
    
}
