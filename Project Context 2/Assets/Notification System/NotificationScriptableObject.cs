using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Notification",menuName = "CustomScriptableObjects/Notification")]
public class NotificationScriptableObject : ScriptableObject
{
    [Header("Message Customisation")]
   [TextArea] public string _notifactionMessage;

    [Header("Message Customisation")]
    public bool _disableAfterTimer = false;
    public float _disableTimer = 1.0f;
}
