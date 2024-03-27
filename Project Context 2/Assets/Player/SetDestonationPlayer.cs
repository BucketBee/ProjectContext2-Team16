using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SetDestonationPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private string Scene;

    private bool _clickable;
    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("BOMBA");
        //EventManager.CallOnSceneSwitch();
        //SceneManager.LoadScene(Scene);

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _clickable)
        {
            Debug.Log("BOMBA");
            EventManager.CallOnSceneSwitch();
            SceneManager.LoadScene(Scene);
        }
    }
    private void OnMouseEnter()
    {
        _clickable= true;
    }
    private void OnMouseExit()
    {
        _clickable= false;
    }

}
