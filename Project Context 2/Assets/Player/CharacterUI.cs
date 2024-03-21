using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _characterName;
    [SerializeField]
    private TextMeshProUGUI _characterInfo;
    [SerializeField]
    private Image _characterIcon;

    private void OnEnable()
    {
        EventManager.OnCharacterChange += UpdateUI;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI(CharacteManager.currentCharacter);
    }

    private void UpdateUI(CharacterInfoScriptableObject character)
    {
        _characterName.text = character._name;
        _characterInfo.text = character._description;
        _characterIcon.sprite = character._icon;
    }
    private void OnDestroy()
    {
        EventManager.OnCharacterChange -= UpdateUI;
    }
}
