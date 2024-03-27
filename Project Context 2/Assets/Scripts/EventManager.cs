using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager _instance;
    static public event Action OnSceneSwitch;
    static public event Action<CharacterInfoScriptableObject> OnCharacterChange;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    static public void CallOnCharacterChangeEvent(CharacterInfoScriptableObject obj)
    {
        OnCharacterChange(obj);
    }

    static public void CallOnSceneSwitch()
    {
        OnSceneSwitch?.Invoke();
    }


}
