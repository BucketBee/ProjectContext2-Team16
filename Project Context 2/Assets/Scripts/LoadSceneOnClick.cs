using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class LoadSceneOnClick : MonoBehaviour
{
    public Object scene;
    private void OnMouseDown()
    {
        FindObjectOfType<CameraTransitionEffect>().TransitionStart(scene);
    }
}