using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteManager : MonoBehaviour
{
    static public CharacterInfoScriptableObject _currentCharacter { get; private set; }
    [SerializeField]
    private CharacterInfoScriptableObject _startCharacter;
    public static void ChangeCharacter(CharacterInfoScriptableObject character)
    {
        _currentCharacter= character;
        EventManager.CallOnCharacterChangeEvent(character);
    }
    
}
