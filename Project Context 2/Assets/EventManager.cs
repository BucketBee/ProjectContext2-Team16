using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    static public event Action OnSceneSwitch;
    static public event Action<CharacterInfoScriptableObject> OnCharacterChange;

    static public void CallOnCharacterChangeEvent(CharacterInfoScriptableObject obj)
    {
        OnCharacterChange(obj);
    }

    static public void CallOnSceneSwitch()
    {
        OnSceneSwitch?.Invoke();
    }

}
