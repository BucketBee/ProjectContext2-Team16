using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractionBox : MonoBehaviour
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
        dialogue.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (dialogue != null)
        {
            control.enabled = false;
            dialogue.SetActive(true);
            player.cursorInputForLook = false;
            player.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cam.LookAt = transform;
        }
    }
}
