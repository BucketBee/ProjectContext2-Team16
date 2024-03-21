using cherrydev;
using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractionBox : MonoBehaviour
{
    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph dialogGraph;

    StarterAssetsInputs player;
    FirstPersonController control;
    CinemachineVirtualCamera cam;

    NpcManager npcManager;

    public float inspirationAmount = 0f;

    private bool successfulInteraction = false;
    private bool interactionCompleted = false;

    void Start()
    {
        player = FindObjectOfType<StarterAssetsInputs>();
        control = FindObjectOfType<FirstPersonController>();
        cam = FindObjectOfType<CinemachineVirtualCamera>();
        dialogBehaviour.BindExternalFunction("success", Success);
    }
    private void Success()
    {
        successfulInteraction = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (dialogBehaviour != null)
        {
            dialogBehaviour.StartDialog(dialogGraph);
            control.enabled = false;
            player.cursorInputForLook = false;
            player.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cam.LookAt = transform;
        }
    }
    public void EndConvo()
    {
        control.enabled = true;
        player.cursorInputForLook = true;
        player.cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam.LookAt = null;
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        if (!interactionCompleted && successfulInteraction)
        {
            InspirationManager.ChangeInspirationMeter(inspirationAmount);
            Debug.Log("Sent " + inspirationAmount + " inspiration to EventManager.");
            interactionCompleted = true;
        }
    }
}