using cherrydev;
using Cinemachine;
using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InteractionBox : MonoBehaviour
{
    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph dialogGraph;
    [SerializeField] private int _newGameState;

    StarterAssetsInputs player;
    FirstPersonController control;
    CinemachineVirtualCamera cam;

    public float inspirationAmount = 0f;
    public Object NextSceneOnSuccess;
    public Object NextSceneOnFail;

    private Object NextScene;

    private bool successfulInteraction = false;
    private bool interactionCompleted = false;
    GameObject bg;

    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;

    void Start()
    {
        player = FindObjectOfType<StarterAssetsInputs>();
        control = FindObjectOfType<FirstPersonController>();
        cam = FindObjectOfType<CinemachineVirtualCamera>();
        bg = GameObject.Find("Background");
        dialogBehaviour.BindExternalFunction("success", Success);
        dialogBehaviour.BindExternalFunction("fail", Fail);
    }
    private void Success()
    {
            successfulInteraction = true;
            NextScene = NextSceneOnSuccess;
    }

    public void Fail()
    {
            NextScene = NextSceneOnFail;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (dialogBehaviour != null)
        {
            initialCameraPosition = cam.transform.position;
            initialCameraRotation = cam.transform.rotation;
            dialogBehaviour.StartDialog(dialogGraph);
            control.enabled = false;
            player.cursorInputForLook = false;
            player.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(EnableBackground());
            cam.LookAt = transform;
        }
    }
    public void EndConvo()
    {
        //control.enabled = true;
        //StartCoroutine(DisableBackground());
        //player.cursorInputForLook = true;
        //player.cursorLocked = true;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //cam.LookAt = null;
        //cam.transform.SetPositionAndRotation(initialCameraPosition, initialCameraRotation);
        EventManager.CallOnSceneSwitch();
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (NextScene != null)
        {
            SceneManager.LoadScene(NextScene.name);
        }
        else
            SceneManager.LoadScene("Test - Erik");

        if (!interactionCompleted && successfulInteraction)
        {
            InspirationManager.ChangeInspirationMeter(inspirationAmount);
            Debug.Log("Sent " + inspirationAmount + " inspiration to EventManager.");
            interactionCompleted = true;
        }
        GameStateManager.ChangeGameState(_newGameState);
    }

    IEnumerator EnableBackground()
    {
        bg.SetActive(true);
        float maxTime = 1f;
        Image image = bg.GetComponent<Image>();
        for (float currentTime = 0f; currentTime < maxTime; currentTime += Time.deltaTime)
        {
            float normalizedTime = currentTime / maxTime;
            float alpha = Mathf.Lerp(0f, 1f, normalizedTime);

            image.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }
        image.color = new Color(1f, 1f, 1f, 1f);
    }
    IEnumerator DisableBackground()
    {
        bg.SetActive(true);
        float maxTime = 1f;
        Image image = bg.GetComponent<Image>();
        for (float currentTime = 0f; currentTime < maxTime; currentTime += Time.deltaTime)
        {
            float normalizedTime = currentTime / maxTime;
            float alpha = Mathf.Lerp(1f, 0f, normalizedTime);

            image.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }
        image.color = new Color(1f, 1f, 1f, 0f);
    }
}
