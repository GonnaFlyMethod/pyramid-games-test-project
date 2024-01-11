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

    private bool _isPlayerInDialog;

    private void Awake()
    {
        Instance = this;
    }

    public bool isPlayerInDialog(){ return _isPlayerInDialog;}

    public void ShowYesNoDialog(string dialogMessage, Action yesButtonCallback, Action noButtonCallback)
    {
        _yesNoGO.SetActive(true);

        _isPlayerInDialog = true; 

        DialogComponents dialogComponents = _yesNoGO.GetComponent<DialogComponents>();

        TextMeshProUGUI txtMeshPro = dialogComponents.GetTxtMeshPro();
        txtMeshPro.text = dialogMessage;

        List<Button> buttons = dialogComponents.GetButtons();

        Button yesBtn = buttons[0];
        Button noBtn = buttons[1];

        yesBtn.onClick.AddListener(() =>
        {
            HideDialog(_yesNoGO);
            yesButtonCallback();
        });

        noBtn.onClick.AddListener(() =>
        {
            HideDialog(_yesNoGO);
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
            HideDialog(_messageOnlyGO);
            okCallback();
        });
    }

    private void HideDialog(GameObject dialog)
    {
        dialog.SetActive(false);
        _isPlayerInDialog = false;
    }
}
