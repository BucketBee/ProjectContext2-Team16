using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject dialogue;
    StarterAssetsInputs player;
    FirstPersonController control;
    CinemachineVirtualCamera cam;

    void Start()
    {
        player = FindObjectOfType<StarterAssetsInputs>();
        control = FindObjectOfType<FirstPersonController>();
        cam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void EndConvo()
    {
        control.enabled = true;
        dialogue.SetActive(false);
        player.cursorInputForLook = true;
        player.cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam.LookAt = null;
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
}