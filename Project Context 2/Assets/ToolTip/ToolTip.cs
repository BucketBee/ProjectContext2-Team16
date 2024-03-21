using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public string Message;
    private void OnMouseEnter()
    {
        ToolTipManager._instance.SetAndShowToolTip(Message);
    }
    private void OnMouseExit()
    {
        ToolTipManager._instance.HideToolTip();
    }
}
