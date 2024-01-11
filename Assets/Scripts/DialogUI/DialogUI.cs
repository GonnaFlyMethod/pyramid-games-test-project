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

    private void Update()
    {
        Button yesButton, noButton;
        getButtons(out yesButton, out noButton);

        if (!yesButton.IsActive())
        {
            yesButton.onClick.RemoveAllListeners();
        }

        if (!noButton.IsActive())
        {
            noButton.onClick.RemoveAllListeners();
        }
    }

    private void getButtons(out Button yesBtn, out Button noBtn)
    {
        DialogComponents dialogComponents = _yesNoGO.GetComponent<DialogComponents>();
        List<Button> buttons = dialogComponents.GetButtons();

        yesBtn = buttons[0];
        noBtn = buttons[1];
    }

    public bool isPlayerInDialog(){ return _isPlayerInDialog;}

    public void ShowYesNoDialog(string dialogMessage, Action yesButtonCallback, Action noButtonCallback)
    {
        _yesNoGO.SetActive(true);

        _isPlayerInDialog = true; 

        DialogComponents dialogComponents = _yesNoGO.GetComponent<DialogComponents>();

        TextMeshProUGUI txtMeshPro = dialogComponents.GetTxtMeshPro();
        txtMeshPro.text = dialogMessage;

        Button yesBtn, noBtn;
        getButtons(out yesBtn, out noBtn);

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
