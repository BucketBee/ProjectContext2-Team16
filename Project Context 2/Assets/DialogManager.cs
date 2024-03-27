using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _dialogTrigger1;
    [SerializeField]
    private GameObject _dialogTrigger2;
    [SerializeField]
    private GameObject _dialogTrigger3;
    [SerializeField]
    private GameObject _audioTrigger1;
    [SerializeField]
    private GameObject _audioTrigger2;
    [SerializeField]
    private GameObject _audioTrigger3;

    // Start is called before the first frame update
    void Start()
    {
        _dialogTrigger1.SetActive(false);
        _dialogTrigger2.SetActive(false);
        _dialogTrigger3.SetActive(false);
        _audioTrigger1.SetActive(false);
        _audioTrigger2.SetActive(false);
        _audioTrigger2.SetActive(false);

        ChangeDialogTrigger();
    }
    private void Awake()
    {
        EventManager.OnSceneSwitch += ChangeDialogTrigger;
    }
    private void ChangeDialogTrigger()
    {
        switch(GameStateManager.gameState)
        {
            default:
                _dialogTrigger1.SetActive(true);
                _audioTrigger1.SetActive(true);
                break;
            case 1:
                _dialogTrigger2.SetActive(true);
                _audioTrigger1.SetActive(true);
                break;
            case 2:
                _dialogTrigger3.SetActive(true);
                _audioTrigger2.SetActive(true);
                break;
            case 3:
                _audioTrigger3.SetActive(true);
                break;




        }
    }
    private void OnDisable()
    {
        EventManager.OnSceneSwitch -= ChangeDialogTrigger;
    }
}
