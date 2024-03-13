using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScriptableObjectManager : MonoBehaviour
{
    [Header("UI content")]
    [SerializeField]
    private TextMeshProUGUI _notificationTextUI;
    [SerializeField]
    private Image _notificationIconUI;

    [Header("ScriptableObject")]
    [SerializeField] private NotificationScriptableObject _noteScriptableObject;

    [Header("Notifaction Animation")]
    [SerializeField] private Animator _notifacitonAnim;

    [SerializeField] private List<NotificationScriptableObject> notificationScriptableObjects = new List<NotificationScriptableObject>();
    private void Awake()
    {
        EventManager.OnSceneSwitchClose += ClearNotification;
        EventManager.OnSceneSwitchOpen += EnableNotifaction;
    }
    public void AddNotification(NotificationScriptableObject _noteScriptableObjectInstance)
    {
        notificationScriptableObjects.Add(_noteScriptableObjectInstance);
    }
    private void Start()
    {
        EnableNotifaction();
    }
    public void EnableNotifaction()
    {
        StartCoroutine(EnableNotifactionCoroutine());
    }
    public IEnumerator EnableNotifactionCoroutine()
    {
        if(notificationScriptableObjects.Count == 0)
            yield break;

        _noteScriptableObject = notificationScriptableObjects[0];
        _notifacitonAnim.Play("NotificationAnimationFadeIn");
        _notificationTextUI.text = _noteScriptableObject._notifactionMessage;
        _notificationIconUI.sprite = _noteScriptableObject._icon;

        if (_noteScriptableObject._disableAfterTimer)
        {
            yield return new WaitForSeconds(_noteScriptableObject._disableTimer);
            StartCoroutine(RemoveNotification());
        }

    }
    public IEnumerator RemoveNotification()
    {
        _notifacitonAnim.Play("NotificationAnimationFadeOut");
        //unity bs want anders pak hij nog de vorige animation (stringmatching issue)
        yield return new WaitForSeconds(.1f);
        //checking if animation
        yield return new WaitUntil(() => _notifacitonAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        notificationScriptableObjects.RemoveAt(0);
        if(notificationScriptableObjects.Count > 0)
        {
            EnableNotifaction();
        }
    }
    public void ClearNotification()
    {
        _noteScriptableObject = null;
    }
    private void OnDestroy()
    {
        EventManager.OnSceneSwitchClose -= ClearNotification;
        EventManager.OnSceneSwitchOpen -= EnableNotifaction;
        StopAllCoroutines();
    }
}
