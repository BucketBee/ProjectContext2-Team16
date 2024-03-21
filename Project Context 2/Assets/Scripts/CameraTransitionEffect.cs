using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraTransitionEffect : MonoBehaviour
{
    [SerializeField] private Volume postProcessing;
    private LensDistortion lensDistortion;


    private Vector3 originalPosition;

    [SerializeField] private Transform cameraToTransition;
    [SerializeField] private Transform cameraToTransitionTo;


	[SerializeField] private GameObject objectToDisable;
	[SerializeField] private GameObject objectToEnable;

	public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
		 postProcessing.profile.TryGet<LensDistortion>(out lensDistortion);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.K))
		{
			StartCoroutine(TransitionCamera());
		}
	}
	private IEnumerator TransitionCamera()
    {
		float time = 1.5f;
		Vector3 startingPos = cameraToTransition.position;
		Vector3 finalPos = cameraToTransitionTo.position;

		float elapsedTime = 0;

		while (elapsedTime < time)
		{
			cameraToTransition.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
			
			elapsedTime += Time.deltaTime * curve.Evaluate(elapsedTime);
			Debug.Log(curve.Evaluate(elapsedTime));
			lensDistortion.intensity.value = Mathf.Lerp(0.25f, 1f, elapsedTime);
			lensDistortion.scale.value = Mathf.Lerp(1f, 0.75f, elapsedTime);
			yield return null;
		}
		objectToDisable.SetActive(false);
		objectToEnable.SetActive(true);
		elapsedTime = 0;

		while (elapsedTime < time)
		{
			elapsedTime += Time.deltaTime * curve.Evaluate(elapsedTime);
			lensDistortion.intensity.value = Mathf.Lerp(1, 0f, elapsedTime);
			lensDistortion.scale.value = Mathf.Lerp(0f, 1f, elapsedTime);
			yield return null;
		}
	}
}
