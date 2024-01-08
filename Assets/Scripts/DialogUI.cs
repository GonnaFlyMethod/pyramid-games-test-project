using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public static DialogUI Instance { get; private set; }

    [SerializeField] private GameObject _yesNoGO;
    [SerializeField] private GameObject _messageOnlyGO;

    public void ShowYesNoDialog(string dialogMessage, Action yesButtonCallback, Action noButtonCallback)
    {
        _yesNoGO.SetActive(true);

        DialogComponents dialogComponents = _yesNoGO.GetComponent<DialogComponents>();

        TextMeshProUGUI txtMeshPro = dialogComponents.GetTxtMeshPro();
        txtMeshPro.text = dialogMessage;

        List<Button> buttons = dialogComponents.GetButtons();

        Button yesBtn = buttons[0];
        Button noBtn = buttons[1];

        yesBtn.onClick.AddListener(() =>
        {
            _yesNoGO.SetActive(false);
            yesButtonCallback();
        });

        noBtn.onClick.AddListener(() =>
        {
            _yesNoGO.SetActive(false);
            noButtonCallback();
        });
    }

    public void ShowMessageOnlyDialog(string dialogMessage, Action okCallback)
    {
        _messageOnlyGO.SetActive(true);

        DialogComponents dialogComponents = _messageOnlyGO.GetComponent<DialogComponents>();

        TextMeshProUGUI txtMeshPro = dialogComponents.GetTxtMeshPro();
        txtMeshPro.text = dialogMessage;

        Button okBtn = dialogComponents.GetButtons()[0];

        okBtn.onClick.AddListener(() =>
        {
            _messageOnlyGO.SetActive(false);
            okCallback();
        });
    }
}
