using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class CameraTransitionEffect : MonoBehaviour
{
    [SerializeField] private Volume postProcessing;
    private LensDistortion lensDistortion;


    private Vector3 originalPosition;

    [SerializeField] private Transform cameraToTransition;
    [SerializeField] private Transform cameraToTransitionTo;

    public AnimationCurve curve;

    public static CameraTransitionEffect Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //make sure this object doesnt get destroyed when switching to scenes
        Object.DontDestroyOnLoad(gameObject);
        postProcessing.profile.TryGet<LensDistortion>(out lensDistortion);

        SceneManager.sceneLoaded += CallTransitionOut;
    }

    public void TransitionStart(Object scene)
    {
        StartCoroutine(TransitionCameraIn(scene));
    }

    //this one does the zoom in. You could change cameraToTransitionTo to a different object, either the mouse position of 
    //where you click, or a gameobject thats close to the scenario you select
    public IEnumerator TransitionCameraIn(Object _scene)
    {
        float time = 1.5f;
        Vector3 startingPos = cameraToTransition.position;
        Vector3 finalPos = cameraToTransitionTo.position;

        float elapsedTime = 1.5f;
       
        while (elapsedTime < time)
        {
            cameraToTransition.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            Debug.Log(curve.Evaluate(elapsedTime));
            elapsedTime += Time.deltaTime * curve.Evaluate(elapsedTime);
            lensDistortion.intensity.value = Mathf.Lerp(0.25f, 1f, elapsedTime);
            lensDistortion.scale.value = Mathf.Lerp(1f, 0.75f, elapsedTime);
            yield return null;
        }
        if (elapsedTime >= time)
        {
            //Do the scene transition here
            SceneManager.LoadScene(_scene.name.ToString());
        }
    }

    //Call the transition backinwards to the camera when a new scene is loaded
    //these parameters don't matter.
    //the program just bitches if i dont use them
    private void CallTransitionOut(Scene scene, LoadSceneMode mode)
    {
        lensDistortion.intensity.value = 1f;
        lensDistortion.scale.value = 0.75f;
        //StartCoroutine(TransitionCameraOut());
    }

    private IEnumerator TransitionCameraOut()
    {
        float time = 1.5f;

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime * curve.Evaluate(elapsedTime);
            lensDistortion.intensity.value = Mathf.Lerp(1, 0f, elapsedTime);
            lensDistortion.scale.value = Mathf.Lerp(0f, 1f, elapsedTime);
            yield return null;
        }
    }
}
