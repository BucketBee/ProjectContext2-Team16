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
    private TextMeshProUGUI _characterOccupation;
    [SerializeField]
    private TextMeshProUGUI _characterAge;
    [SerializeField]
    private Image _characterIcon;
    [SerializeField]
    private CharacterInfoScriptableObject _startingCharacter;

    private void OnEnable()
    {
        EventManager.OnCharacterChange += UpdateUI;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI(_startingCharacter);
    }

    private void UpdateUI(CharacterInfoScriptableObject character)
    {
        _characterName.text = character._name;
        _characterOccupation.text = character._occupation;
        _characterAge.text= character._age;
        _characterIcon.sprite = character._icon;
    }
    private void OnDestroy()
    {
        EventManager.OnCharacterChange -= UpdateUI;
    }
}
