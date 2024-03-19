using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationTriggerEvent : MonoBehaviour
{
    [Header("UI content")]
    [SerializeField]
    private TextMeshProUGUI _notificationTextUI;
    [SerializeField]
    private Image _notificationIconUI;

    [Header("Message Customisation")]
    [SerializeField]
    private Sprite _icon;
    [SerializeField][TextArea] private string _notifactionMessage;

    [Header("Message Customisation")]
    [SerializeField]
    private bool _removeAfterExit = false;
    [SerializeField]
    private bool _disableAfterTimer = false;
    [SerializeField]
    private float _disableTimer = 1.0f;

    [Header("Notifaction Animation")]
    [SerializeField] private Animator _notifacitonAnim;
    private BoxCollider _objectCollider;

    private const string PLAYER_TAG = "Player";
    private void Awake()
    {
        _objectCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            EnableNotifaction();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG) && _removeAfterExit)
        {
            RemoveNotification();
        }
    }
    async void EnableNotifaction()
    {
        _objectCollider.enabled = false;
        _notifacitonAnim.Play("NotificationAnimationFadeIn");
        _notificationTextUI.text = _notifactionMessage;
        _notificationIconUI.sprite = _icon;

        if (_disableAfterTimer)
        {
            await Task.Delay((int)(_disableTimer * 1000f));
        }

    }

    private void RemoveNotification()
    {
        _notifacitonAnim.Play("NotificationAnimationFadeOut");
        gameObject.SetActive(false);
    }

}
