using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetDestonationPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Transform target;

    private PlayerTopDownMovementManager _playerManager;
    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerTopDownMovementManager>();
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _playerManager.SetDestonationPLayer(target);
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
