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

    [SerializeField] static private List<NotificationScriptableObject> notificationScriptableObjects = new List<NotificationScriptableObject>();
    private void Awake()
    {
        EventManager.OnSceneSwitch += EnableNotifaction;
    }
    static public void AddNotification(NotificationScriptableObject _noteScriptableObjectInstance)
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


        if (_noteScriptableObject._disableAfterTimer)
        {
            yield return new WaitForSeconds(_noteScriptableObject._disableTimer);
            RemoveNotification();
        }

    }
    public void RemoveNotification()
    {
        StartCoroutine(RemoveNotificationCoroutine());
    }
    public IEnumerator RemoveNotificationCoroutine()
    {
        _notifacitonAnim.Play("NotificationAnimationFadeOut");
        //unity bs want anders pak hij nog de vorige animation (stringmatching issue)
        yield return new WaitForSeconds(.1f);
        //checking if animation
        yield return new WaitUntil(() => _notifacitonAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        notificationScriptableObjects.RemoveAt(0);
        if(notificationScriptableObjects.Count > 0)
        {
            yield return new WaitForSeconds(Random.Range(0, 20));
            EnableNotifaction();
        }
    }
    public void ClearNotification()
    {
        _noteScriptableObject = null;
    }
    static public void ClearNotificationList()
    {
        notificationScriptableObjects.Clear();
    }
    private void OnDisable()
    {
        EventManager.OnSceneSwitch-= EnableNotifaction;
        StopAllCoroutines();
    }
}
