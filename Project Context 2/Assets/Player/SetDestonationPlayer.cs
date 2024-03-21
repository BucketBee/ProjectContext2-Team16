using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SetDestonationPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private string Scene;
    public void OnPointerClick(PointerEventData eventData)
    {
      SceneManager.LoadScene(Scene);
      EventManager.CallOnSceneSwitch();
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
